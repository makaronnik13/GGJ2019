using UnityEngine;

public class DoorScript : MonoBehaviour
{
	enum DoorMoving { None, Up, Down }
	enum DoorState { Closed, Opened }

	DoorMoving moving;
	DoorState state;
	public Transform Closed;
	public Transform Opened;
	public float MovementSpeed;
	
    void Start()
    {
		moving = DoorMoving.None;
		state = DoorState.Closed;
    }

    // Update is called once per frame
    void Update()
	{
		if (moving == DoorMoving.Up)
		{
			if (transform.position.y > Opened.transform.position.y)
			{
				moving = DoorMoving.None;
			}
			transform.position += Time.deltaTime * MovementSpeed * transform.up;
		}
		if (moving == DoorMoving.Down)
		{
			if (transform.position.y < Closed.transform.position.y)
			{
				moving = DoorMoving.None;
			}
			transform.position -= Time.deltaTime * MovementSpeed * transform.up;
		}
	}

	public void OpenClose()
	{
		if (state == DoorState.Closed)
		{
			state = DoorState.Opened;
			moving = DoorMoving.Up;
		}
		else
		{
			state = DoorState.Closed;
			moving = DoorMoving.Down;
		}
	}
}
