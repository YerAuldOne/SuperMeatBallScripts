using UnityEngine;
using System.Collections;

public class FloorMovement : MonoBehaviour 
{
	public bool ifDead;
	Playerscript pScript;
	// Use this for initialization
	void Start () 
	{
		pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(ifDead==false)
		{
			transform.position-=new Vector3(0.02f,0,0);

			if(transform.position.x <= -1.75f)
			{
				if(pScript.levelno<=2)
				{
					transform.position = new Vector3(1.91f,-1.026f,0);
				}
				else if(pScript.levelno==3)
				{
					transform.position = new Vector3(1.91f,-0.987f,0);
				}
				else if(pScript.levelno==4)
				{
					transform.position = new Vector3(1.91f,-1.0f,0);
				}
			}
		}
	}
}
