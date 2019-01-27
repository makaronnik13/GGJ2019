using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    public Animator Wings;
    public SpriteRenderer Glow;
    public Transform Mask;
    public GameObject Eyes;
    private float _life = 0;
    private bool standingUp = false;

    private void OnMouseDown()
    {
        if (!standingUp && _life<1)
        {
            StartCoroutine(StandUp(0.05f));
        }
    }

    private IEnumerator StandUp(float v)
    {
        Wings.GetComponent<Animator>().SetTrigger("OneShot");
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        standingUp = true;
        float t = 0;
        while (t<0.5)
        {
            _life += v*t;
            Glow.color = Color.Lerp(Glow.color, Color.yellow, _life/10f);
            Mask.localScale = Vector3.Lerp(20*Vector3.one, 50*Vector3.one, _life);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        if (_life>=1)
        {
            GetComponent<FireflyController>().enabled = true;
           // Transform parent = Eyes.transform.parent;
            Eyes.transform.parent.parent.GetComponent<Animator>().SetTrigger("Off");
            Eyes.transform.SetParent(Eyes.GetComponent<EyesController>().SpawnPoint);
            Eyes.transform.localPosition = Vector3.zero;
            Eyes.GetComponent<Animator>().enabled = true;
            Eyes.GetComponent<EyesController>().enabled = true;
            Wings.GetComponent<Animator>().SetBool("Fly", true);
        }
        standingUp = false;
    }


}
