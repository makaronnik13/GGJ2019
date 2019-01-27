using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyBody : MonoBehaviour
{
    public float speed = 3f;
    private Quaternion _globalRotation;
    // Update is called once per frame

    private void Start()
    {
        _globalRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _globalRotation, Time.deltaTime*speed);
    }
}
