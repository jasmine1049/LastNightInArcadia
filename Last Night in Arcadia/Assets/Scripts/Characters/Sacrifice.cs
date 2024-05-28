using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : Character
{
    private int _numberDaysBoonLasts;
    private int _numberExtraCommandsOnDeath;
    private int _numberVictimsToProtect;

    private int _dayOfExecution;


    public int NumberDaysBoonLasts { get { return _numberDaysBoonLasts; } private set { } }
    public int NumberExtraCommandsOnDeath { get { return _numberExtraCommandsOnDeath; } private set { } }
    public int NumberVictimsToProtect { get { return _numberVictimsToProtect; } private set { } }


    public Sacrifice(SOPerson person, SORole role, int index) : base(person, role, index)
    {
        _numberDaysBoonLasts = 1;
        _numberExtraCommandsOnDeath = 1;
        _numberVictimsToProtect = 1;
    }


    protected override void MainAction()
    {
        // This assumes that if you're being targeted by the exectuioner, you WILL die that day. No matter what :p
        if (base._targeter is Executioner)
        {
            _dayOfExecution = GameManager.Instance.GetComponent<DayTracker>().NumberOfDaysPassed;
        }
    }


    public bool IsBoonActive()
    {
        int numberDaysPassed = GameManager.Instance.GetComponent<DayTracker>().NumberOfDaysPassed;

        bool isKillerExecutioner = _killer is Executioner;
        bool withinExecutionTimeFrame = (numberDaysPassed - _dayOfExecution) < _numberDaysBoonLasts;

        return isKillerExecutioner && withinExecutionTimeFrame;
    }
}
