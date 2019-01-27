using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
	public UnityEvent OnActivate;
    public Transform Visual;

	void OnMouseDown()
	{
		OnActivate.Invoke();
       // FireFlyClickController.Instance.Item = this;
        //StartCoroutine(PingItem());
	}

    private IEnumerator PingItem()
    {
        float t = 0;
        while (t<0.3f)
        {
            Visual.transform.localScale = Vector3.one * Mathf.Lerp(0.9f, 1f, t/0.3f);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
		Activate();
    }

    public void Activate()
    {
        Debug.Log("Activate");
        OnActivate.Invoke();
    }
}
