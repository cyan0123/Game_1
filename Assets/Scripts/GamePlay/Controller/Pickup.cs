using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup
{
    private static Pickup instance = new Pickup();
    public static Pickup Instance => instance;

    public List<Herb> herbs = new List<Herb>();
    private void Start()
    {
    }
    public void addHerb(Herb herb)
    {
        this.herbs.Add(herb);
    }
    public void delHerb(Herb herb)
    {
        this.herbs.Remove(herb);
    }

    Herb tmp;
    public void pickup()
    {
        Package.Instance.addHerb(this.herbs[0]);
        /*Object.Destroy(this.herbs[0].gameObject);
        this.delHerb(this.herbs[0]);*/
        if (herbs.Count == 0) PickupPanel.Instance.HidePanel();
    }

}
