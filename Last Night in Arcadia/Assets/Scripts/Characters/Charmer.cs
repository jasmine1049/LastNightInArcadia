using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmer : Character
{
    private int _moraleIncreaseOnSuccesfulVisit;

    public Charmer(SOPerson person, SORole role, int index) : base(person, role, index)
    {

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
        Character[] characters = GameManager.Instance.GetCharacters(character => character.IsAlive && character != this);

        int randomIndex = Random.Range(0, characters.Length);

        if (characters[randomIndex].IsUsable())
        {

        }

    }
}
