using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bodyguard : Character
{
    private int injuryClock;
    public Bodyguard(SOPerson person, SORole role, int index) : base(person, role, index)
    {
        injuryClock = 0;
    }

    protected override void MainAction()
    {
        if (IsUsable())
        {
            if (Target == this)
            {
                Reveal();
            }
            if (Target != null)
            {
                Target.SetGuard(this);
            }
        }
        if (GameManager.Instance.GetTimeOfDay() == DayTracker.TimesOfDay.Night)
        {
            injuryClock--;
        }
    }

    public override bool IsUsable()
    {
        return base.IsUsable() && injuryClock <= 0;
    }

    public void Injure()
    {
        if (Target != null) {
            GameManager.ReportManager.AddItem(
                GameManager.Instance.GetDaysFromZero(),
                GameManager.Instance.GetTimeOfDay(),
                $"The bodyguard, {Name}, was injured while protecting {Target.Name}."
                );
        Reveal();
        injuryClock = 2;
        }
    }
}
