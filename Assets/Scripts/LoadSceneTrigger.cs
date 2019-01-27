using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    public string SceneName;
    public string Title;
    public AudioClip nextClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fader.Instance.OpenScene(SceneName, 2, 3, Title, null, nextClip);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Fader.Instance.OpenScene(SceneName, 2, 3, Title, null, nextClip);
    }
}
