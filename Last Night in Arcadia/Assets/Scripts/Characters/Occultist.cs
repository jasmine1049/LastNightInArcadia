using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occultist : Character
{
    public Occultist(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }

    protected override void MainAction()
    {
        if (IsUsable())
        {
            if (Target == this)
            {
                GameManager.ReportManager.AddItem(
                GameManager.Instance.GetDaysFromZero(),
                GameManager.Instance.GetTimeOfDay(),
                $"The occultist, {Name}, was assigned to visit themself."
                );
                Reveal();
            }
            else if (_target != null)
            {
                Debug.Log("OCCULTIST KILLING");
                if (!Target.IsHostile && Target.Kill(this))
                {
                    Reveal();
                    this.Kill(this);
                }
            }
        }
    }
}
