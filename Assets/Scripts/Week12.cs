using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Week12 : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector2 targetPos;
    private bool isWalking = false;


    Animator animator;
    Animator animatorup;
    SpriteRenderer sr;
    public AudioClip footstep;
    public AudioSource footstepSource;
  

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //sr = GetComponent<SpriteRenderer>();
        //animatorup = GetComponent<Animator>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            isWalking = true;
        }
     

        if (isWalking == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPos) < 0.05f);
            {
                transform.position = targetPos;
                isWalking = false;
            }
        }
       

    }

    

    public void Footstep()
    {
        footstepSource.PlayOneShot(footstep);
    }

    public void Shake()
    {
        //impulse.GenerateImpulse();
    }
}
