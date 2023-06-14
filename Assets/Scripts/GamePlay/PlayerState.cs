using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int hot = 0, cold = 0, poison = 0;
    private static PlayerState instance;
    public static PlayerState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerState>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<PlayerState>();
                    singletonObject.name = "SingletonClass";
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this as PlayerState;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void setHot(int data)
    {
        hot += data;

    }
}
