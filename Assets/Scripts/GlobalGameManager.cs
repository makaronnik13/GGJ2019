using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
    public AudioClip Chew;
    

    private static GlobalGameManager _instance;
    public static GlobalGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalGameManager>();
            }
            return _instance;
        }
    }


    public void Die()
    {
        Fader.Instance.OpenScene(SceneManager.GetActiveScene().name, 0.5f, 3, "", null, Fader.Instance.GetComponent<AudioSource>().clip);
    }
}
