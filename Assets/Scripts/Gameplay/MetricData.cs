using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MetricData
{ 
    public List<LevelInfo> LevelWPM {get {return levelWPM;}}
    static List<LevelInfo> levelWPM;

    public MetricData()
    {
        levelWPM = new List<LevelInfo>();
    }
    
    public void AddLevelWPMMetric(LevelInfo info)
    {
        levelWPM.Add(info);
    }

    private string CreateUniqueFileName(string metric)
    {
        string dateTime = System.DateTime.Now.ToString();
        dateTime = dateTime.Replace("/", "_");
        dateTime = dateTime.Replace(":", "_");
        dateTime = dateTime.Replace(" ", "___");
        return "Ghostwriter_" + metric + "_metrics_" + dateTime + ".csv";
    }
    public void WriteMetricsToFile()
    {
        string totalReport1 = "Report generated on " + System.DateTime.Now + "\n\n";
        totalReport1 += "Total Report:\n";
        totalReport1 += ConvertMetricsToStringRepresentation(0);
        totalReport1 = totalReport1.Replace("\n", System.Environment.NewLine);
        string reportFile1 = CreateUniqueFileName("PlayerPerformance");


#if !UNITY_WEBPLAYER
        File.WriteAllText(reportFile1, totalReport1);
#endif
    }
    private string ConvertMetricsToStringRepresentation(int metricID)
    {
        string metrics = "Here are my metrics:\n";
        switch(metricID)
        {
            case 0:
                metrics += "Level Words Per Minute:\n";
                metrics += "Level, WordCount, Time, WPM, Basic Ghost Count, Basic Ghost Kill Time, "
                    + "Jumping Ghost Count, Jumping Ghost Kill Time, Mini Ghost Count, Mini Ghost Kill Time, Cat Ghost Count, Cat Ghost Kill Time, Ghost Bomb Used, Barrier Used, Completed, Level Requirement\n";
                for (int i = 0; i < levelWPM.Count; i++)
                {
                    metrics += levelWPM[i].Level.ToString() + "," 
                        + levelWPM[i].WordCount.ToString() + "," 
                        + levelWPM[i].Time.ToString() + ","
                        + levelWPM[i].WPM.ToString() + ","
                        + levelWPM[i].BasicGhostCount.ToString() + ","
                        + levelWPM[i].BasicGhostKillTime.ToString() + ","
                        + levelWPM[i].JumpingGhostCount.ToString() + ","
                        + levelWPM[i].JumpingGhostKillTime.ToString() + ","
                        + levelWPM[i].MiniGhostCount.ToString() + ","
                        + levelWPM[i].MiniGhostKillTime.ToString() + ","
                        + levelWPM[i].CatGhostCount.ToString() + ","
                        + levelWPM[i].CatGhostKillTime.ToString() + ","
                        + levelWPM[i].GhostBombsUsed.ToString() + ","
                        + levelWPM[i].BarrierUsed.ToString() + ",";
                    if(levelWPM[i].Success)
                    {
                        metrics += "Completed, ";
                    }
                    else 
                    {
                        metrics += "Failed, ";
                    }
                    metrics += "="+levelWPM[i].LevelRequirement + ""+"\n";
                }
                break;
        }
        
        //metrics += "Metric 2: " + m_metric2.ToString() + "\n";
        return metrics;
    }
}
