using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Marksman : Character
{

    private bool deactivated;
    private int uses;

    public Marksman(SOPerson person, SORole role, int index) : base(person, role, index)
    {
        deactivated = false;
        uses = 3;
    }

    public override bool IsUsable()
    {
        return base.IsUsable() && !deactivated;
    }

    // Marksman must go dead last to ensure this check is done after all others may have interacted
    protected override void MainAction()
    {
        if (Target != null)
        {
            uses--;
        }
        if (uses <= 0)
        {
            deactivated = true;
        }
    }

    public void DoKill(Character target)
    {
        if (target.IsHostile)
        {
            deactivated = true;
            Reveal();
            if (!(target is Overseer))
            {
                target.Kill(this);
            }
        }
        else
        {
            target.Kill(this);
        }
    }
}
