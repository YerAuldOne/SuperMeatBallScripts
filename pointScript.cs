using UnityEngine;
using System.Collections;

public class pointScript : MonoBehaviour {
	Color color;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position+= new Vector3(0,0.02f,0);
		renderer.material.color -= new Color(0,0,0,0.03f);
	}

	IEnumerator sd()
	{
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
}
