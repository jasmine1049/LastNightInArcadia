using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Character
{
    public Executioner(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    protected override void MainAction()
    {
        if (_target != null)
        {
            if (_target is Madman)
            {
                _target.TakeAction();
            }

            _target.Kill(this);
        }
    }
}
