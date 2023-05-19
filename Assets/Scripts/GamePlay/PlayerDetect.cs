using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    private HerbData herbData;
    private Canvas text;
    // Start is called before the first frame update
    void Start()
    {
        //print(Name);
        text = transform.GetChild(0).GetChild(0).GetComponent<Canvas>();
        text.enabled = false;
        herbData = GetComponent<HerbData>();
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = herbData.herbName;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            PickupPanel.Instance.ShowPanel();
            PickupPanel.Instance.addHerb(this.herbData);
            text.enabled = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickupPanel.Instance.HidePanel();
            PickupPanel.Instance.delHerb(this.herbData);
            text.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickupPanel.Instance.ShowPanel();
            PickupPanel.Instance.addHerb(this.herbData);
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickupPanel.Instance.HidePanel();
            PickupPanel.Instance.delHerb(this.herbData);
            text.enabled = false;
        }
    }

}
