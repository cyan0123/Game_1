using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaMove : MonoBehaviour
{
    private static ChaMove instance;
    public static ChaMove Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    private Vector3 lastPosition;
    private float lastTime;

    private float Zspeed;
    private float Xspeed;
    private float Yspeed;
    //private float height;
    private bool XisZero;
    private bool Gathering;
    [HideInInspector]
    public bool Eating;
    Animator anim;
    void Start()
    {
        /*anim = transform.GetChild(1).GetComponent<Animator>();*/
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float currentTime = Time.time;

        float deltaTime = currentTime - lastTime;
        //��ȡ�ٶ���Ҫת���ɱ�������
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


        if (Eating)
        {
            //����Զ���ʱ���㹻
            if (Time.time - eatStartTime > 3.0f)
            {
                eatEvent();
            }
        }

        UpdateAnim();
    }

    void UpdateAnim()
    {
        anim.SetFloat("Zspeed",Zspeed);
        anim.SetFloat("Xspeed", Xspeed);
        anim.SetFloat("Yspeed", Yspeed);
        anim.SetBool("XisZero", XisZero);
        anim.SetBool("Gathering", Gathering);
        anim.SetBool("Eating", Eating);
    }
    public void Setpick()
    {
        Gathering = true;
        StartCoroutine(Timer(1f));  // ����һ��5��ļ�ʱ��
    }

    IEnumerator Timer(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // ÿ֡����ʱ��
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ��ʱ����ɺ���߼�����
        //Debug.Log("��ʱ�����");
        Gathering = false;
        
    }

    float eatStartTime = 0;
    public void StartEat()
    {
        /*Eating = true;
        eatStartTime = Time.time;*/
        if (Package.Instance.herbs[GamePanel.Instance.nowItem].herbData.herbType == HerbData.HerbType.Soup
            && !Eating)
        {
            Eating = true;
            eatStartTime = Time.time;
        }
    }
    public void EndEat()
    {
        Eating = false;
    }

    public void eatEvent()
    {
        Eating = false;
        print("�Զ���");
        //������ǲ�ҩ
        /*if( Package.Instance.herbs[GamePanel.Instance.nowItem].herbData.herbType == HerbData.HerbType.Soup)
        {
            print("��ҩ�˳�ҩ��   ");
        }*/

    }
}
