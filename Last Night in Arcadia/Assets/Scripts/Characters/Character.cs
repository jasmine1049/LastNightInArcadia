using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    protected int _index;
    protected bool _isAlive;
    protected bool _isRoleRevealed;
    protected Character _target;
    protected Character _targeter;
    protected Character _killer;

    protected SOPerson _person;
    protected SORole _role;


    // Public getters for Character
    public int Index { get { return _index; } private set { } }
    public bool IsAlive { get { return _isAlive; } private set { } }
    public bool IsRoleRevealed { get { return _isRoleRevealed; } private set { } }
    public Character Target { get { return _target; } private set { } }
    public Character Targeter { get { return _targeter; } private set { } }
    public Character Killer { get { return _killer; } private set { } }

    // Public getters from Person
    public string Name { get { return _person.Name; } private set { } }
    public Sprite Portrait { get { return _person.Portrait; } private set { } }

    // Public getters from Role
    public string RoleName { get { return _role.Name; } private set { } }
    public string RoleDescription { get { return _role.Description; } private set { } }
    public Sprite RoleIcon { get { return _role.Icon; } private set { } }
    public int RoleIndex { get { return _role.Index; } private set { } }
    public bool IsAllied { get { return _role.IsAllied; } private set { } }
    public bool IsHostile { get { return _role.IsHostile; } private set { } }


    /// <summary>
    /// Initializes the character base class from the given scriptable object.
    /// </summary>
    /// <param name="person">Random and unique person scriptable object.</param>
    /// <param name="role">Random and unique role scriptable object.</param>
    /// <param name="index">Index of this Character in the character's array.</param>
    public Character(SOPerson person, SORole role, int index)
    {
        _person = person;
        _role = role;
        _index = index;

        _isAlive = true;
    }


    public void Kill()
    {
        if (_guard != null)
        {
            _isAlive = false;
        }
        else
        {
            // implement guard behavoir and call functionality here
        }
    }


    /// <summary>
    /// Sets the character's target.
    /// </summary>
    /// <param name="target">Target character that this character will perform their action on.</param>
    public void SetTarget(Character target)
    {
        _target = target;
    }


    /// <summary>
    /// Sets the character's targeter.
    /// </summary>
    /// <param name="targeter">Character who is targeting this character.</param>
    public void SetTargeter(Character targeter)
    {
        _targeter = targeter;
    }


    public void ClearTarget()
    {
        _target = null;
        _targeter = null;
    }


    /// <summary>
    /// Kills the character.
    /// </summary>
    public virtual void Kill(Character killer)
    {
        _isAlive = false;
        _isRoleRevealed = true;
        _killer = killer;
    }


    /// <summary>
    /// Base method to be overwritten by each character class.
    /// </summary>
    public virtual void TakeAction()
    {
        Target = null;
        IsBlocked = false;
    }
}
