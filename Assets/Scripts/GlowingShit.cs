using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingShit : MonoBehaviour
{
    private SpriteRenderer rend;
    private Color col, col2;
    public float rate = 1;
    private float diff;

    private void Start()
    {
        diff = Random.Range(0, 30f);
        rend = GetComponent<SpriteRenderer>();
        col = rend.color;
        col2 = new Color(col.r, col.g, col.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rend.color = Color.Lerp(col, col2,  Mathf.Sin(Time.time*rate+diff)+0.3f);
    }
}
