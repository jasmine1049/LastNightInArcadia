using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Henchman : Character
{

    public Henchman(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }

    protected override void MainAction()
    {
        if (IsUsable())
        {
            Character[] chars = GameManager.Instance.GetCharacters();
            System.Random random = new System.Random();
            int char_num = chars.Length;
            int index = random.Next(0, char_num - 1);
            Character target = chars[index];

            // choose target randomly
            while (target.IsHostile || !target.IsAlive) {
                index = random.Next(0, char_num - 1);
                target = chars[index];
            }

            // kill function
            DayTracker thing = GameManager.Instance.GetComponent<DayTracker>();
            // Yes it makes sense for it to be "Night" since it's the night phase. But the day tracker is weird, just trust that it's supposed to be "Evening" sob
            if (target != null && (String.Equals(thing.GetTimeOfDay(), "Evening"))) {
                target.Kill(this);
            } else {
                ;
            }
        }
    }
}
