using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {
	Playerscript pScript;
	public GameObject pointsText;
	// Use this for initialization
	void Start () 
	{
		pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
		StartCoroutine(SelfDestruct());
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	
		if(pScript.isDead==false)
		{
			transform.position-=new Vector3(0.02f,0,0);
		}
	}

	void SD()
	{
		Instantiate(pointsText,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	IEnumerator SelfDestruct()
	{
		yield return new WaitForSeconds(15);
		Destroy(gameObject);
	}


}
