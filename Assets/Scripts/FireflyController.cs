using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyController : MonoBehaviour
{
    public float MovementSpeed, RotationSpeed;

    // Update is called once per frame
    void Update()
    {
       
        //transform.Translate(transform.up*Time.deltaTime*MovementSpeed);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.position += Time.deltaTime * MovementSpeed * transform.up;

        transform.up = Vector2.Lerp(transform.up, direction, Time.deltaTime*RotationSpeed);   
    }
}
