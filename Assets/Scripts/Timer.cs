using UnityEngine;
using System.Collections;

public struct Timer
{
    float _endTime;

    public void Wait(float seconds)
    {
        _endTime = Time.timeSinceLevelLoad + seconds;
    }

    public bool IsEnd()
    {
        return Time.timeSinceLevelLoad > _endTime;
    }

    public bool IsWaitting()
    {
        return !IsEnd();
    }
}
