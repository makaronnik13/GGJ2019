using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    public GameObject Zone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GlobalGameManager.Instance.SetLastSavePoint(this);
    }
}
