using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

// This class encapsulates all of the metrics that need to be tracked in your game. These may range
// from number of deaths, number of times the player uses a particular mechanic, or the total time
// spent in a level. These are unique to your game and need to be tailored specifically to the data
// you would like to collect. The examples below are just meant to illustrate one way to interact
// with this script and save data.
public static class MetricManager
{
    static MetricData metricData;
    public static void Initialize()
    {
        metricData = new MetricData();
    }

    // Public method to add to Metric 1.
    public static void AddToMetric1 (LevelInfo info)
    {
        metricData.AddLevelWPMMetric(info);
    }

    // Public method to add to Metric 2.
    //public void AddToMetric2 (double valueToAdd)
    //{
    //    m_metric2 += valueToAdd;
    //}

    // Converts all metrics tracked in this script to their string representation
    // so they look correct when printing to a file.


    // Uses the current date/time on this computer to create a uniquely named file,
    // preventing files from colliding and overwriting data.


    // Generate the report that will be saved out to a file.


    // The OnApplicationQuit function is a Unity-Specific function that gets
    // called right before your application actually exits. You can use this
    // to save information for the next time the game starts, or in our case
    // write the metrics out to a file.
    public static void Quit()
    {
        //metricData.WriteMetricsToFile ();
    }
}
