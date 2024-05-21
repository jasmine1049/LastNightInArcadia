using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Henchman : Character
{

    public Henchman(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    /*public override void TakeAction()
    {
        
    }*/

    protected override void PostAction()
    {
        if (IsUsable())
        {
            Character[] chars = GameManager.Instance.GetCharacters();
            //Character[] targets = GameManager.Instance.GetCharacters(!IsHostile && IsAlive);
            System.Random random = new System.Random();
            int char_num = chars.Length;
            int index = random.Next(0, char_num - 1);
            Character target = chars[index];

            while (target.IsHostile || !target.IsAlive) {
                index = random.Next(0, char_num - 1);
                target = chars[index];
            }

            //GameManager.Instance.Shuffle<Character>(targets);
            //Character target = chars[0];
            DayTracker thing = GameManager.Instance.GetComponent<DayTracker>();
            if (target != null && (String.Equals(thing.GetTimeOfDay(), "Evening"/*DayTracker.TimesOfDay.Evening*/))) {
                target.Kill(this);
            } else {
                ;
            }
        }
    }
}
