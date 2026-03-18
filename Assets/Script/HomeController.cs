using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    // 爆炸特效预制体
    public GameObject explodePrefab;
    // 被摧毁图片
    public Sprite destroyedSprite;

    private SpriteRenderer sp;
    
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BeAttacked()
    {
        // 播放爆炸特效
        Instantiate(explodePrefab, transform.position, transform.rotation);
        // 切换贴图
        sp.sprite = destroyedSprite;
    }
}
