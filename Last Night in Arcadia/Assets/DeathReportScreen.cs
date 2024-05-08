using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeathReportScreen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _nextUIPage;


    private int _numberDeathsToReport;


    void Start()
    {
        // This is currently hard-coded, but I'm thinking I can call a GameManager.Instance.GetNightDeath()
        // or something like that? Basically an array of characters of the people who mcdied, then I can use
        // that info to update the death reports
        _numberDeathsToReport = 1;
        UpdateText();
    }


    public void OnPointerClick(PointerEventData _)
    {
        _numberDeathsToReport--;
        print(_numberDeathsToReport);

        if (_numberDeathsToReport <= 0)
        {
            this.gameObject.SetActive(false);
            _nextUIPage.SetActive(true);
        }
        else
        {
            UpdateText();
        }
    }


    private void UpdateText()
    {
        // This is where I would iterate over all the dead people and make a report for them.
        // I need serialized fields for the icon and text description(s)
    }
}
