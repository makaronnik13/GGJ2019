using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : Singleton<GlobalGameManager>
{

    // Start is called before the first frame update
    void Start()
    {
        Glow.Instance.OnDeath += Die;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Die()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}
