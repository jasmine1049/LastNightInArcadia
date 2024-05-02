using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressDayUI : MonoBehaviour, IPointerClickHandler
{
    [Header("Background Art")]
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite _backgroundArt;

    [Header("Text Boxes")]
    [SerializeField] private TextMeshProUGUI _dateTextBox;
    [SerializeField] private TextMeshProUGUI _dayOfTheWeekTextBox;
    [SerializeField] private TextMeshProUGUI _timeOfDayTextBox;
    [SerializeField] private TextMeshProUGUI _currentMorale;

    [Header("Next UI Page")]
    [SerializeField] private GameObject _nextUIPage;

    private GameManager _gameManager;
    private DateTime _date;
    private DayTracker.TimesOfDay _timeOfDay;


    /// <summary>
    /// Initializes background art image and gets current date and time of day.
    /// </summary>
    void Start()
    {
        _backgroundImage.sprite = _backgroundArt;

        _gameManager = GameManager.Instance;
        _date = _gameManager.DayTracker.Date;
        _timeOfDay = _gameManager.DayTracker.TimeOfDay;

        UpdateText();
    }


    /// <summary>
    /// Disables the ProgressDay screen on mouse click.
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        _nextUIPage.SetActive(true);
    }


    /// <summary>
    /// Updates all UI text.
    /// </summary>
    public void UpdateText()
    {
        _dateTextBox.text = FormatDate();
        _dayOfTheWeekTextBox.text = _date.DayOfWeek.ToString();
        _timeOfDayTextBox.text = _timeOfDay.ToString();
        _currentMorale.text = CalculateMoraleText();
    }


    /// <summary>
    /// Correctly formats the current date in the following way "1st of January, 2002."
    /// </summary>
    /// <returns>A string of the date in the aforementioned format.</returns>
    private string FormatDate()
    {
        int day = _date.Day;
        string daySuffix = GetDaySuffix(day);
        string monthName = _date.ToString("MMMM");

        return string.Format("{0}{1} of {2}, {3}.", day, daySuffix, monthName, _date.Year);
    }


    /// <summary>
    /// Returns the correct suffix for a given day.
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
    /// Calculates the correct string to represent the morale status, dependent on the current morale.
    /// </summary>
    /// <returns>A string representing the morale status.</returns>
    private string CalculateMoraleText()
    {
        int morale = _gameManager.MoraleSystem.CurrentMorale;

        if (morale <= 100 && morale > 90)
        {
            return "Very Happy :)";
        }
        else if (morale <= 90 && morale > 80)
        {
            return "Vibey";
        }
        else if (morale <= 80 && morale > 70)
        {
            return "feeling ight";
        }
        else if (morale <= 70 && morale > 60)
        {
            return "ok...";
        }
        else if (morale <= 60 && morale > 50)
        {
            return "no happy >:(";
        }
        else if (morale <= 50 && morale > 30)
        {
            return "Dire";
        }
        else if (morale <= 30 && morale > 10)
        {
            return "It's joever";
        }
        else if (morale <= 10)
        {
            return "NIGHTMARE";
        }
        else
        {
            return "";
        }
    }
}
