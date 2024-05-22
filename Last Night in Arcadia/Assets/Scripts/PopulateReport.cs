using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulateReport : MonoBehaviour
{
    [SerializeField] private DayTracker.TimesOfDay time;
    [SerializeField] private TextMeshProUGUI tm;

    // Start is called before the first frame update
    void Start()
    {
        DayTracker dt = GameManager.Instance.GetDayTracker();
        tm.text = GameManager.ReportManager.GetDayAndTimeReports(dt, time, dt.GetDaysFromZero());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
