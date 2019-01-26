using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public GameObject Scene;

    private void Start()
    {
        Scene.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene.SetActive(true);
    }
}
