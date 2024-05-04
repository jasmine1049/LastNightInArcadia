using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } private set { } }

    private Character[] _characters;


    /// <summary>
    /// Implement the game manager as a singleton. Initialize characters list.
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

        // Put these 3 in an "initialize" function so it's easier to run multiple games, simply call these
        // three again in the afermentioned function.
        // Oh and probably a variable in the fuction that checks for "new game"
        CreateCharactersList();
        ShuffleCharacterList();
        AssignRoles();
    }


    /// <summary>
    /// Returns the character from the character's array at the given index.
    /// </summary>
    /// <param name="index">Index to the character's array.</param>
    /// <returns>Character from character's array.</returns>
    public Character GetCharacter(int index)
    {
        return _characters[index];
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
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


    public void SetTarget(int targeter, int target)
    {
        _characters[targeter].SetTarget(_characters[target]);
        _characters[target].SetTargeter(_characters[targeter]);
    }


    /// <summary>
    /// Creates the characters list and initializes each character from it's scriptable object.
    /// </summary>
    private void CreateCharactersList()
    {
        SOCharacter[] SOCharacters = Resources.LoadAll<SOCharacter>("Characters");

        _characters = new Character[SOCharacters.Length];
        for (int i = 0; i < SOCharacters.Length; i++)
        {
            _characters[i] = new Character(SOCharacters[i]);
        }
    }


    /// <summary>
    /// Randomly shuffles characters list using a Fisher-Yates algorithm.
    /// </summary>
    private void ShuffleCharacterList()
    {
        for (int i = _characters.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Character temp = _characters[i];
            _characters[i] = _characters[j];
            _characters[j] = temp;
        }
    }


    /// <summary>
    /// Assigns a role to each character. Assumes each role was given a unique role index and is of
    /// equal length to the number of characters.
    /// </summary>
    private void AssignRoles()
    {
        SORole[] SORoles = Resources.LoadAll<SORole>("Roles");

        for (int i = 0; i < SORoles.Length; i++)
        {
            SORole role = SORoles[i];
            _characters[role.Index].AssignRole(role);
        }
    }
}
