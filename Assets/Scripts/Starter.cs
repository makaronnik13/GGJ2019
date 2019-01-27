using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public string Title;
    public AudioClip Run1Clip;
    // Start is called before the first frame update
    void Start()
    {
        Fader.Instance.OpenScene("Run1", 2, 1, Title, null, Run1Clip);   
    }
}
