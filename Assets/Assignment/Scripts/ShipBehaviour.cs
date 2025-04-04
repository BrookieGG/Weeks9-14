using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Runtime.CompilerServices;

public class ShipBehaviour : MonoBehaviour
{
    private int currentSpawn;
    private Vector2 spawnTransform;
    private Coroutine obstacleSpawn;
    private IEnumerator spawnObject;
    private int scoreValue = 0;

    public float t;
    public float timeToSpawn = 5;
    public GameObject star;
    public GameObject blackhole;
    public GameObject asteroid;
    public GameObject ship;
    public Vector2 movement;
    public float moveSpeed = 3;
    public UnityEvent starEvent;
    public UnityEvent blackholeEvent;
    public TMP_Text score;
    public GameObject GameOver;
  

    // Start is called before the first frame update
    void Start()
    {
        if (!enabled) return;
        {
            starEvent.AddListener(starInteract);
            blackholeEvent.AddListener(EndGame);
            obstacleSpawn = StartCoroutine(SpawnTheObstacles());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2();
        if (Input.GetAxis("Horizontal") < 0)
        {
            movement.x -= moveSpeed * Time.deltaTime;
            
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            movement.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            movement.y -= moveSpeed * Time.deltaTime;

        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            movement.y += moveSpeed * Time.deltaTime;
        }

        

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 30f); // Adjust as needed
        }

    }
    public void Launch()
    {
        ship.GetComponent<ShipBehaviour>().enabled = true;
        ship.GetComponent<ShipBehaviour>().Start();
    }
    private void starInteract()
    {
        
        scoreValue += 1;
        score.text = "Score: " + scoreValue;
    }

    void EndGame()
    {
        StopCoroutine(SpawnTheObstacles());
        StopCoroutine(spawnObject);
        GameOver.SetActive(true);
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
        spawnTransform = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        if (currentSpawn == 0)
        {
            GameObject spawned = Instantiate(star, spawnTransform, Quaternion.identity);
            spawned.GetComponent<Star>().player = ship;
            spawned.GetComponent<Star>().interact = starEvent;
            
        }
        else if (currentSpawn == 1)
        {
            GameObject spawned = Instantiate(asteroid, spawnTransform, Quaternion.identity);
            spawned.GetComponent<Asteroid>().player = ship;
        }
        else 
        {
            GameObject spawned = Instantiate(blackhole, spawnTransform, Quaternion.identity);
            spawned.GetComponent<Blackhole>().player = ship;
            spawned.GetComponent<Blackhole>().interact = blackholeEvent;
            spawned.GetComponent<Blackhole>().Subscribe();
        }
        currentSpawn = (currentSpawn + 1)%3;

    }
}
