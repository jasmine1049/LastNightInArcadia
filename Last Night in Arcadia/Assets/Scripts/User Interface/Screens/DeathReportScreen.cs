using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeathReportScreen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _nextUIPage;
    [SerializeField] private Image _characterPortrait;

    private Character[] _nightPhaseDeaths;
    private int _numberDeathsReported;


    void Start()
    {
        _nightPhaseDeaths = GameManager.Instance.GetNightPhaseDeaths();

        if (_nightPhaseDeaths.Length == 0)
        {
            GoToNextPage();
        }
        else
        {
            ReportNextDeath();
        }
    }


    public void OnPointerClick(PointerEventData _)
    {
        if (_numberDeathsReported >= _nightPhaseDeaths.Length)
        {
            _numberDeathsReported = 0;
            GoToNextPage();
        }
        else
        {
            ReportNextDeath();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    private void ReportNextDeath()
    {
        // Critical that _numberDeathsReported is AFTER the UI is updated!!
        UpdateUI();
        _numberDeathsReported++;
    }


    private void UpdateUI()
    {
        // This is where I would iterate over all the dead people and make a report for them.
        // I would need serialized fields for the icon and texts
        // 
        // From there probably jsut a bunch of FormatText type functinos for each TextMeshProUGUI thingy
        Character character = _nightPhaseDeaths[_numberDeathsReported];
        _characterPortrait.sprite = character.Portrait;
    }


    private void GoToNextPage()
    {
        this.gameObject.SetActive(false);
        _nextUIPage.SetActive(true);
    }
}
