using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
	public bool ifDead;
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Enemy5;
	public GameObject Spikes;
	public GameObject tree1;
	public GameObject bush1;
	public GameObject tree2;
	public GameObject bush2;
	public GameObject tree3;
	public GameObject bush3;
	public GameObject tree4;
	public GameObject bush4;
	public GameObject coin;
	public bool hasStarted;
	Playerscript pScript;
	int treeChance;
	int EnemyType;
	int EnemyChance;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("treeSpawner",1,1);
		pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hasStarted==true)
		{
			InvokeRepeating("Spawner",1,1f);
			hasStarted=false;
			if(ifDead==true)
			{
				CancelInvoke("Spawner");
				CancelInvoke("treeSpawner");
			}
		}
	}

	void Spawner()
	{
		EnemyChance = Random.Range(0,2);
		EnemyType = Random.Range (0,8);
		if(ifDead==false)
		{
			if(EnemyChance==1)
			{
				if(EnemyType==1)
				{
					Instantiate(Enemy1,new Vector3(1.7f,-0.55f,-0.1f),Quaternion.identity);
				}
				else if(EnemyType==2)
				{
					Instantiate(Enemy2,new Vector3(1.7f,-0.538f,-0.1f),Quaternion.identity);
				}
				else if(EnemyType==3)
				{
					Instantiate(Enemy3,new Vector3(1.7f,-0.53f,-0.1f),Quaternion.identity);
				}
				else if(EnemyType==4)
				{
					Instantiate(Enemy4,new Vector3(1.7f,-0.547f,-0.1f),Quaternion.identity);
				}
				else if(EnemyType==5)
				{
					Instantiate(Enemy5,new Vector3(1.7f,-0.5f,-0.1f),Quaternion.identity);
				}
				else if(EnemyType==6)
				{
					Instantiate(Spikes,new Vector3(1.7f,-0.54f,-0.1f),Quaternion.identity);
				}
				else if(EnemyType==7)
				{
					Instantiate(coin,new Vector3(1.7f,-0.54f,-0.1f),Quaternion.identity);
				}
			}
		}
	}

	void treeSpawner()
	{
		treeChance = Random.Range(0,3);
		if(ifDead==false)
		{
			if(treeChance == 1)
			{
				if(pScript.levelno==1)
				{
					Instantiate(tree1,new Vector3(1.7f,-0.45f,-0.08f),Quaternion.identity);
				}
				else if(pScript.levelno==2)
				{
					Instantiate(tree2,new Vector3(1.7f,-0.459f,-0.08f),Quaternion.identity);
				}
				else if(pScript.levelno==3)
				{
					Instantiate(tree3,new Vector3(1.7f,-0.45f,-0.08f),Quaternion.identity);
				}
				else if(pScript.levelno==4)
				{
					Instantiate(tree4,new Vector3(1.7f,-0.45f,-0.08f),Quaternion.identity);
				}
			}
			else if(treeChance == 2)
			{
				if(pScript.levelno==1)
				{
				Instantiate(bush1,new Vector3(1.7f,-0.54f,-0.08f),Quaternion.identity);
				}
				else if(pScript.levelno==2)
				{
					Instantiate(bush2,new Vector3(1.7f,-0.54f,-0.08f),Quaternion.identity);
				}
				else if(pScript.levelno==3)
				{
					Instantiate(bush3,new Vector3(1.7f,-0.539f,-0.08f),Quaternion.identity);
				}
				else if(pScript.levelno==4)
				{
					Instantiate(bush4,new Vector3(1.7f,-0.531f,-0.08f),Quaternion.identity);
				}
			}
		}
	}
}
