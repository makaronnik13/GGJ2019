using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchScript : MonoBehaviour
{
	enum HatchMoving { None, Up, Down }
	enum HatchState { Closed, Opened }

	public Transform RotationPoint;
	public float RotationSpeed;
	public float Debug;
	private HatchMoving moving;
	private HatchState state;

    // Start is called before the first frame update
    void Start()
    {
		moving = HatchMoving.None;
		state = HatchState.Closed;
    }

    // Update is called once per frame
    void Update()
	{
		Debug = transform.rotation.z;
		if (moving == HatchMoving.Up)
		{
			if (transform.rotation.z < -0.45)
			{
				moving = HatchMoving.None;
			}
			transform.RotateAround(RotationPoint.transform.position, Vector3.back, RotationSpeed * Time.deltaTime);
		}
		if (moving == HatchMoving.Down)
		{
			if (transform.rotation.z > 0)
			{
				moving = HatchMoving.None;
			}
			transform.RotateAround(RotationPoint.transform.position, Vector3.forward, RotationSpeed * Time.deltaTime);
		}
	}

	public void OpenClose()
	{
		if (state == HatchState.Closed)
		{
			state = HatchState.Opened;
			moving = HatchMoving.Up;
		}
		else
		{
			state = HatchState.Closed;
			moving = HatchMoving.Down;
		}
	}
}
