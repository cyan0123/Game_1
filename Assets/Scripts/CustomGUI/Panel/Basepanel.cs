using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basepanel<T> : MonoBehaviour where T :class
{
    private static T instance;
    public static T Instance => instance;
    private void Awake()
    {
        instance = this as T;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }   
    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
}
