using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : Singleton<GlobalGameManager>
{
    private SaveTrigger SavePoint;

    // Start is called before the first frame update
    void Start()
    {
        Glow.Instance.OnDeath += Die;
    }

    private void Die()
    {
        Debug.Log("Die");
        Glow.Instance.transform.position = SavePoint.transform.position;
        Glow.Instance.transform.rotation = Quaternion.Euler(Vector3.right);
        SavePoint.Zone.SetActive(true);
    }

    public void SetLastSavePoint(SaveTrigger  sp)
    {
        SavePoint = sp;
    }
}
