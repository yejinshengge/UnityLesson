using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
  
    }

    // Update is called once per frame
    void Update()
    {

        // Vector3 pos = transform.position;
        //
        // int vertical = 0;
        // if (Input.GetKey(KeyCode.W))
        // {
        //     vertical = 1;
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     vertical = -1;
        // }
        //
        // int horizontal = 0;
        // if (Input.GetKey(KeyCode.A))
        // {
        //     horizontal = -1;
        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     horizontal = 1;
        // }
        //
        // pos.x = pos.x + speed * Time.deltaTime * horizontal;
        // pos.y = pos.y + speed * Time.deltaTime * vertical;
        //
        // transform.position = pos;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime, Space.World);

        // if (horizontal < 0)
        // {
        //     sr.sprite = leftSprite;
        // }
        // else if (horizontal > 0)
        // {
        //     sr.sprite = rightSprite;
        // }
        //
        // if (vertical < 0)
        // {
        //     sr.sprite = downSprite;
        // }
        // else if (vertical > 0)
        // {
        //     sr.sprite = upSprite;
        // }

        var angle = transform.eulerAngles;
        if (horizontal < 0)
        {
            angle.z = 90;
        }
        else if (horizontal > 0)
        {
            angle.z = -90;
        }

        if (vertical < 0)
        {
            angle.z = -180;
        }
        else if (vertical > 0)
        {
            angle.z = 0;
        }

        transform.eulerAngles = angle;
    }
}
