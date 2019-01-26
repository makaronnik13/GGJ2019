﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : Singleton<Glow>
{
    public AnimationCurve FadeOutCurve;
    public Transform Mask;
    public SpriteRenderer GlowRenderer;
    public Color GlowColor;
    private Color NotGlowColor;
    public float CanBeInDanger = 0.3f;


    public Action OnDeath = () => { };

    public float _life = 1f;
    private float Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
            GlowRenderer.color = Color.Lerp(NotGlowColor, GlowColor, _life);
            Mask.localScale = Vector3.one * Mathf.Lerp(1f,30f,_life);

            if (_life<=0)
            {
                OnDeath();
            }
        }
    }

    private float _timeInDanger = 0;
    public bool _inDangerZone;

    private void Start()
    {
        NotGlowColor = new Color(GlowColor.r, GlowColor.g, GlowColor.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_inDangerZone)
        {
            _timeInDanger += Time.deltaTime;
            Life = FadeOutCurve.Evaluate(_timeInDanger);

        }
        else
        {
            _timeInDanger = 0;
            Life = Mathf.Lerp(Life, 1f, Time.deltaTime * 2f);
           
        }
    }

    public void SetDanger(bool v)
    {
        _inDangerZone = v;
    }

}
