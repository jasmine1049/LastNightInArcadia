using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressDayScreen : MonoBehaviour, IPointerClickHandler
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _day;
    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private TextMeshProUGUI _morale;

    [Header("Morale Text Breakpoints")]
    [Tooltip("List from highest to lowest.")]
    [SerializeField] private int[] _breakPoints;
    [Tooltip("List from highest to lowest.")]
    [SerializeField] private string[] _breakPointTexts;

    [Header("Next Page")]
    [Tooltip("UI Page to be activated right after this one.")]
    [SerializeField] private GameObject _nextUIPage;

    private DayTracker _dayTracker;


    /// <summary>
    /// Initializes text.
    /// </summary>
    void Start()
    {
        UpdateText();
    }


    /// <summary>
    /// Disables the ProgressDay screen on mouse click and activates the next page.
    /// </summary>
    /// <param name="_">Event payload associated with pointer (mouse / touch) events.</param>
    public void OnPointerClick(PointerEventData _)
    {
        this.gameObject.SetActive(false);
        _nextUIPage.SetActive(true);
    }


    /// <summary>
    /// Updates all UI text.
    /// </summary>
    public void UpdateText()
    {
        _dayTracker = GameManager.Instance.GetComponent<DayTracker>();

        _day.text = FormatDayText();
        _date.text = FormatDateText();
        _morale.text = FormatMoraleText();
    }


    /// <summary>
    /// Formats the day string in the following format "{Friday} {Evening}" and return it.
    /// </summary>
    /// <returns>A string of the day in the format "{Friday} {Evening}."</returns>
    private string FormatDayText()
    {
        string dayOfWeek = _dayTracker.GetDayOfTheWeek();
        string timeOfDay = _dayTracker.GetTimeOfDay();

        return String.Format("{0} {1}", dayOfWeek, timeOfDay);
    }


    /// <summary>
    /// Formats the date text in the following format "{1st} of {January}, {1982}." and return it.
    /// </summary>
    /// <returns>A string of the date in the format "{1st} of {January}, {1982}."</returns>
    private string FormatDateText()
    {
        (int Day, string MonthName, int Year) date = _dayTracker.GetDate();

        string daySuffix = GetDaySuffix(date.Day);

        return string.Format("{0}{1} of {2}, {3}.", date.Day, daySuffix, date.MonthName, date.Year);
    }


    /// <summary>
    /// Returns the suffix for a given day (i.e. the 'st' in 1st). 
    /// </summary>
    /// <param name="day">Integer representing a day in a month (1 - 31).</param>
    /// <returns>A string of the suffix based off the given day.</returns>
    private string GetDaySuffix(int day)
    {
        if (day == 1 || day == 21 || day == 31)
        {
            return "st";
        }
        else if (day == 2 || day == 22)
        {
            return "nd";
        }
        else if (day == 3 || day == 23)
        {
            return "rd";
        }

        return "th";
    }


    /// <summary>
    /// Formats the morale text in the following format "Morale: {Excellent}." and return it.
    /// </summary>
    /// <returns>A string of the morale text in the format "Morale: {Excellent}.</returns>
    private string FormatMoraleText()
    {
        return String.Format("Morale: {0}", GetCurrentMoraleText());
    }


    /// <summary>
    /// Returns the correct string to represent the current morale.
    /// </summary>
    /// <returns>A string representing the morale status.</returns>
    private string GetCurrentMoraleText()
    {
        int currentMorale = GameManager.Instance.GetComponent<MoraleManager>().CurrentMorale;
        int numBreakPoints = _breakPoints.Length;

        if (numBreakPoints == 0)
        {
            return _breakPointTexts[0];
        }
        else if (numBreakPoints == 1)
        {
            int i = currentMorale <= _breakPoints[0] ? 1 : 0;
            return _breakPointTexts[i];
        }

        for (int i = 0; i < numBreakPoints - 1; i++)
        {
            int upperBreakPoint = _breakPoints[i];
            int lowerBreakPoint = _breakPoints[i + 1];

            if (lowerBreakPoint < currentMorale && currentMorale <= upperBreakPoint)
            {
                return _breakPointTexts[i];
            }
        }

        return _breakPointTexts[numBreakPoints - 1];
    }
}
