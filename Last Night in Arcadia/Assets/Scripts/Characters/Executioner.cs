using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Character
{
    public Executioner(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    public override void TakeAction()
    {
        if (_target != null)
        {
            _target.Kill(this);
            base.TakeAction();
        }
    }
}
