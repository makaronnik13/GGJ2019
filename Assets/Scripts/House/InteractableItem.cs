using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
	public UnityEvent OnActivate;

	private bool IsReady = false;

    // Update is called once per frame
    void Update()
    {

    }

	void OnMouseDown()
	{
		IsReady = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (IsReady || col.transform.tag == "Player")
		{
			IsReady = false;
			OnActivate.Invoke();
		}
	}
}
