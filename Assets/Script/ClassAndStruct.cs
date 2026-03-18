
using System;
using UnityEngine;

public class ClassAndStruct:MonoBehaviour
{
    class Vector
    {
        public int x;
    }

    private Vector nullClass;
    private Vector3 nullStruct;
    private void Start()
    {
        // 赋值时的区别
        var vec = new Vector();
        vec.x = 5;
        var vec2 = vec;
        vec2.x = 10;
        Debug.Log("vec.x = " + vec.x + " vec2.x = " + vec2.x);
        
        int a = 10;
        int b = a;
        b = 5;
        Debug.Log("a = " + a + " b = " + b);
        
        var pos = new Vector3(1, 1, 1);
        var pos2 = pos;
        pos2.x = 5;
        Debug.Log("pos = " + pos + "pos2 = " + pos2);
        
        // 是否需要实例化
        // nullClass.x = 10;
        nullStruct.x = 10;
    }
}
