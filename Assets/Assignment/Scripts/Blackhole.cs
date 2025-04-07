using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Blackhole : MonoBehaviour
{
    public GameObject player;
    public float radius = 50;
    public UnityEvent interact;

    private float maxScale = 5f;
    private bool isDone = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(transform.position.x, transform.position.y) - player.GetComponent<ShipBehaviour>().movement;
        transform.position = movement;
        if (isDone )
        {
            //increase scalle of blackhole
            float currentScale = gameObject.transform.localScale.x;
            currentScale += maxScale * Time.deltaTime;
            gameObject.transform.localScale = new Vector2(currentScale, currentScale);
        }

        if (CalculateDistance())
        {
            interact.Invoke(); //triggers interaction that triggers the end of the game
        }
    }

    public void Subscribe()
    {
        interact.AddListener(EndGame);  //Add a listener for the interact event
    }

    public void EndGame()
    {
        isDone = true; //Start scaling the black hole
    }
    bool CalculateDistance()
    {
        //distance equation
        float changeX = player.transform.position.x - transform.position.x;
        float changeY = player.transform.position.y - transform.position.y;
        //using 2D distance equation - https://en.wikipedia.org/wiki/Euclidean_distance
        float distance = Mathf.Sqrt(Mathf.Pow(changeX, 2) + Mathf.Pow(changeY, 2));
        return distance < radius; //return if the ship is within the radius
    }
}
