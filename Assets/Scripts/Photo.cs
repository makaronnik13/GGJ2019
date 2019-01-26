using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{

    bool _open = false;

    public void OpenClose()
    {
        _open = !_open;

        GetComponent<Animator>().SetBool("Open", _open);
    }

    private void OnMouseDown()
    {
        if (_open)
        {
            GetComponent<Animator>().SetBool("Open", false);
        }
    }
}
