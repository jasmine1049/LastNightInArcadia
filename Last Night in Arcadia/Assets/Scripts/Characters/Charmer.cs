using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmer : Character
{
    private int _moraleIncreaseOnSuccesfulVisit;


    public Charmer(SOPerson person, SORole role, int index) : base(person, role, index)
    {
        _moraleIncreaseOnSuccesfulVisit = 5;
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

        int randomIndex = Random.Range(0, characters.Length);

        // needs to make the number negative, cause to increase morale we need to decrease the morale... negatively...
        characters[randomIndex].IncreaseMorale(_moraleIncreaseOnSuccesfulVisit);
    }
}
