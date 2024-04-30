using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpdateProgressDayUI : MonoBehaviour, IPointerClickHandler
{
    enum TimesOfDay
    {
        Evening,
        Night,
        Afternoon
    }

    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite _backgroundArt;

    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private int _startingDay;
    [SerializeField] private int _startingMonth;
    [SerializeField] private int _startingYear;
    private DateTime _currentDate;

    [SerializeField] private TextMeshProUGUI _dayOfTheWeek;

    [SerializeField] private TextMeshProUGUI _timeOfDay;
    private TimesOfDay _currentTimeOfDay = TimesOfDay.Evening;

    [SerializeField] private TextMeshProUGUI _currentMorale;


    /// <summary>
    /// Initializes background art image, date, and all UI text elements to their starting values.
    /// </summary>
    void Start()
    {
        _backgroundImage.sprite = _backgroundArt;
        _backgroundImage.color = Color.white;

        _currentDate = new DateTime(_startingYear, _startingMonth, _startingDay);
        UpdateText(true);
    }


    /// <summary>
    /// Disables the ProgressDay screen on mouse click.
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
    }


    /// <summary>
    /// Updates all UI text.
    /// </summary>
    public void UpdateText(bool initialization = false)
    {
        if (!initialization && _currentTimeOfDay == TimesOfDay.Afternoon)
        {
            AdvanceOneDay();
        }

        UpdateDate();
        UpdateDayOfTheWeek();
        UpdateTimeOfDay();
    }


    /// <summary>
    /// Advances the date by one day.
    /// </summary>
    private void AdvanceOneDay()
    {
        _currentDate = _currentDate.AddDays(1);
    }


    /// <summary>
    /// Updates the date text.
    /// </summary>
    private void UpdateDate()
    {
        _date.text = FormatDate();
    }


    /// <summary>
    /// Correctly formats the current date in the following way "1st of January, 2002."
    /// </summary>
    /// <returns>A string of the date in the aforementioned format.</returns>
    private string FormatDate()
    {
        int day = _currentDate.Day;
        string daySuffix = GetDaySuffix(day);
        string monthName = _currentDate.ToString("MMMM");

        return string.Format("{0}{1} of {2}, {3}.", day, daySuffix, monthName, _currentDate.Year);
    }


    /// <summary>
    /// Returns the correct suffix for the given day.
    /// </summary>
    /// <param name="day"></param>
    /// <returns>A string of the suffix based off the day.</returns>
    private string GetDaySuffix(int day)
    {
        switch (day)
        {
            case 1:
            case 21:
            case 31:
                return "st";
            case 2:
            case 22:
                return "nd";
            case 3:
            case 23:
                return "rd";
            default:
                return "th";
        }
    }


    /// <summary>
    /// Updates the day of the week text.
    /// </summary>
        private void UpdateDayOfTheWeek()
    {
        _dayOfTheWeek.text = _currentDate.DayOfWeek.ToString();
    }


    /// <summary>
    /// Updates the time of day text by cycling through the TimesOfDay.
    /// </summary>
    private void UpdateTimeOfDay()
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

        _timeOfDay.text = _currentTimeOfDay.ToString();
    }
}
