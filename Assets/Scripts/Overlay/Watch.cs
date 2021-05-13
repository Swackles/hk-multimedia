using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Watch : MonoBehaviour
{
    float timer;
    float milliseconds;
    float seconds;
    float minutes;

    bool start;

    [SerializeField] TextMeshProUGUI stopWatch;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StopWatch();
    }

    void StopWatch()
    {
        if(start)
        {
            timer += Time.deltaTime;
            milliseconds = (int)(timer * 1000) % 1000;
            seconds = (int)(timer % 60);
            minutes = (int)(timer / 60) % 60;

            stopWatch.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        }
    }

    public void StartStopWatch()
    {
        start = true;
    }

    public void StopStopWatch()
    {
        start = false;
    }

    public float MsStopWatch()
    {
        if (start)
        {
            timer += Time.deltaTime;
            milliseconds = (int)(timer * 1000);
        }
        return milliseconds;
    }

}
