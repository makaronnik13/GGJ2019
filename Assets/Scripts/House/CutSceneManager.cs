using UnityEngine;

	public enum CutSceneState
	{
		Start,
		BugClicked,
		VedroClicked,
		ShkafClicked,
		LetterClicked,
		Finish
	}
public class CutSceneManager : MonoBehaviour
{
	public CutSceneState state;

	public Sprite BugPic2;
	public SpriteRenderer BugPic;
	public Transform Vedro;
	public Transform Letter;
	public Transform BubbleOgurec;
	public Transform BubbleLetter;
	public Animator Shkaf;

	// Start is called before the first frame update
	void Start()
    {
		state = CutSceneState.Start;
    }

    // Update is called once per frame
    void Update()
	{
		if (state == CutSceneState.VedroClicked)
		{
			Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			a.Set(a.x, a.y, Vedro.transform.position.z);
			Vedro.transform.position = a;
		}
		if (state == CutSceneState.LetterClicked)
		{
			Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			a.Set(a.x, a.y, Letter.transform.position.z);
			Letter.transform.position = a;
		}
	}

	public void TriggerBug()
	{
		if (state == CutSceneState.Start)
		{
			state = CutSceneState.BugClicked;
			// всплывает бабл с огруцами
			var color = BubbleOgurec.GetComponent<SpriteRenderer>().color;
			BubbleOgurec.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 255);
		}
		if (state == CutSceneState.LetterClicked)
		{
			state = CutSceneState.Finish;
			Letter.transform.position = new Vector3(-123123, 312, 1231);
			BugPic.sprite = BugPic2;
			var color = BubbleLetter.GetComponent<SpriteRenderer>().color;
			BubbleLetter.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
			GetComponent<Animator>().SetTrigger("Next");
		}
	}

	public void TriggerVedro()
	{
		if (state == CutSceneState.BugClicked)
		{
			state = CutSceneState.VedroClicked;
			var color = BubbleOgurec.GetComponent<SpriteRenderer>().color;
			BubbleOgurec.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
			Vedro.transform.localScale = new Vector3(0.5f, 0.5f, 1);
		}
	}

	public void TriggerShkaf()
	{
		if (state == CutSceneState.VedroClicked)
		{
			Vedro.transform.position = new Vector3(-123123, 312, 1231);
			state = CutSceneState.ShkafClicked;
			Shkaf.SetTrigger("Click");
			var color = BubbleLetter.GetComponent<SpriteRenderer>().color;
			BubbleLetter.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 255);
		}
	}

	public void TriggerLetter()
	{
		if (state == CutSceneState.ShkafClicked)
		{
			state = CutSceneState.LetterClicked;
		}
	}

	public void Fin()
	{
		GetComponent<LoadSceneTrigger>().Load();
	}
}
