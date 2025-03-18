using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineClock : MonoBehaviour
{
    public Transform minuteHand;
    public Transform hourHand;
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    private Coroutine clockIsRunning;
    private IEnumerator doOneHour;

    // Start is called before the first frame update
    void Start()
    {
        clockIsRunning = StartCoroutine(MoveTheClock());
    }

    // Update is called once per frame
    private IEnumerator MoveTheClock()
    {
        while (true)
        {
            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doOneHour);
        }
    }
    private IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if(hour == 13)
        {
            hour = 1;
        }

        OnTheHour.Invoke(hour);
    }
    public void StopClock()
    {
        StopCoroutine(clockIsRunning);
        StopCoroutine(doOneHour);
    }
}
