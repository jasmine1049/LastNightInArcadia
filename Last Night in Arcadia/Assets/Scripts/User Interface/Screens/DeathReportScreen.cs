using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeathReportScreen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _nextUIPage;

    [SerializeField] private GameObject _characterPortrait;
    [SerializeField] private GameObject _journalist;
    [SerializeField] private GameObject _singer;

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
        
        // Very ugly temp thing to make the animation work :D!
        if (character.Name == "Journalist")
        {
            _journalist.SetActive(true);
            _characterPortrait.SetActive(false);
            _singer.SetActive(false);
        }
        else if (character.Name == "Actress")
        {
            _singer.SetActive(true);
            _characterPortrait.SetActive(false);
            _journalist.SetActive(false);
        }
        else
        {
            _singer.SetActive(false);
            _journalist.SetActive(false);
            _characterPortrait.SetActive(true);
            _characterPortrait.GetComponent<Image>().sprite = character.Portrait;
        }
    }


    private void GoToNextPage()
    {
        this.gameObject.SetActive(false);
        _nextUIPage.SetActive(true);
    }
}
