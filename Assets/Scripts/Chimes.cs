using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimes : MonoBehaviour
{
    public CoroutineClock clock;
    public AudioSource source;
    public AudioClip clip;
    public GameObject bird;

    private void Start()
    {
        clock.OnTheHour.AddListener(Chime);
    }
    // Start is called before the first frame update
    public void Chime(int hour)
    {
        Debug.Log("Chiming " + hour + "o'clock !");
        source.PlayOneShot(clip);
        GameObject cuckoo = Instantiate(bird, transform.position, Quaternion.identity);
        Destroy(cuckoo, 2);
    }

    public void ChimeWithoutArguments()
    {
        Debug.Log("Chiming !");
    }

}
