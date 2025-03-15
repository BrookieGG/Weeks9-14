using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float f = 2;
    public UnityEvent hourChange;

    // Start is called before the first frame update
    void Start()
    {
        //hourChange.AddListener(ChangeHour);
    }

    // Update is called once per frame
    void Update()
    {
        f -= Time.deltaTime;

        if (f < 0)
        {
            f = 2;
            hourChange.Invoke();
        }
    }
   
}
