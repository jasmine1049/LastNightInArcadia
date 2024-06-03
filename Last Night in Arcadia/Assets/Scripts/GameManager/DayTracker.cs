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


    [Header("Starting Date")]
    [SerializeField] private int _startingDay;
    [SerializeField] private int _startingMonth;
    [SerializeField] private int _startingYear;

    private DateTime _currentDate;
    private int _currentDaysFromZero;
    private TimesOfDay _currentTimeOfDay;
    private int _numberOfDaysPassed;


    public int NumberOfDaysPassed {  get { return _numberOfDaysPassed; } private set { } }


    /// <summary>
    /// Initializes the date and time of day. Done in Awake to ensure data from this class is
    /// always set if another class calls data from it in its Start.
    /// </summary>
    void Awake()
    {
        _currentDaysFromZero = 0;
        _currentDate = new DateTime(_startingYear, _startingMonth, _startingDay);
        _currentTimeOfDay = TimesOfDay.Evening;
        _numberOfDaysPassed = 0;
    }


    /// <summary>
    /// Progress time, moving the time of day and date if needed.
    /// </summary>
    public void ProgressTime()
    {
        AdvanceTimeOfDay();

        if (_currentTimeOfDay == TimesOfDay.Afternoon)
        {
            GameManager.Instance.ClearNightPhaseDeaths(); // Each new day the Night Phase Deaths array is reset.

            AdvanceOneDay();
        }
    }


    /// <summary>
    /// Returns the day of the week (Monday, Tuesday, etc) as a string.
    /// </summary>
    /// <returns></returns>
    public string GetDayOfTheWeek()
    {
        return _currentDate.DayOfWeek.ToString();
    }


    /// <summary>
    /// Returns the time of the day (Evening, Night, Afternoon) as a string.
    /// </summary>
    /// <returns></returns>
    public string GetTimeOfDay()
    {
        return _currentTimeOfDay.ToString();
    }


    /// <summary>
    /// Returns the time of the day as an enum.
    /// </summary>
    /// <returns></returns>
    public TimesOfDay GetTimeOfDayEnum()
    {
        return _currentTimeOfDay;
    }


    /// <summary>
    /// Returns a tuple of the current day in the format (29, May, 2024)
    /// </summary>
    /// <returns></returns>
    public (int Day, string MonthName, int Year) GetDate()
    {

        return (_currentDate.Day, _currentDate.ToString("MMMM"), _currentDate.Year);
    }

    public string GetDateString()
    {
        return _currentDate.ToString("d");
    }

    public (int Day, string MonthName, int Year) GetDate(int daysFromZero)
    {
        DateTime adjustedDays = (new DateTime(_startingYear, _startingMonth, _startingDay)).AddDays(daysFromZero);
        return (adjustedDays.Day, adjustedDays.ToString("MMMM"), adjustedDays.Year);
    }

    public int GetDaysFromZero()
    {
        return _currentDaysFromZero;
    }


    /// <summary>
    /// Advances the date by one day.
    /// </summary>
    private void AdvanceOneDay()
    {
        _currentDaysFromZero++;
        _currentDate = _currentDate.AddDays(1);
        _numberOfDaysPassed++;
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
