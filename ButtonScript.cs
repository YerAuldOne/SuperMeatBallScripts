using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public TextMesh highscore;
	public TextMesh currscore;
	// Use this for initialization
	void Start () 
	{
		highscore.text = ""+PlayerPrefs.GetInt("HighScore");
		currscore.text = ""+PlayerPrefs.GetInt("CurrScore");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() 
	{
		Application.LoadLevel("Runner");
	}
}
