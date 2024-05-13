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
                return;
            }
            else
            {
                Target.Kill();
                if (!Target.IsHostile)
                {
                    this.Kill();
                }
            }
        }
        base.TakeAction();
    }
}
