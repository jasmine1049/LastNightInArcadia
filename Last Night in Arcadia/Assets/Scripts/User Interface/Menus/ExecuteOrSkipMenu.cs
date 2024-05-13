using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExecuteOrSkipMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _day;


    void Start()
    {
        _day.text = FormatDayText();
    }


    private string FormatDayText()
    {
        DayTracker dayTracker = GameManager.Instance.GetComponent<DayTracker>();

        string dayOfWeek = dayTracker.GetDayOfTheWeek();
        string timeOfDay = dayTracker.GetTimeOfDay();

        return String.Format("{0} {1}", dayOfWeek, timeOfDay);
    }
}
