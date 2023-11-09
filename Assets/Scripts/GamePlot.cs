using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlot : MonoBehaviour
{
    private GameDate currentDate;
    private float currentTimeCount;
    
    // Start is called before the first frame update
    void Start()
    {
        // TODO: load these obviously
        currentTimeCount = 0.0f;     
        currentDate = new GameDate(1,1,4260);
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeCount += Time.deltaTime;
        if (currentTimeCount > 3600.0f)
        {
            currentDate.IncrementDay();
            currentTimeCount = 0.0f;
        }
    }
}
