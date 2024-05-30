using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmer : Character
{
    private int _moraleIncreaseOnSuccessfulVisit;


    public Charmer(SOPerson person, SORole role, int index) : base(person, role, index)
    {
        _moraleIncreaseOnSuccessfulVisit = 5;
    }


    protected override void MainAction()
    {
        DayTracker dayTracker = GameManager.Instance.GetComponent<DayTracker>();

        if (_target == null && dayTracker.GetTimeOfDayEnum() == DayTracker.TimesOfDay.Evening && !_isBlocked)
        {
            VisitRandomInactive();
        }
    }


    private void VisitRandomInactive()
    {
        Character[] characters = GameManager.Instance.GetCharacters(c => c.IsAlive && c.Target == null && c.Targeter == null && c != this);

        // There's random inactives to "visit"
        if (characters.Length > 0)
        {
            // I don't think we need to check if a random person in the list is killed or not roleblocked?
            // int randomIndex = Random.Range(0, characters.Length);

            IncreaseMorale(_moraleIncreaseOnSuccessfulVisit);
        }
    }
}
