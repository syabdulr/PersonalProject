using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems : MonoBehaviour
{
    //this script will be a static instance
    //where you can pull assets and variables from

    public static Systems instance;
    //create any public fields here to access them in others scripts

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
}
