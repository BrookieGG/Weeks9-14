using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class Knight : MonoBehaviour
{
    public float speed = 2;
    public float speedy = 2;
    Animator animator;
    Animator animatorup;
    SpriteRenderer sr;
    public bool canRun = true;
    public AudioClip footstep;
    public AudioSource footstepSource;
    public CinemachineImpulseSource impulse; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        animatorup =GetComponent<Animator>();
  
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        float directiony = Input.GetAxis("Vertical");
        sr.flipX = direction < 0;

        animator.SetFloat("speed",Mathf.Abs(direction));
        animatorup.SetFloat("speedy", Mathf.Abs(directiony));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
            transform.position += transform.up * directiony * speed * Time.deltaTime;
        }

    }

    public void AttackHasFinished()
    {
        Debug.Log("The attack has finished!");
        canRun = true;
    }

    public void Footstep()
    {
        footstepSource.PlayOneShot(footstep);
    }

    public void Shake()
    {
        impulse.GenerateImpulse();
    }
}
