using System;
using System.IO; 
using UnityEngine;

public class GlobalDayCounter : MonoBehaviour
{
    string filePath;
    string configFolder;
// protected virtual void start is for childclass without this childclass dont working cus Start() means "only childclass start()" idk why
    protected virtual void Start()
    {
        // a basic kash and cfg derictory finding for all devices
        string rootPath = Application.persistentDataPath;

        configFolder = Path.Combine(rootPath, "config");

        if (!Directory.Exists(configFolder))
        {
            Directory.CreateDirectory(configFolder);
        }
        // this is looking at the launched device and change a directory from a / to \ or . for android windows or linux 
        filePath = Path.Combine(configFolder, "StartCountDate.cfg");

        // cfg debug
        Debug.Log("cfg path: " + filePath);

        if (!File.Exists(filePath))
        {
            FirstLaunch();
        }
        else
        {
            RegularLaunch();
        }
    }

    void FirstLaunch()
    {
    //    this is cfg making.   Utc.now is a finding a not user set date time and finding a regional format or idk something like this
    //    making a varible with date
        DateTime now = DateTime.UtcNow;
    //    taking from varible "now" a year month and day and setting a time to 0 0 0 cus tamagochi will change day in the download time like new day at 15:00
        DateTime targetTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
    //    fixing errors if we will move to the another country or just change a utc or gmt, (like in half year)
        string timeText = targetTime.ToString(System.Globalization.CultureInfo.InvariantCulture);
        File.WriteAllText(filePath, timeText);
        Debug.Log("first count day cfg saved");
    }
    // making global usable day counter and showing in unity
    
    protected int daysPassed;
    protected void RegularLaunch()
    {
        try 
        {
            // its easy for read, this making a day count from a First launch day and assign in a varible daysPassed. 
            // datetime parse using for a cfg reading cus in cfg all text is just a words with parameters
            string savedText = File.ReadAllText(filePath);
            DateTime firstDate = DateTime.Parse(savedText);
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan difference = currentDate - firstDate;
            daysPassed = (int)difference.TotalDays;

            Debug.Log("day count: " + daysPassed);
        }
        // if error "catch" will show this in debug instead of crush. "e" is a varible
        catch (Exception e)
        {
            Debug.LogError("count config error: " + e.Message);
        }
    }
}