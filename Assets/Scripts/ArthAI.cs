using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthAI : MonoBehaviour
{
    private const int SECONDS_IN_DAY = 86400;               // TODO: consider making this data driven.
    public static ArthAI Instance { get; private set; }

    private GameDate _currentDate;
    public GameDate CurrentDate => _currentDate;

    private long _secondCount = 0;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        _currentDate = new GameDate(1, 1, 4720);
    }

    public void TimePass(long seconds)
    {
        _secondCount += seconds;
        if (_secondCount >= SECONDS_IN_DAY)
        {
            _secondCount = 0;
            _currentDate.IncrementDay();
        }
    }
}
