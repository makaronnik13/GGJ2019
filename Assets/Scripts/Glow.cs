using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public AnimationCurve FadeOutCurve;
    public SpriteRenderer GlowRenderer;
    public Color GlowColor;
    private Color NotGlowColor;
    public float CanBeInDanger = 0.3f;

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

    public Action OnDeath = () => { };


    public void SetDanger(bool v)
    {

        if (v)
        {
            OnDeath();
        }
       
    }

}
