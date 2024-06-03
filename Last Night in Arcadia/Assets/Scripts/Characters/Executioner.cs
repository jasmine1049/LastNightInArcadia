using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Character
{
    public override string Name { get { return "Execution"; }
    public override string RoleName { get { return "Execution"; }
    }

    public Executioner(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    protected override void MainAction()
    {
        if (_target != null)
        {
            bool targetIsMadmanOrSacrifice = (_target is Madman) || (_target is Sacrifice);

            if (targetIsMadmanOrSacrifice)
            {
                _target.TakeAction();
            }

            _target.Kill(this);
        }
    }
}
