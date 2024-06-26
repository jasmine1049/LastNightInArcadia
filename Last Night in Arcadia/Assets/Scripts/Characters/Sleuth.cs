using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleuth : Character
{
    public Sleuth(SOPerson person, SORole role, int index) : base(person, role, index)
    {

    }


    // Currently it just debug logs it, but it the future I imagine we will just take the same
    // string, and send it to the in-game daily log system
    protected override void MainAction()
    {
        if (IsUsable())
        {
            if (Target == this)
            {
                Reveal();
                GameManager.ReportManager.AddItem(
                    GameManager.Instance.GetDaysFromZero(),
                    GameManager.Instance.GetTimeOfDay(),
                    $"The Sleuth, {Name}, sleuthed themself."
                );
            }
            else if (Target != null)
            {
                if (Target is Overseer || Target is Occultist || Target is Madman)
                {
                    Debug.Log("The slueth visited either the overseer, occultist, or the madman.");
                    GameManager.ReportManager.AddItem(
                        GameManager.Instance.GetDaysFromZero(),
                        GameManager.Instance.GetTimeOfDay(),
                        $"The slueth visited either the overseer, occultist, or the madman."
                    );
                }
                else if (Target is Henchman || Target is Marksman || Target is Bodyguard)
                {
                    Debug.Log("The slueth visited either the henchman, the marksman, or the bodyguard.");
                    GameManager.ReportManager.AddItem(
                        GameManager.Instance.GetDaysFromZero(),
                        GameManager.Instance.GetTimeOfDay(),
                        $"The slueth visited either the henchman, the marksman, or the bodyguard."
                    );
                }
                // should also include saboteur in the future
                else if (Target is Trickster || Target is Charmer)
                {
                    Debug.Log("The slueth visited either the trickster, the charmer, or the SABOTEUR (not implemented, so they didnt visit).");
                    GameManager.ReportManager.AddItem(
                        GameManager.Instance.GetDaysFromZero(),
                        GameManager.Instance.GetTimeOfDay(),
                        $"The slueth visited either the trickster, the charmer, or the SABOTEUR (not implemented, so they didnt visit)."
                    );
                }
                else if (Target is Ghoul || Target is Spy || Target is Coroner)
                {
                    Debug.Log("The slueth visited either the ghoul, the spy, or the coroner.");
                    GameManager.ReportManager.AddItem(
                        GameManager.Instance.GetDaysFromZero(),
                        GameManager.Instance.GetTimeOfDay(),
                        $"The slueth visited either the ghoul, the spy, or the coroner."
                    );
                }
                //will include roles 8 and 9
                else if (Target is Sacrifice)
                {
                    Debug.Log("The slueth visited either the sacrifice, the ALLY ROLE 8 (not implemented, so they didnt visit), or the ALLY ROLE 9 (not implemented, so they didnt visit).");
                    GameManager.ReportManager.AddItem(
                        GameManager.Instance.GetDaysFromZero(),
                        GameManager.Instance.GetTimeOfDay(),
                        $"The slueth visited either the sacrifice, the ALLY ROLE 8 (not implemented, so they didnt visit), or the ALLY ROLE 9 (not implemented, so they didnt visit)."
                    );
                }
                else
                {
                    Debug.Log("The slueth visited someone who lacks purpose and meaning in life (probably ally role 7, 8, or 9.");
                    GameManager.ReportManager.AddItem(
                        GameManager.Instance.GetDaysFromZero(),
                        GameManager.Instance.GetTimeOfDay(),
                        $"The slueth visited someone who lacks purpose and meaning in life (probably ally role 7, 8, or 9."
                    );
                }
            }
        }
    }
}
