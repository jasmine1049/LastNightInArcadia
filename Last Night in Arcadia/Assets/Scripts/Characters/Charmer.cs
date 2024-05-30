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

        if (_target == null && dayTracker.GetTimeOfDayEnum() == DayTracker.TimesOfDay.Evening)
        {
            VisitRandomInactive();
        }
    }


    private void VisitRandomInactive()
    {
        Character[] characters = GameManager.Instance.GetCharacters(c => c.IsAlive && c.Target == null && c.Targeter == null && c != this);

        if (characters.Length > 0)
        {
            int randomIndex = Random.Range(0, characters.Length);

            characters[randomIndex].IncreaseMorale(_moraleIncreaseOnSuccessfulVisit);
        }
    }
}
