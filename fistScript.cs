using UnityEngine;
using System.Collections;

public class fistScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//spider
		if (coll.gameObject.tag == "enemy") 
		{
			coll.gameObject.SendMessage("Die");
		}
	}
}
