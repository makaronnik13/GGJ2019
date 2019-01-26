using UnityEngine;

public class FireFlyHomeMovement : MonoBehaviour
{
	public float MovementSpeed, RotationSpeed;
	private Vector3 DirectionPoint;

	void Start()
	{
		DirectionPoint = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		//transform.Translate(transform.up*Time.deltaTime*MovementSpeed);
		if (Input.GetMouseButtonDown(0))
		{
			DirectionPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		Vector2 direction = new Vector2(DirectionPoint.x - transform.position.x, DirectionPoint.y - transform.position.y);
		transform.position += Time.deltaTime * MovementSpeed * transform.up;
		transform.up = Vector2.Lerp(transform.up, direction, Time.deltaTime * RotationSpeed);
	}
}
