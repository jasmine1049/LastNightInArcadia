using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Overseer : Character
{
    public Overseer(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }

    protected override void MainAction()
    {
        // function to check if the henchman is dead
        Character[] hm_check = GameManager.Instance.GetCharacters(c => c.RoleName == "Henchman");
        Character hench = hm_check[0];

        if (IsUsable() && !hench.IsAlive)
        { 
            Character[] chars = GameManager.Instance.GetCharacters();
            System.Random random = new System.Random();
            int char_num = chars.Length;
            int index = random.Next(0, char_num - 1);
            Character target = chars[index];

            // this function essentially doubles the chance for allied roles to be targeted over neutral roles
            Character[] pool = new Character[25];
            for (int i = 0; i < chars.Length; i++) {
                pool[i] = chars[i];
            }
            int j = 16;
            for (int i = 0; i < chars.Length; i++) {
                if (chars[i].IsAllied) {
                    pool[j] = chars[i];
                    j++;
                }
            }

            // choose target randomly
            while (target.IsHostile || !target.IsAlive) {
                index = random.Next(0, char_num - 1);
                target = pool[index];
            }

            // kill function
            DayTracker thing = GameManager.Instance.GetComponent<DayTracker>();
            if (target != null && (String.Equals(thing.GetTimeOfDay(), "Night"))) {
                target.Kill(this);
            } else {
                ;
            }
        }
    }
}
