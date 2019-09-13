using UnityEngine;
using System.Collections;

public class Playerscript : MonoBehaviour {
	float ColliderSpeed = 0.01f;
	float seconds;
	enemySpawn eScript;
	FloorMovement fScript;
	public BoxCollider2D bC2D;
	public bool trigger;
	public bool firsttime;
	bool splashdestroyed;
	public TextMesh timeText;
	Animator anim;
	public int levelno=1;
	public GameObject splash;
	public ParticleSystem ps;
	public AudioSource jump;
	public AudioSource squash;
	public AudioSource coin;
	public AudioSource punch;
	public GameObject fist;
	public bool isPunching;
	public bool isDead;
	public GameObject floorTiles1;
	public GameObject floorTiles2;
	public GameObject floorTiles3;
	public GameObject floorTiles4;
	public GameObject Background;
	public Sprite l2;
	public Sprite l3;
	public Sprite l4;
	SpriteRenderer sr;
	bool changingLevel;
	//inside class
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	// Use this for initialization
	void Start () 
	{
		Instantiate(floorTiles1,new Vector3(2.024f,-1.026f,0),Quaternion.identity);
		sr = Background.GetComponent<SpriteRenderer>();
		fScript = GameObject.FindGameObjectWithTag("floor").GetComponent<FloorMovement>();
		eScript = GameObject.FindGameObjectWithTag("spawner").GetComponent<enemySpawn>();
		Screen.SetResolution(640, 480, true);
		anim = transform.gameObject.GetComponent<Animator>();
		levelno=1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeLevel();
		Punch();
		StartTimer();
		if(bC2D.center.y>=-0.03f)
		{
			trigger = false;
		}

		if(trigger==true)
		{
			bC2D.center += new Vector2(0,ColliderSpeed);
		}

		else
		{
			if(bC2D.center.y>-0.26f && trigger ==false)
			{
				bC2D.center -= new Vector2(0,ColliderSpeed);
			}
		}

		if(firsttime==true)
		{
			if(splashdestroyed==false)
			{
				splash.transform.position += new Vector3(0,0.1f,0);
			}
		}

		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();
				
				if (!(secondPressPos == firstPressPos))
				{
					if (Mathf.Abs(currentSwipe.x) > Mathf.Abs(currentSwipe.y))
					{
						if (currentSwipe.x < 0)
						{
							    
						}
						else
						{
							if(anim.GetBool("IsJumping")==false&&fist.transform.position.x<=-0.07f)
							{
								if(anim.GetBool("IsDead")==false)
								{
									isPunching=true;  
									punch.Play ();
								}

							}
						}
					}
					else
					{
						if (currentSwipe.y < 0)
						{
							// Swipe Down
						}
						else
						{
							if(bC2D.center.y<=-0.2f && anim.GetBool("IsDead")==false)
							{
								StartCoroutine(AnimWait());
								trigger= true;
								audio.Play ();
								if(firsttime==false)
								{
									eScript.hasStarted=true;
									firsttime=true;
									StartCoroutine(SplashScreen());
								}
							}
						}
					}
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//spider
		if (coll.gameObject.tag == "enemy") 
		{
			PlayerPrefs.SetInt("CurrScore",(int)seconds);
			if(PlayerPrefs.GetInt("CurrScore")>= PlayerPrefs.GetInt("HighScore"))
			{
				PlayerPrefs.SetInt("HighScore",(int)seconds);
			}
			StartCoroutine(Die());
		}
		if (coll.gameObject.tag == "coin") 
		{
			coin.Play ();
			seconds += 5;
			coll.gameObject.SendMessage("SD");
		}
	}

	void Punch()
	{
		if(isPunching==true)
		{
			fist.transform.position+=new Vector3(1.8f*Time.deltaTime,0,0);
		}
		else
		{
			if(fist.transform.position.x>=-0.07f)
			{
				fist.transform.position+=new Vector3(-1.8f*Time.deltaTime,0,0);
			}
		}
		if(fist.transform.position.x>=0.18f)
		{
			isPunching=false;
		}
	}

	void ChangeLevel()
	{

			if(seconds>=300)
			{
				if(levelno==3)
				{
					levelno=4;
					Destroy(GameObject.FindGameObjectWithTag("floor"));
					Instantiate(floorTiles4,new Vector3(2.024f,-1.0f,0),Quaternion.identity);
					sr.sprite = l4;
				}
			}
			else if(seconds>=150)
			{
				if(levelno==2)
				{
					levelno=3;
					Destroy(GameObject.FindGameObjectWithTag("floor"));
					Instantiate(floorTiles3,new Vector3(2.024f,-0.987f,0),Quaternion.identity);
					sr.sprite = l3;
				}
			}
			else if(seconds>=50)
			{
				if(levelno==1)
				{
					levelno=2;
					Destroy(GameObject.FindGameObjectWithTag("floor"));
					Instantiate(floorTiles2,new Vector3(2.024f,-1.026f,0),Quaternion.identity);
					sr.sprite = l2;
				}
			}
	}

	IEnumerator AnimWait()
	{
		fist.transform.renderer.enabled=false;
		fist.transform.collider2D.enabled=false;
		anim.SetBool ("IsJumping", true);
		yield return new WaitForSeconds (0.7f);
		fist.transform.collider2D.enabled=true;
		fist.transform.renderer.enabled=true;
		anim.SetBool ("IsJumping", false);
	}

	IEnumerator SplashScreen()
	{
		yield return new WaitForSeconds(3);
		splashdestroyed=true;
		Destroy(splash);
	}

	IEnumerator Die()
	{
		fScript = GameObject.FindGameObjectWithTag("floor").GetComponent<FloorMovement>();
		ps.Play();
		squash.Play();
		isDead = true;
		anim.SetBool("IsDead",true);
		fScript.ifDead=true;
		eScript.ifDead=true;
		yield return new WaitForSeconds(3);
		ps.Stop();
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel("GameOver");
	}

	void StartTimer()
	{
		if(firsttime==true && isDead==false)
		{
			seconds += Time.deltaTime;
			timeText.text = ""+(int)seconds;
		}
	}
}
