using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float fallSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move the object down based on fallSpeed
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        //if the object is off the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject); //destory prefab
        }
    }
}
