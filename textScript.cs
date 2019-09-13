using UnityEngine;
using System.Collections;

public class textScript : MonoBehaviour {
	Color color;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(Texting());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	IEnumerator Texting()
	{
		renderer.material.color = new Color(0,0,0,0.0f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,100f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,0.0f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,100f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,0.0f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,100f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,0f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,100f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,0.0f);
		yield return new WaitForSeconds(0.2f);
		renderer.material.color = new Color(0,0,0,100f);
		Destroy(gameObject);
	}
}
