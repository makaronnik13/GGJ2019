using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("Fly", true);   
    }
}
