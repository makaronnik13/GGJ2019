using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public SpriteRenderer WhiteEdge;
    private Color _transparent = new Color(1,1,1,0);

    public float MaxDist = 10;

    // Update is called once per frame
    void Update()
    {
        if (Glow.Instance == null)
        {
            return;
        }
        float dist = Vector3.Distance(Glow.Instance.transform.position, transform.position);

        dist = Mathf.Min(dist, MaxDist) / MaxDist;

        WhiteEdge.color = Color.Lerp(Color.white, _transparent, dist);
    }
}
