using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Components;

public class StovePanel : Basepanel<StovePanel>
{
    private MouseLook mouseLook;
    void Start()
    {
        mouseLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
        this.HidePanel();
    }

    void Update()
    {
        //°´EÊ°È¡
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (CookPanel.Instance.gameObject.activeSelf)
            {
                CookPanel.Instance.HidePanel();
                mouseLook.SetCursorLock(true);
            }
            else
            {
                CookPanel.Instance.ShowPanel();
                mouseLook.SetCursorLock(false);

            }
        }
    }
}