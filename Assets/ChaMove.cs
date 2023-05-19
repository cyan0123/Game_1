using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaMove : MonoBehaviour
{
    private Vector3 lastPosition;
    private float lastTime;

    private float Zspeed;
    private float Xspeed;
    private float Yspeed;
    //private float height;
    private bool XisZero;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float currentTime = Time.time;

        float deltaTime = currentTime - lastTime;
        //获取速度是要转换成本地向量
        Vector3 deltaPosition = transform.InverseTransformPoint(currentPosition) - transform.InverseTransformPoint(lastPosition);

        Zspeed = deltaPosition.z / deltaTime;
        Xspeed = deltaPosition.x / deltaTime;
        Yspeed = deltaPosition.y / deltaTime;
        if (System.Math.Abs(Yspeed) < System.Math.Abs(Xspeed)) Yspeed = 0;
        if (System.Math.Abs(Yspeed) < System.Math.Abs(Zspeed)) Yspeed = 0;
        //print(Yspeed);
        if (System.Math.Abs(Zspeed)> System.Math.Abs(Xspeed)) XisZero = true;
        else
        {
            XisZero = false;
           if(Input.GetAxis("Vertical") < 0) Xspeed = -Xspeed;
        }

        //height = this.transform.position.y;


        lastPosition = currentPosition;
        lastTime = currentTime;
        UpdateAnim();
    }

    void UpdateAnim()
    {
        anim.SetFloat("Zspeed",Zspeed);
        anim.SetFloat("Xspeed", Xspeed);
        anim.SetFloat("Yspeed", Yspeed);
        //anim.SetFloat("Height", height);
        anim.SetBool("XisZero", XisZero);
    }
}
