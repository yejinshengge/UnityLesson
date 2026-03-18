using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 速度
    public float Speed = 3f;
    private SpriteRenderer sp;
    private Rigidbody2D rd;
    
    // 方向
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    
    // 子弹预制体
    public GameObject bulletPrefab;
    // 射击cd
    public float bulletCd = 1f;
    // 射击cd计时器
    private float bulletCdTimer = 0f;
    // 子弹需要旋转的角度
    private Vector3 bulletAngles;
    
    // 爆炸特效预制体
    public GameObject explodePrefab;
    
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        rd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _attack(Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveByAxis(Time.fixedDeltaTime,out var h,out var v);
        _rotateBySprite(h,v);
    }

    /// <summary>
    /// 受到攻击
    /// </summary>
    public void BeAttacked()
    {
        // 播放爆炸特效
        Instantiate(explodePrefab, transform.position, transform.rotation);
        // 销毁自身
        Destroy(gameObject);
    }

    private void _attack(float deltaTime)
    {
        if (bulletCdTimer < bulletCd)
        {
            bulletCdTimer += deltaTime;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletAngles));
            var bulletController = bullet.GetComponent<BulletController>();
            bulletController.isFriendly = true;
            bulletCdTimer = 0;
        }
    }

    /// <summary>
    /// 通过轴向移动
    /// </summary>
    private void _moveByAxis(float deltaTime,out float h,out float v)
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.right * horizontal * Speed * Time.deltaTime,Space.World);
        // transform.Translate(Vector3.up * vertical * Speed * Time.deltaTime,Space.World);
        // var dir = new Vector3(horizontal, vertical,0);

        var dir = Vector3.zero;
        if (Math.Abs(vertical) > 0)
        {
            dir.y = vertical;
        }
        else
        {
            dir.x = horizontal;
        }
        rd.MovePosition(transform.position + dir * Speed * deltaTime);
        h = horizontal;
        v = vertical;
    }
    
    /// <summary>
    /// 通过精灵图旋转
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    private void _rotateBySprite(float horizontal, float vertical)
    {
        if (vertical > 0)
        {
            sp.sprite = upSprite;
            bulletAngles.z = 0;
        }
        else if (vertical < 0)
        {
            sp.sprite = downSprite;
            bulletAngles.z = 180;
        }
        
        if(Math.Abs(vertical) > 0)
            return;
        
        if (horizontal > 0)
        {
            sp.sprite = rightSprite;
            bulletAngles.z = -90;
        }
        else if (horizontal < 0)
        {
            sp.sprite = leftSprite;
            bulletAngles.z = 90;
        }
    }
}
