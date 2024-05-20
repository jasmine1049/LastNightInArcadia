using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodyguard : Character
{
    private int injuryClock;
    public Bodyguard(SOPerson person, SORole role, int index) : base(person, role, index)
    {
        injuryClock = 5;
    }

    public override void TakeAction()
    {
        if (Target == this)
        {
            Reveal();
        }
        if (Target != null)
        {
            Target.SetGuard(this);
        }
        injuryClock--;
        base.TakeAction();
    }

    public override bool IsUsable()
    {
        return base.IsUsable() && injuryClock <= 0;
    }

    public void Injure()
    {
        injuryClock = 2;
    }
}
