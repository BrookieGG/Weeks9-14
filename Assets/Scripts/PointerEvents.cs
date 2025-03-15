using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PointerEvents : MonoBehaviour
{
    public SpriteRenderer Render;
    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject knife;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        Render.sprite = sprite1;
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = mousePos;
        
    }
     
    public void onPointerEnter()
    {
        Render.sprite = sprite1;
        Debug.Log("entered");
    }

    public void onPointerExit()
    {
        Render.sprite = sprite2;
        Debug.Log("exited");
    }

    public void onPointerClick()
    {
        Instantiate(knife, mousePos, Quaternion.identity);
    }
}
