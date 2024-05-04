using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private string _name;
    private Sprite _portrait;
    private SORole _role;
    private bool _isRoleRevealed;
    private bool _isAlive;
    private Character _target;
    private Character _targeter;
    private Character _killer;

    // variables from _role
    public int Index { get { return _role.Index; } private set { } }
    public Sprite RoleIcon { get { return _role.Icon; } private set { } }
    public string RoleName { get { return _role.Name; } private set { } }
    public string RoleDescription { get { return _role.Description; } private set { } }
    public bool IsAllied { get { return _role.IsAllied; } private set { } }

    // variables from Character
    public string Name { get { return _name; } private set { } }
    public Sprite Portrait { get { return _portrait; } private set { } } 
    public bool IsRoleRevealed { get { return _isRoleRevealed; } private set { } }
    public bool IsAlive { get { return _isAlive; } private set { } }
    public Character Target { get { return _target; } private set { } }
    public Character Targeter { get { return _targeter; } private set { } }
    public Character Killer { get { return _killer; } private set { } }


    /// <summary>
    /// Constructor for a new character class.
    /// </summary>
    /// <param name="character"></param>
    public Character(SOCharacter character)
    {
        _name = character.Name;
        _portrait = character.Portrait;
        _isRoleRevealed = false;
        _isAlive = true;
    }


    /// <summary>
    /// Sets character's role.
    /// </summary>
    /// <param name="role"></param>
    public void AssignRole(SORole role)
    {
        _role = role;
    }


    public void SetTarget(Character target)
    {
        _target = target;
    }


    public void SetTargeter(Character targeter)
    {
        _targeter = targeter;
    }


    /// <summary>
    /// Base method to be overwritten by each character class.
    /// </summary>
    /// After TakeAction is done, the target should be cleared!!!
    public virtual void TakeAction()
    {
        return;
    }
}
