using UnityEngine;
using System.Collections;

public class bgmusicScript : MonoBehaviour {
	public AudioSource music1, music2, music3, music4;
	Playerscript pScript;
	int playOnce=0;
	public GameObject fasterText;
	// Use this for initialization
	void Start () 
	{
		pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
		music1.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pScript.levelno==2)
		{
			if(playOnce==0)
			{
				music1.Stop();
				music3.Play ();
				Instantiate(fasterText,new Vector3(-1f,0.9f,0),Quaternion.identity);
				playOnce+=1;
			}
		}
		else if(pScript.levelno==3)
		{
			if(playOnce==1)
			{
				music3.Stop();
				music2.Play ();
				Instantiate(fasterText,new Vector3(-1f,0.9f,0),Quaternion.identity);
				playOnce+=1;
			}
		}
		else if(pScript.levelno==4)
		{
			if(playOnce==2)
			{
				music2.Stop();
				music4.Play ();
				Instantiate(fasterText,new Vector3(-1f,0.9f,0),Quaternion.identity);
				playOnce+=1;
			}
		}
	}
}
