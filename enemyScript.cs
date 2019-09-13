using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
	Playerscript pScript;
	bool oneTime;
	// Use this for initialization
	void Start () 
	{
		pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
		StartCoroutine(SelfDestruct());
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(oneTime==false)
		{
			if(pScript.isDead==true)
			{
				StartCoroutine(DieEnum());
				oneTime=true;
			}
			else
			{
				if(pScript.levelno==1)
				{
					transform.position-=new Vector3(0.024f,0,0);
				}
				else if(pScript.levelno==2)
				{
					transform.position-=new Vector3(0.027f,0,0);
				}
				else if(pScript.levelno==3)
				{
					transform.position-=new Vector3(0.03f,0,0);
				}
				else if(pScript.levelno==4)
				{
					transform.position-=new Vector3(0.034f,0,0);
				}
			}
		}
	}

	public void Die()
	{
		StartCoroutine(DieEnum());
	}

	IEnumerator DieEnum()
	{
		audio.Play();
		transform.rigidbody2D.fixedAngle=false;
		transform.rigidbody2D.isKinematic=false;
		transform.rigidbody2D.gravityScale=1;
		rigidbody2D.angularVelocity = Random.Range(200,500);
		rigidbody2D.AddForce(new Vector2(Random.Range(80,120),Random.Range(200,250)));
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}

	IEnumerator SelfDestruct()
	{
		yield return new WaitForSeconds(15);
		Destroy(gameObject);
	}
}
