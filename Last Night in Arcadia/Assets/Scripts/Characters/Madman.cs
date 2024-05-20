using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madman : Character
{
    private float _moraleBreakpoint = 40f;
    private MoraleManager _moraleManger;


    public Madman(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    protected override void MainAction()
    {
        DayTracker dayTracker = GameManager.Instance.GetComponent<DayTracker>();

        if (_target == null && dayTracker.GetTimeOfDayEnum() == DayTracker.TimesOfDay.Evening)
        {
            CheckRandomKillChance();
        }
        else if (_target != null)
        {
            _target.Kill(this);
        }
        else if (_targeter is Executioner)
        {
            KillRandomCharacter();
        }
    }


    private void CheckRandomKillChance()
    {
        _moraleManger = GameManager.Instance.GetComponent<MoraleManager>();

        bool breakpointReached = _moraleManger.CurrentMorale <= _moraleBreakpoint;
        bool exceededChanceToKill = Random.Range(0, 100) < ChanceToKill();

        if (breakpointReached && exceededChanceToKill)
        {
            KillRandomCharacter();
        }
    }


    private float ChanceToKill()
    {
        // This assumes that the morale breakpoint is always less than or equal to the current morale.
        // If this assumption is not true, this will not work.
        return (1 - ((float)_moraleManger.CurrentMorale / _moraleBreakpoint)) * 100f;
    }


    private void KillRandomCharacter()
    {
        Character[] characters = GameManager.Instance.GetCharacters(character => character.IsAlive && character is not Overseer && character != this);

        // Is it possible for characters.Length to ever be 0? If so this would return an error, but surely that won't happen me thinks...
        int randomIndex = Random.Range(0, characters.Length);

        GameManager.Instance.SetTarget(this, characters[randomIndex]);

        MainAction();
    }
}
