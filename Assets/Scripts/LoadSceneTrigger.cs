using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadSceneTrigger : MonoBehaviour
{
    public string SceneName;
    public string Title;
    public AudioClip nextClip;
    public UnityEvent onEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fader.Instance.OpenScene(SceneName, 2, 3, Title, null, nextClip);
        onEnter.Invoke();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Fader.Instance.OpenScene(SceneName, 2, 3, Title, null, nextClip);
    }
}
