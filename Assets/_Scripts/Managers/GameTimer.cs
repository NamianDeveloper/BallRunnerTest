using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameTimer
{
    public int Minute
    {
        get => minute;
        set => minute = value;
    }

    public int Second
    {
        get => second;
        set
        {
            if (value > 59)
            {
                minute++;
                second = 0;
            }
            else
            {
                second = value;
            }
        }
    }

    private int minute;
    private int second;

    public string CurrentTime()
    {
        string currentTime = "";
        currentTime += minute < 10 ? $"0{Minute}:" : minute + ":";
        currentTime += second < 10 ? $"0{second}" : second;

        return currentTime;
    }
}