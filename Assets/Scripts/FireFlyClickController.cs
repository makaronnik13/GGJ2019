using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyClickController : MonoBehaviour
{
    private Vector3 aim = Vector3.zero;
    public float MovementSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            aim = mousePosition;
        }

        if (aim!=Vector3.zero)
        {
            Vector2 direction = new Vector2(aim.x - transform.position.x, aim.y - transform.position.y);

            transform.position += Time.deltaTime * MovementSpeed * transform.up;

            transform.up =  direction;

            if (Vector2.Distance(aim, transform.position)<0.04f)
            {
                aim = Vector3.zero;
            }
        }
    }
}
