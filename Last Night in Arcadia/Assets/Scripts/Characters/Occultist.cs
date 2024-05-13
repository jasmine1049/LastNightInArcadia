using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occultist : Character
{
    public Occultist(SOCharacter character) : base(character)
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
