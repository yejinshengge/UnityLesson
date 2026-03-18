using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour
{
    // 速度
    public float speed = 10f;
    
    // 自毁时间
    public float destroyCd = 3f;
    // 自毁计时器
    private float destroyTimer = 0f;

    private Rigidbody2D rd;

    // 是否是友方子弹
    public bool isFriendly = false;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.up物体上方在世界坐标系中的方向
        // transform.Translate默认在局部坐标中移动
        // transform.Translate(transform.up * speed * Time.deltaTime,Space.World);
        // Debug.Log(transform.up);
        
        destroyTimer += Time.deltaTime;
        if(destroyTimer > destroyCd)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }

    private void Move(float deltaTime)
    {
        // 移动到哪里
        rd.MovePosition(transform.position + transform.up * speed * deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        switch (other.tag)
        {
            case "Player":
                if(isFriendly) return;
                other.SendMessage("BeAttacked");
                break;
            case "Wall":
                Destroy(gameObject);
                Destroy(other.gameObject);
                break;
            case "IronWall":
                Destroy(gameObject);
                break;
            case "Home":
                other.SendMessage("BeAttacked");
                break;
            case "Enemy":
                break;
        }
    }
}
