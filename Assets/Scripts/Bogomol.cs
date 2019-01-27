using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bogomol : MonoBehaviour
{
    public Animator anim;
    public LoadSceneTrigger loader;

    private int _clicks;

    public void Click()
    {
        anim.SetTrigger("Next");
    }

   public void Om()
   {
        GetComponent<AudioSource>().PlayOneShot( GetComponent<AudioSource>().clip);
        anim.SetTrigger("Next");
   }

    public void EndScene()
    {
        loader.Load();
    }
}
