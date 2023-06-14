using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldControl : MonoBehaviour
{
    private static HandHeldControl instance;
    public static HandHeldControl Instance
    {
        get { return instance; }
    }

    public GameObject HandheldObj;

}
