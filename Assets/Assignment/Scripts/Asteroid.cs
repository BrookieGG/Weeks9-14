using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    public GameObject player;
    public float radius = 2;
    public UnityEvent interact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(transform.position.x, transform.position.y) - player.GetComponent<ShipBehaviour>().movement;
        transform.position = movement;
        if (CalculateDistance())
        {
            interact.Invoke();
            Destroy(gameObject);
        }
    }

    public void Subscribe()
    {
        ShipBehaviour shipScript = player.GetComponent<ShipBehaviour>();
        if (shipScript != null)
        {
            interact.AddListener(shipScript.AsteroidEffect);
        }
    }

    bool CalculateDistance()
    {
        float changeX = player.transform.position.x - transform.position.x;
        float changeY = player.transform.position.y - transform.position.y;
        //using 2D distance equation - https://en.wikipedia.org/wiki/Euclidean_distance
        float distance = Mathf.Sqrt(Mathf.Pow(changeX, 2) + Mathf.Pow(changeY,2));
        return distance < radius;
    }
}
