using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    private Coroutine obstacleSpawn;
    private IEnumerator spawnObject;
    public float t;
    public float timeToSpawn = 5;
    public GameObject star;
    public GameObject blackhole;
    public GameObject asteroid;
    private int currentSpawn;
    private Transform spawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        spawnTransform = transform;
        obstacleSpawn = StartCoroutine(SpawnTheObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnTheObstacles()
    {
        while (true)
        {
            spawnObject = ObstacleTimer();
            yield return StartCoroutine(spawnObject);
        }
    }

    private IEnumerator ObstacleTimer()
    {
        t = 0;
        while (t < timeToSpawn)
        {
            t += Time.deltaTime;
            yield return null;
        }
        Debug.Log("obstacle spawns");
        spawnTransform.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        if (currentSpawn == 0)
        {
            Instantiate(star,spawnTransform);
        }
        else if (currentSpawn == 1)
        {
            Instantiate(asteroid, spawnTransform);
        }
        else 
        {
            Instantiate(blackhole, spawnTransform);
        }
        currentSpawn = (currentSpawn + 1)%3;

    }
}
