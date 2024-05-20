using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occultist : Character
{
    public Occultist(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    public override void TakeAction()
    {
        if (IsAlive && !IsBlocked)
        {
            if (Target == this)
            {
                Reveal();
            }
            else if (_target != null)
            {
                if (!Target.IsHostile && Target.Kill(this))
                {
                    Reveal();
                    this.Kill(this);
                }
            }
        }
        base.TakeAction();
    }
}
