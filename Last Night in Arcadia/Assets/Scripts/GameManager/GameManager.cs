using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int TotalNumberOfCharacters = 16;
    private const int EXECUTIONER_INDEX = -1;

    private static GameManager _instance;
    private Character[] _characters;
    private Executioner _executioner;


    public static GameManager Instance { get { return _instance; } private set { } }
    public Executioner Executioner { get { return _executioner; } private set { } }


    /// <summary>
    /// Implement the game manager as a singleton and starts a new game.
    /// </summary>
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        StartNewGame();
    }

    public DayTracker.TimesOfDay GetTimeOfDay()
    {
        return GetComponent<DayTracker>().GetTimeOfDayEnum();
    }


    /// <summary>
    /// Creates, randomizes, and initializes a new character's array.
    /// </summary>
    public void StartNewGame()
    {
        _characters = new Character[TotalNumberOfCharacters];
        SOPerson[] people = LoadResourcesFolder<SOPerson>("People");
        SORole[] roles = LoadResourcesFolder<SORole>("Roles");

        foreach (var character in RandomZip(people, roles))
        {
            Type type = Type.GetType(character.role.Name);
            Debug.Assert(type != null,
                String.Format("{0} is not a valid type. Check spelling of scriptable object and associated script.", character.role.Name));

            _characters[character.index] = (Character)Activator.CreateInstance(type, character.person, character.role, character.index);
        }

        CreateExecutioner();
    }


    /// <summary>
    /// Returns the character from the character's array at the given index. Assumes the given
    /// index is within range of the character's array.
    /// </summary>
    /// <param name="index">Index to the character's array.</param>
    /// <returns>Character associated with the given index.</returns>
    public Character GetCharacter(int index)
    {
        return _characters[index];
    }


    /// <summary>
    /// Returns a copy of the character's array.
    /// </summary>
    /// <returns></returns>
    public Character[] GetCharacters()
    {
        List<Character> characters = new List<Character>(_characters);

        return characters.ToArray();
    }


    /// <summary>
    /// Returns an array of characters that match the given condition.
    /// </summary>
    /// <param name="condition">A function that takes in a Character as a parameter and returns a bool.</param>
    /// <returns>Array of characters that match the given condition.</returns>
    public Character[] GetCharacters(Func<Character, bool> condition)
    {
        List<Character> characters = new List<Character>();

        foreach (Character character in _characters)
        {
            if (condition(character))
            {
                characters.Add(character);
            }
        }

        return characters.ToArray();
    }


    /// <summary>
    /// Calls each character's TakeAction method.
    /// </summary>
    public void TakeActions()
    {
        _executioner.TakeAction();

        // Sort by Role Index
        Character[] characters = GetCharacters(c => c.IsAlive);
        System.Array.Sort(characters, (c1, c2) => { return c1.RoleIndex.CompareTo(c2.RoleIndex); });

        foreach (Character character in characters)
        {
            character.TakeAction();
        }
    }


    /// <summary>
    /// Sets the targeter's target and vice versa.
    /// </summary>
    /// <param name="targeter">The character whose going to act upon the target.</param>
    /// <param name="target">Character who will be acted upon by the targeter.</param>
    public void SetTarget(Character targeter, Character target)
    {
        if (targeter.Index == EXECUTIONER_INDEX)
        {
            _executioner.SetTarget(target);
        }
        else
        {
            _characters[targeter.Index].SetTarget(target);
        }

        _characters[target.Index].SetTargeter(targeter);
    }


    /// <summary>
    /// Returns an array of all the assets from a specified folder in the Resource folder.
    /// </summary>
    /// <typeparam name="T">Asset type.</typeparam>
    /// <param name="path">Pathname to the target folder, is relative to any Resource folder.</param>
    /// <returns>Array of asset types from the target folder.</returns>
    private T[] LoadResourcesFolder<T>(string path)
    {
        T[] assets = Resources.LoadAll(path, typeof(T)).Cast<T>().ToArray();

        Debug.Assert(assets != null,
            String.Format("Path ({0}) could not be found in the Resources folder.", path));

        Debug.Assert(assets.Length == TotalNumberOfCharacters,
            String.Format("Number of {0} assets ({1}) doesn't match the number of characters ({2})", typeof(T), assets.Length, TotalNumberOfCharacters));

        return assets;
    }


    /// <summary>
    /// Returns a unique IEnumerable tuple that represents a randomized character combination.
    /// </summary>
    /// <param name="people">Array of Person scriptable objects.</param>
    /// <param name="roles">Array of Role scriptable objects.</param>
    /// <returns>A unique IEnumerable tuple of a randomized character.</returns>
    private IEnumerable<(SOPerson person, SORole role, int index)> RandomZip(SOPerson[] people, SORole[] roles)
    {
        Shuffle(people);
        Shuffle(roles);

        for (int i = 0; i < TotalNumberOfCharacters; i++)
        {
            yield return (people[i], roles[i], i);
        }
    }


    /// <summary>
    /// Randomly shuffles an array using a Fisher�Yates shuffle.
    /// </summary>
    /// <typeparam name="T">Array type.</typeparam>
    /// <param name="array">Array to be shuffled.</param>
    private void Shuffle<T>(T[] array)
    {
        // Ya I just copy and pasted this from stack overflow :) - Diego
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }


    private void CreateExecutioner()
    {
        SOPerson executionerPerson = Resources.Load<SOPerson>("Executioner/ExecutionerPerson");
        SORole executionerRole = Resources.Load<SORole>("Executioner/ExecutionerRole");

        Type type = Type.GetType("Executioner");
        Debug.Assert(type != null,
                String.Format("{0} is not a valid type. Check spelling of scriptable object and associated script.", executionerRole.Name));

        _executioner = (Executioner)Activator.CreateInstance(type, executionerPerson, executionerRole, EXECUTIONER_INDEX);
    }
}
