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
            if (allControls[i] is PacItem || allControls[i] is PacItem CookItem) continue; 
            allControls[i].DrawGUI();
        }

        if (Application.isPlaying)
        {
            if (CookPanel.Instance.gameObject.activeSelf)
            {
                for (int i = 0; i < ItemRenderContol.Instance.allItems.Count; i++)
                {
                    ItemRenderContol.Instance.allItems[i].DrawGUI();
                    //print(ItemRenderContol.Instance.allItems[i].transform.parent.name);
                }
            }
        }
    }
}
