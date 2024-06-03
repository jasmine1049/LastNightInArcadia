using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    protected int _index;
    protected bool _isAlive;
    protected bool _isRoleRevealed;
    protected bool _isBlocked;
    protected Character _target;
    protected Character _targeter;
    protected Character _killer;
    private Bodyguard _guard;

    protected SOPerson _person;
    protected SORole _role;


    // Public getters for Character
    public int Index { get { return _index; } private set { } }
    public bool IsAlive { get { return _isAlive; } private set { } }
    public bool IsRoleRevealed { get { return _isRoleRevealed; } private set { } }
    public bool IsBlocked { get { return _isBlocked; } private set { } }
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


    public virtual bool IsUsable()
    {
        return _isAlive && !_isBlocked;
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
    /// Sets the character's guard.
    /// </summary>
    /// <param name="guard">Guard for this character, or null</param>
    public void SetGuard(Bodyguard guard)
    {
        _guard = guard;
    }


    /// <summary>
    /// Sets the character's targeter.
    /// </summary>
    /// <param name="targeter">Character who is targeting this character.</param>
    public void SetTargeter(Character targeter)
    {
        _targeter = targeter;
    }


    private string GetMurderText(Character killer)
    {
        string nameAndRole = $"{this.Name}, the {this.RoleName} ";
        if (killer == this)
        {
            if (UnityEngine.Random.Range(0, 1) == 0)
            {
                return nameAndRole + "killed themself.";
            }
            else
            {
                return nameAndRole + "committed suicide.";
            }
        }
        else
        {
            int r = UnityEngine.Random.Range(0, 2);
            if (r == 0)
            {
                return nameAndRole + $"was murdered by the {killer.RoleName}.";
            }
            else if (r == 1)
            {
                return nameAndRole + $"died at the hands of the {killer.RoleName}.";
            }
            else
            {
                return nameAndRole + $"had their life ended by the {killer.RoleName}.";
            }
        }
    }


    /// <summary>
    /// Kills the character.
    /// </summary>
    public bool Kill(Character killer)
    {
        if (this is Marksman)
        {
            Debug.Log("I AM THE MARKSMAN " + RoleName);
        }
        if (_guard == null)
        {
            // Sacrifice will save character from death
            Sacrifice sacrifice = (Sacrifice)(GameManager.Instance.GetCharacters(c => c is Sacrifice)[0]);
            if (sacrifice.IsBoonActive() && sacrifice.CanSaveCharacter())
            {
                sacrifice.SaveCharacter();
                Debug.Log("Sacrifice saved " + Name);
                return false;
            }
            
            GameManager.ReportManager.AddItem(
                GameManager.Instance.GetDaysFromZero(), 
                GameManager.Instance.GetTimeOfDay(),
                GetMurderText(killer)
                );

            Debug.Log("KILLING ME " + Name);
            _isAlive = false;
            _isRoleRevealed = true;
            _killer = killer;

            DecreaseMorale();

            // If died during night phase, add it to night phase deaths.
            if (GameManager.Instance.GetTimeOfDay() == DayTracker.TimesOfDay.Evening)
            {
                GameManager.Instance.AddNightPhaseDeath(this);
            }

            return true;
        }
        else
        {
            _guard.Injure();
            _guard = null;
            return false;
            // implement guard behavoir and call functionality here
        }
    }


    public void Reveal()
    {
        _isRoleRevealed = true;
    }


    protected virtual void PreAction()
    {
        if (!(Target == this) && Target is Marksman && ((Marksman)Target).Target != null && Target.IsUsable())
        {
            ((Marksman)Target).DoKill(this);
        }
    }

    protected virtual void PostAction()
    {
        if (_target != null)
            Debug.Log("character " + RoleName + " (" + _person.Name + ") taking action on target " + Target._person.Name);
        _target = null;
        _isBlocked = false;
    }


    public virtual void TakeAction()
    {
        PreAction();
        MainAction();
        PostAction();
    }


    /// <summary>
    /// Base method to be overwritten by each character class.
    /// </summary>
    protected virtual void MainAction()
    {
        return;
    }


    private void DecreaseMorale()
    {
        MoraleManager moraleManager = GameManager.Instance.GetComponent<MoraleManager>();

        if (_killer is Executioner)
        {
            moraleManager.DecreaseMorale(_role.MoraleLossOnExecution);
        }
        else
        {
            moraleManager.DecreaseMorale(_role.MoraleLossOnDeath);
        }
    }


    public void IncreaseMorale(int amount)
    {
        MoraleManager moraleManager = GameManager.Instance.GetComponent<MoraleManager>();

        moraleManager.IncreaseMorale(amount);
    }
}
