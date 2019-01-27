using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSpase : MonoBehaviour
{
  
    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    
    private void OnTriggerEnter2D (Collider2D other)
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        Glow.Instance.TurnOff();
        GlobalGameManager.Instance.Die();
    }

}
