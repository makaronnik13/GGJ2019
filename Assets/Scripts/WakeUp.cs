using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    public SpriteRenderer Glow;
    public Transform Mask;
    public GameObject Eyes;
    private float _life = 0;
    private bool standingUp = false;

    private void OnMouseDown()
    {
        if (!standingUp)
        {
            StartCoroutine(StandUp(0.05f));
        }
    }

    private IEnumerator StandUp(float v)
    {
        standingUp = true;
        float t = 0;
        while (t<0.5)
        {
            _life += v*t;
            Glow.color = Color.Lerp(Glow.color, Color.yellow, _life/10f);
            Mask.localScale = Vector3.Lerp(20*Vector3.one, 75*Vector3.one, _life);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        if (_life>=1)
        {
            GetComponent<FireflyController>().enabled = true;
            Eyes.SetActive(true);
        }
        standingUp = false;
    }


}
