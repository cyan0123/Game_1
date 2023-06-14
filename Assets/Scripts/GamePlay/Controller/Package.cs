using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package
{
    private static Package instance = new Package();
    public static Package Instance => instance;
    Herb nowHerb;
    public List<Herb> herbs = new List<Herb>();
    public void addHerb(Herb herb)
    {
        this.herbs.Add(herb);
    }
    public void delHerb(Herb herb)
    {
        this.herbs.Remove(herb);
    }
    public void delHerb(HerbData herbData)
    {
        for (int i = 0; i < herbs.Count; i++)
        {
            if(herbData == this.herbs[i].herbData)
            {
                this.herbs.Remove(this.herbs[i]);
            }
        }
        
    }

    public void updateData(HerbData oldData, HerbData newData)
    {
        if(newData.herbName == "")
        {
            Package.Instance.delHerb(oldData);
            return;
        }
        for (int i = 0; i < herbs.Count; i++)
        {
            if (oldData == this.herbs[i].herbData)
            {
                this.herbs[i].herbData = newData;
                return;
            }
        }
        Package.Instance.addHerb(new Herb(newData));
    }

    
}
