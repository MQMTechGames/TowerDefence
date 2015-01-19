using UnityEngine;
using System.Collections.Generic;

public class AttackerWaveManager : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> _waves;

    int _waveCount = 0;

    Timer _waveTimer;

    void Update()
    {
        if (_waveTimer.IsEnd() && _waves.Count > _waveCount)
        {
            _waves[_waveCount].Play();
            _waveTimer.Wait(_waves[_waveCount].WaitTime);

            _waveCount++;
        }
    }
}
