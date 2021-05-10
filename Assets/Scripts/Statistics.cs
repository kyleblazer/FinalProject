﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Statistics : MonoBehaviour
{
    public void findAverageLap(float[] lapTimes)
    {
        float[] m_lapTimes = lapTimes;
        float totalTime = 0;
        int numLaps = m_lapTimes.Length;
        for (int i = 0; i<numLaps; ++i)
        {
            totalTime += m_lapTimes[i];
        }
        float average = totalTime / numLaps;
        int minutes = (int)average / 60;
        int seconds = (int)average - 60 * minutes;
        int milliseconds = (int)(1000 * (average - minutes * 60 - seconds));
        string averageTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        print("Average lap was " + averageTime);
    }
    public void findFastestLap(float[] lapTimes)
    {
        float[] m_lapTimes = lapTimes;
        int numLaps = m_lapTimes.Length;
        float min = m_lapTimes[0];
        for (int i = 1; i < numLaps; ++i)
        {
            if (m_lapTimes[i] < min)
            {
                min = m_lapTimes[i];
            }
        }
        int minutes = (int)min / 60;
        int seconds = (int)min - 60 * minutes;
        int milliseconds = (int)(1000 * (min - minutes * 60 - seconds));
        string minTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        print("Fastest lap was " + minTime);
    }
    public void findSlowestLap(float[] lapTimes)
    {
        float[] m_lapTimes = lapTimes;
        int numLaps = m_lapTimes.Length;
        float max = m_lapTimes[0];
        for (int i = 1; i < numLaps; ++i)
        {
            if (m_lapTimes[i] > max)
            {
                max = m_lapTimes[i];
            }
        }
        int minutes = (int)max / 60;
        int seconds = (int)max - 60 * minutes;
        int milliseconds = (int)(1000 * (max - minutes * 60 - seconds));
        string maxTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        print("Slowest lap was " + maxTime);
    }
    public void findVariance(float[] lapTimes)
    {
        float[] m_lapTimes = lapTimes;
        float totalTime = 0;
        int numLaps = m_lapTimes.Length;
        for (int i = 0; i < numLaps; ++i)
        {
            totalTime += m_lapTimes[i];
        }
        float average = totalTime / numLaps;
        float totalVariance = 0;
        for (int i = 0; i < numLaps; ++i)
        {
            totalVariance += Math.Abs(m_lapTimes[i]-average);
        }
        float averageVariance = totalVariance / numLaps;
        int minutes = (int)averageVariance / 60;
        int seconds = (int)averageVariance - 60 * minutes;
        int milliseconds = (int)(1000 * (averageVariance - minutes * 60 - seconds));
        string varianceString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        print("Average lap variance was " + varianceString);
    }
}
