using UnityEngine;
using System.Collections;

public class pauseScript : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite play;
	public Sprite pause;
	Playerscript pScript;
	public GameObject pausemenu;
	bool isPaused;
	// Use this for initialization
	void Start () 
	{
		pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		pausemenu.renderer.enabled=false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if(pScript.firsttime==true)
		{
			if(isPaused==false)
			{
				pausemenu.renderer.enabled=true;
				Time.timeScale = 0;
				sr.sprite = play;
				isPaused=true;
			}
			else
			{
				pausemenu.renderer.enabled=false;
				Time.timeScale = 1;
				sr.sprite = pause;
				isPaused=false;
			}
		}
	}
}
