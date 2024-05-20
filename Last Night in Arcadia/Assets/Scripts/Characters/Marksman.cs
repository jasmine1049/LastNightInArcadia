using System.Collections;
using System.Collections.Generic;
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

    public void DoKill()
    {
        uses--;
        if (uses <= 0)
        {
            deactivated = true;
        }
    }
}
