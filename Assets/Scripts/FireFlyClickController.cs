using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyClickController : MonoBehaviour
{
    private Vector3 aim = Vector3.zero;
    public float MovementSpeed;

    public InteractableItem Item;

    private static FireFlyClickController _instance;
    public float RotationSpeed;

    public static FireFlyClickController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<FireFlyClickController>();
            }
            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            aim = mousePosition;
            //Item = null;
        }

        if (aim!=Vector3.zero)
        {
            Vector2 direction = new Vector2(aim.x - transform.position.x, aim.y - transform.position.y);

            transform.Translate(Time.deltaTime * MovementSpeed * transform.up);

            transform.up = Vector2.Lerp(transform.up, direction, Time.deltaTime * RotationSpeed);

            if (Vector2.Distance(aim, transform.position)<0.2f)
            {
                aim = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        aim = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableItem>() == Item && Item!=null)
        {
            Item.Activate();
            Item = null;
            aim = Vector3.zero;
        }

    }
}
