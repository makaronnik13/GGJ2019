using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchScript : MonoBehaviour
{

	public void OpenClose()
	{
        GetComponent<Animator>().SetBool("Open", !GetComponent<Animator>().GetBool("Open"));
	}
}
