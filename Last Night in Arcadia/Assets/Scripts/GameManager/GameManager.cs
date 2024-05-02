using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } private set { } }

    private List<SOCharacter> _SOCharacters;
    private List<SORole> _SORoles;
    private List<Character> _characters;
    public List<Character> Characters { get { return _characters; } private set { } }
    public List<SORole> SORoles { get { return _SORoles; } private set { } }

    private DayTracker _dayTracker;
    private MoraleSystem _moraleSystem;
    public DayTracker DayTracker { get { return _dayTracker; } private set { } }
    public MoraleSystem MoraleSystem { get { return _moraleSystem; } private set { } }


    /// <summary>
    /// Implement the game manager as a singleton.
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

        _SOCharacters = new List<SOCharacter>(Resources.LoadAll<SOCharacter>("Characters"));
        _SORoles = new List<SORole>(Resources.LoadAll<SORole>("Roles"));
        CreateCharactersList();
        ShuffleCharacterList();
        AssignRoles();

        _dayTracker = this.gameObject.GetComponent<DayTracker>();
        _moraleSystem = this.gameObject.GetComponent<MoraleSystem>();
    }

    /*
    /// <summary>
    /// Load all roles and character scriptable objects then randomly assign roles.
    /// Then initialize variables.
    /// </summary>
    void Start()
    {
        _SOCharacters = new List<SOCharacter>(Resources.LoadAll<SOCharacter>("Characters"));
        _SORoles = new List<SORole>(Resources.LoadAll<SORole>("Roles"));
        CreateCharactersList();
        ShuffleCharacterList();
        AssignRoles();

        _dayTracker = this.gameObject.GetComponent<DayTracker>();
        _moraleSystem = this.gameObject.GetComponent<MoraleSystem>();
    }
    */


    /// <summary>
    /// Returns a list of scriptable object, by default all will be returned but a type can be
    /// specified instead.
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Returns a list of scriptable object roles.</returns>
    public List<SORole> GetSORoles(SORole.RoleType type = SORole.RoleType.NONE)
    {
        if (type == SORole.RoleType.NONE)
        {
            return _SORoles;
        }

        List<SORole> roles = new List<SORole>();
        foreach (SORole role in _SORoles)
        {
            if (role.Type == type)
            {
                roles.Add(role);
            }
        }

        return roles;
    }


    /// <summary>
    /// Creates the characters list and initializes each character from it's scriptable object.
    /// </summary>
    private void CreateCharactersList()
    {
        _characters = new List<Character>();
        for (int i = 0; i < _SOCharacters.Count; i++)
        {
            Character character = new Character(_SOCharacters[i]);
            _characters.Add(character);
        }
    }


    /// <summary>
    /// Randomly shuffles characters list using a Fisher-Yates algorithm.
    /// </summary>
    private void ShuffleCharacterList()
    {
        for (int i = _characters.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Character temp = _characters[i];
            _characters[i] = _characters[j];
            _characters[j] = temp;
        }
    }


    /// <summary>
    /// Assigns a role to each character. Assumes each role scriptable object was given a unique
    /// role index. Roles are assigned in order of execution.
    /// </summary>
    private void AssignRoles()
    {
        for (int i = 0; i < _SORoles.Count; i++)
        {
            int index = _SORoles[i].Index;
            _characters[index].AssignRole(_SORoles[index]);
        }
    }
}
