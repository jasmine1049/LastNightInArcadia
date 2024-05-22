using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReportsManager
{

    private struct report
    {
        public int day;
        public DayTracker.TimesOfDay time;
        public string details;
        public report(int day, DayTracker.TimesOfDay time, string details)
        {
            this.day = day;
            this.time = time;
            this.details = details;
        }
    }

    private Dictionary<int, List<report>> reports;
    public ReportsManager()
    {
        reports = new Dictionary<int, List<report>>();
    }

    public void AddItem(int day, DayTracker.TimesOfDay time, string details)
    {
        if (!reports.ContainsKey(day))
        {
            reports[day] = new List<report>();
        }
        reports[day].Add(new report(day, time, details));
    }

    // needs day tracker to know when starting date is and format the dates accordingly
    public string GetDayReports(DayTracker dt, int day)
    {
        string r = "";
        r += dt.GetDateString() + "\n";
        if (!reports.ContainsKey(day))
        {
            return r + "Nothing eventful happened on this day.";
        }
        foreach (report rep in reports[day].OrderBy(x => x.time))
        {
            r += rep.details + "\n";
        }
        return r + "\n\n";
    }

    public string GetDayAndTimeReports(DayTracker dt, DayTracker.TimesOfDay time, int day)
    {
        string r = "";
        r += dt.GetDateString() + "\n";
        if (!reports.ContainsKey(day))
        {
            return r + "Nothing eventful happened.";
        }
        foreach (report rep in reports[day].Where(x => x.time == time))
        {
            r += rep.details + "\n";
        }
        return r + "\n\n";
    }

}
