using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : Singleton<EyesController>
{
    public float MovementSpeed = 4f;
    public Transform SpawnPoint;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Glow.Instance.transform.position - transform.position;

        transform.position += Time.deltaTime * MovementSpeed * transform.up;

        transform.up = Vector2.Lerp(transform.up, direction, Time.deltaTime * 3);
    }

    public void Reborn()
    {
        transform.position = SpawnPoint.position;
    }
}
