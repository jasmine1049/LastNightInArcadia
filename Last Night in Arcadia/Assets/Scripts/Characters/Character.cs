using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    protected string _name;
    protected Sprite _portrait;
    protected SORole _role;
    protected bool _isAlive;

    public string Name { get { return _name; } private set { } }
    public Sprite Portrait { get { return _portrait; } private set { } } 
    public SORole Role { get { return _role; } private set { } }
    public bool IsAlive { get { return _isAlive; } private set { } }


    /// <summary>
    /// Constructor for a new character class.
    /// </summary>
    /// <param name="character"></param>
    public Character(SOCharacter character)
    {
        _name = character.Name;
        _portrait = character.Portrait;
    }


    /// <summary>
    /// Sets character's role.
    /// </summary>
    /// <param name="role"></param>
    public void AssignRole(SORole role)
    {
        _role = role;
    }


    /// <summary>
    /// Base method to be overwritten by each character class.
    /// </summary>
    public virtual void TakeAction()
    {
        return;
    }
}
