using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{

    private static Glow _instance;
    public static Glow Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Glow>();
            }
            return _instance;
        }
    }

    public void TurnOff()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
            GameObject.Destroy(transform.GetChild(0).gameObject);
        }
    }
}
