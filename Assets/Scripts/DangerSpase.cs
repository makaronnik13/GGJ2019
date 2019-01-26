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
        Glow.Instance.SetDanger(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Glow.Instance.SetDanger(false);
    }
}
