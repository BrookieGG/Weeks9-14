using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HourHand : MonoBehaviour
{
    public UnityEvent hourChange;
    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        hourChange.AddListener(ChangeHour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHour()
    {
       
        Vector3 rot = transform.eulerAngles;
        rot.z -= 30;
        transform.eulerAngles = rot;

    }
}
