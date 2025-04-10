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
    private float TimeValue = 30;
    private GameObject[] obstacles = new GameObject[100]; //arrays https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Array.html
    private int counter = 0;
    private bool isStarted = false;
    private bool move = false;
    private bool upRight;

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
    public UnityEvent asteroidEvent;
    public TMP_Text score;
    public TMP_Text Timer;
    public GameObject GameOver;
    public GameObject Restart;
    public GameObject Effect;
    public GameObject BonusEffect;
    public GameObject launch;


    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        starEvent.AddListener(starInteract);
        asteroidEvent.AddListener(AsteroidEffect);
        blackholeEvent.AddListener(EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2();
        Vector3 rot = new Vector3();

        if (upRight)
        {
            rot.z = 0; //up
            upRight = false;
        }

        if (move)
        {
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

            //rotates ship based on direction movement
            if (movement.x > 0 && movement.y > 0) //top right
            {
                rot.z = -45f;
            }
            else if (movement.y > 0 && movement.x < 0) //top left
            {
                rot.z = 45f;
            }
            else if (movement.y < 0 && movement.x > 0) //bottom right
            {
                rot.z = -135f;
            }
            else if (movement.y < 0 && movement.x < 0) //bottom left
            {
                rot.z = 135f;
            }
            else if (movement.x < 0) //left
            {
                rot.z = 90;
            }
            else if (movement.x > 0) //right
            {
                rot.z = -90;
            }
            else if (movement.y < 0) //down
            {
                rot.z = 180;
            }
            else
            {
                rot.z = 0; //up
            }
    
            transform.eulerAngles = rot;
        }



        if (isStarted)
        { 
            if (TimeValue > 0)
            {
                TimeValue -= Time.deltaTime;
                Timer.text = "Time: " + Mathf.FloorToInt(TimeValue); //game timer
            }

            else
            {
                Timer.text = "Time: 0";
                EndGame();
            }
        }

    }

    public void BeginGame()
    {
        
        obstacleSpawn = StartCoroutine(SpawnTheObstacles());
        launch.SetActive(false);
    }
    public void Launch()
    {
        ship.transform.position = new Vector2(0, 0); //moves ship to center
        ship.GetComponent<ShipBehaviour>().enabled = true;
        ship.GetComponent<ShipBehaviour>().BeginGame();
        isStarted = true;
        move = true;
    }
    private void starInteract()
    {
        scoreValue += 1;
        score.text = "Score: " + scoreValue;
        Bonus();
    }

    void EndGame()
    { //stops corotinues, stops obstacles from spawning
        StopCoroutine(SpawnTheObstacles());
        StopCoroutine(spawnObject);
        GameOver.SetActive(true); //displays ui
        Restart.SetActive(true);
        move = false;
        isStarted = false;
    }

    public void RestartGame()
    {
        //destorys all the obstacles
        for(int i = 0; i < obstacles.Length; i++) 
        {
            Destroy(obstacles[i]);
            ship.transform.position = new Vector2(0, -2.9f);
        }
        GameOver.SetActive(false); //hides gameover text
        Restart.SetActive(false);
        scoreValue = 0; //restarts score
        score.text = "Score: " + scoreValue;
        TimeValue = 30; //restarts time
        isStarted = false;
        //launch button shows up
        launch.SetActive(true);
        upRight = true;
    }
    public void AsteroidEffect()
    { 
        scoreValue -= 1; //decreases score
        score.text = "Score: " + scoreValue;
    }

    public void Bonus()
    {
        if (scoreValue % 5 == 0) //every time 5 stars are collected it plays bonus effect
        {
            Instantiate(BonusEffect, transform.position, Quaternion.identity);
        }
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
        //Debug.Log("obstacle spawns");

        //generates random spawn position from -8 to 8
        spawnTransform = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));

        //instantiate one of 3 prefabs
        if (currentSpawn == 0)
        {
            GameObject spawned = Instantiate(star, spawnTransform, Quaternion.identity);
            spawned.GetComponent<Star>().player = ship;
            spawned.GetComponent<Star>().interact = starEvent;
            obstacles[counter] = spawned;

        }
        else if (currentSpawn == 1)
        {
            GameObject spawned = Instantiate(asteroid, spawnTransform, Quaternion.identity);
            spawned.GetComponent<Asteroid>().player = ship;
            spawned.GetComponent<Asteroid>().interact = asteroidEvent;
            obstacles[counter] = spawned;
        }
        else 
        {
            GameObject spawned = Instantiate(blackhole, spawnTransform, Quaternion.identity);
            spawned.GetComponent<Blackhole>().player = ship;
            spawned.GetComponent<Blackhole>().interact = blackholeEvent;
            spawned.GetComponent<Blackhole>().Subscribe();
            obstacles[counter] = spawned;
        }
        counter++;

        //Cycle through obstacles (0 = star, 1 = asteroid, 2 = blackhole)
        currentSpawn = (currentSpawn + 1)%3;

    }
}
