using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psuedocode : MonoBehaviour
{
    //Challenge 1 Psuedocode

    //Variables
        //timer
        //index
        //time between each spawned object
        //array to keep a hold of prefabs

    //Repeat infinitely (Coroutine):
        //Use a time to handle spawn timing
        //Wait for the timer to finish 

    //Coroutine:
        //timer
        //when its time to spawn a prefab:
        //Increase time by Time.deltaTime
        //Generate random spawn position(between world screen space)
        //Spawn one of 3 obstacles based on index:
        //If index is 0 (Star):
            //Instantiate Star at the random spawn position
            //Set the Star's player reference to the ship and interaction event to starEvent.
            //Store the spawned prefan in the array at the index counter.
        //If currentSpawn is 1 (Asteroid):
            //Instantiate Asteroid at the random spawn position
            //Set Asteroid's player reference to ship
            //Store the spawned prefan in the array at the index counter.
        //if its not 0 or 1 (Blackhole) :
            //Instantiate Blackhole at spawn position
            //Store the spawned prefan in the array at the index counter.
            //Subscribe Blackhole to events

        //Cycle through obstacle types



    //Challenge 2 Psuedocode

    //Variables
        //reference game object's and assign in the inspector (ship, effect prefab)
        //radius
        //UnityEvent
        //Vector2 for movement

    //Update
        //Calculate and update the movement vector for the object
        //Calculate to check the distance between the object and the player
        //If the player is within the radius of the object
            //Invoke the event (this triggers the score increase located in main ship script)
            //Instantiate the effect prefab at the object's position
            //Destroy the current object

    //Function CalculatingDistance
        //Calculate the difference in the X and Y positions between the player and the object
        //Use Distance Equation
        //Return true if the player is within range (using radius variable)

    //Challenge 3 Psuedocode

    //Timer

    //Variables
        //time
        //score
        //bonus effect (prefab) 
        //array
        //ship

        //reduce the timer using Time.DeltaTime
        //if time is less than 0 destroy the object the script is on

    //Bonus Function
        //check if score is increased by 5 (if the score is a multiplier of 5)
        //instantiate bonus effect prefab

    //Use GetComponent (get access to the main script located on the ship)
}
