using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    public enum TimesOfDay
    {
        Evening,
        Night,
        Afternoon
    }


    [Header("Date")]
    [SerializeField] private int _startingDay;
    [SerializeField] private int _startingMonth;
    [SerializeField] private int _startingYear;
    private DateTime _currentDate;
    private TimesOfDay _currentTimeOfDay;


    public DateTime Date { get { return _currentDate; } set { } }
    public TimesOfDay TimeOfDay { get { return _currentTimeOfDay; } set { } }


    /// <summary>
    /// Initializes the date and time of day.
    /// </summary>
    void Start()
    {
        _currentDate = new DateTime(_startingYear, _startingMonth, _startingDay);
        _currentTimeOfDay = TimesOfDay.Evening;
    }


    /// <summary>
    /// Progress time, moving the time of day and date if needed.
    /// </summary>
    public void ProgressTime()
    {
        AdvanceTimeOfDay();

        if (_currentTimeOfDay == TimesOfDay.Afternoon)
        {
            AdvanceOneDay();
        }
    }


    /// <summary>
    /// Advances the date by one day.
    /// </summary>
    private void AdvanceOneDay()
    {
        _currentDate = _currentDate.AddDays(1);
    }


    /// <summary>
    /// Advance the time of day by cycling through the TimesOfDay enum.
    /// </summary>
    private void AdvanceTimeOfDay()
    {
        switch (_currentTimeOfDay)
        {
            case TimesOfDay.Evening:
                _currentTimeOfDay = TimesOfDay.Night;
                break;
            case TimesOfDay.Night:
                _currentTimeOfDay = TimesOfDay.Afternoon;
                break;
            case TimesOfDay.Afternoon:
                _currentTimeOfDay = TimesOfDay.Evening;
                break;
        }
    }
}
