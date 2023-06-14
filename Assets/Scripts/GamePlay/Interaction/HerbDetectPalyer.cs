using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HerbDetectPalyer : MonoBehaviour
{
    private HerbData herbData;
    private Canvas text;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(0).GetChild(0).GetComponent<Canvas>();
        text.enabled = false;
        herbData = GetComponent<Herb>().herbData;
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
            Pickup.Instance.addHerb(this.gameObject.GetComponent<Herb>());
            text.enabled = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickupPanel.Instance.HidePanel();
            Pickup.Instance.delHerb(this.gameObject.GetComponent<Herb>());
            text.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickupPanel.Instance.ShowPanel();
            Pickup.Instance.addHerb(this.gameObject.GetComponent<Herb>());
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickupPanel.Instance.HidePanel();
            Pickup.Instance.delHerb(this.gameObject.GetComponent<Herb>());
            text.enabled = false;
        }
    }

}
