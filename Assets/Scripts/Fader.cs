using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Image img;
    public TMPro.TextMeshProUGUI Text;
    public AudioSource Source;

    private bool _fading = false;
    private static Fader _instance;
    public static Fader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Fader>();
            }
            return _instance;
        }
    }

    private AudioClip nextClip;

    public Action OnSceneLoaded = () => { };

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(nextClip);
        if (nextClip)
        {
            Source.clip = nextClip;
            Source.Play();
        }

        StartCoroutine(FadeIn(2));

    }

    private IEnumerator FadeIn(int v)
    {
        float time = 0;
        while (time<v)
        {
            time += Time.deltaTime;
            Source.volume = Mathf.Lerp(0,1,time/v);
            Text.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), time*2 / v);
            img.color = Color.Lerp(Color.black, new Color(0, 0, 0, 0), time / v);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _fading = false;
        OnSceneLoaded();
    }

    public void OpenScene(string scene, float timeOfFade, float timeForReload, string text = "", AudioClip sound = null, AudioClip nextMusic = null)
    {
        if (_fading)
        {
            return;
        }
        _fading = true;
        EyesController eye = FindObjectOfType<EyesController>();
        if (eye)
        {
            eye.enabled = false;
        }
        StartCoroutine(FadeOut(scene, timeOfFade, timeForReload, text, sound, nextMusic));
    }

    private IEnumerator FadeOut(string scene, float timeOfFade, float timeForReload, string text, AudioClip sound, AudioClip nextClip)
    {
        if (sound)
        {
            Source.volume = 1;
            Source.PlayOneShot(sound);
        }

        if (nextClip!=null)
        {
            this.nextClip = nextClip;
        }
        Text.text = text;
        float time = 0;
        do
        {
            float coef = time / timeOfFade;

            if (text != "")
            {
                Text.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, coef);
                Text.transform.localScale = Vector3.one * Mathf.Lerp(0.95f, 1.05f, coef);
            }
            img.color = Color.Lerp(Color.black * 0, Color.black, coef);
            if (!sound)
            {
                Source.volume = Mathf.Lerp(1, 0, coef);
            }
            
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (time / timeOfFade < 1f);
       
        yield return new WaitForSeconds(timeForReload);
      
        Source.Stop();
        SceneManager.LoadScene(scene);
    }
}
