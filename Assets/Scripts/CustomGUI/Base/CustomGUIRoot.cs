using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] allControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI()
    {
        allControls = this.GetComponentsInChildren<CustomGUIControl>(); 
        for (int i = 0;i<allControls.Length;i++)
        {
            allControls[i].DrawGUI();
        }
    }
}
