using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyController : MonoBehaviour
{
    public enum FlyMode
    {
        Calm,
        Run
    }

    public FlyMode Mode = FlyMode.Calm;
    public float MovementSpeed, RotationSpeed;

    // Update is called once per frame
    void Update()
    {
       
        //transform.Translate(transform.up*Time.deltaTime*MovementSpeed);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        float distanceMultiplyer = 1;

        if (Mode == FlyMode.Calm)
        {
            float dist = Vector3.Distance(transform.position, mousePosition);
            distanceMultiplyer = 1;
        }

        transform.position += Time.deltaTime * MovementSpeed * transform.up * distanceMultiplyer;

        transform.up = Vector2.Lerp(transform.up, direction, Time.deltaTime*RotationSpeed);   
    }
}
