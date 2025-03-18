using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimes : MonoBehaviour
{
    public CoroutineClock clock;

    private void Start()
    {
        clock.OnTheHour.AddListener(Chime);
    }
    // Start is called before the first frame update
    public void Chime(int hour)
    {
        Debug.Log("Chiming " + hour + "o'clock !");
    }

    public void ChimeWithoutArguments()
    {
        Debug.Log("Chiming !");
    }

}
