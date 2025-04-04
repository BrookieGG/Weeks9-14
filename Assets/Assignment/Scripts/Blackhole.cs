using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            float currentScale = gameObject.transform.localScale.x;
            currentScale += maxScale * Time.deltaTime;
            gameObject.transform.localScale = new Vector2(currentScale, currentScale);
        }

        if (CalculateDistance())
        {
            interact.Invoke();
        }
    }

    public void Subscribe()
    {
        interact.AddListener(EndGame);
    }

    public void EndGame()
    {
        isDone = true;
    }
    bool CalculateDistance()
    {
        float changeX = player.transform.position.x - transform.position.x;
        float changeY = player.transform.position.y - transform.position.y;
        //using 2D distance equation - https://en.wikipedia.org/wiki/Euclidean_distance
        float distance = Mathf.Sqrt(Mathf.Pow(changeX, 2) + Mathf.Pow(changeY, 2));
        return distance < radius;
    }
}
