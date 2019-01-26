using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    public GameObject Scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene.SetActive(false);
    }
}
