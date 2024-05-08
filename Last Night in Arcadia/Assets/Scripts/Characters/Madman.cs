using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madman : Character
{
    private int _moraleBreakpoint;


    public Madman(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    public override void TakeAction()
    {
        if (_moraleBreakpoint <= GameManager.Instance.GetComponent<MoraleManager>().CurrentMorale)
        {
            //
        }
    }
}
