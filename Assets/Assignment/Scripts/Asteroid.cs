using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject player;
    public float radius = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
