using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveDetectPalyer : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StovePanel.Instance.ShowPanel();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        StovePanel.Instance.HidePanel();
        CookPanel.Instance.HidePanel();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StovePanel.Instance.ShowPanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StovePanel.Instance.HidePanel();
        CookPanel.Instance.HidePanel();
    }
}
