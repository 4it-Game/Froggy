using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private bool onGround;
	private float jumpPressure;
	private float minJump;
	private float maxJumpPressure;
	public Image powerImage;

	public Animator playerAnimator;

	public AudioClip jump;
	public AudioClip ground;

	public float targetTime = 10.0f;
	public bool isLevelComplete;

	//reference to star images
	private GameObject star1;
	private GameObject star2;
	private GameObject star3;

	//reference to next button
	private GameObject buttonNext;
	//timer text reference
	public Text timerText;
	//time passed since start of level
	protected float totalTime = 0f;

	private Rigidbody rb;

	private Animator anim;

	// Use this for initialization
	void Start () {

		star1 = GameObject.Find("Star1");
		star2 = GameObject.Find("Star2");
		star3 = GameObject.Find("Star3");

		buttonNext = GameObject.Find("NextLevel");

		isLevelComplete = false;

		onGround = true;
		jumpPressure = 0f;
		minJump = 3f;
		maxJumpPressure = 10f;
		rb = GetComponent<Rigidbody> ();

		powerImage.fillAmount = 0;

		anim = GetComponent<Animator> ();

		//disable the image component of all the star images
		star1.GetComponent<Image>().enabled = false;
		star2.GetComponent<Image>().enabled = false;
		star3.GetComponent<Image>().enabled = false;
		//disable the next button
		buttonNext.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		powerImage.fillAmount = jumpPressure / 10f;


		if (jumpPressure == 10) {
			jumpPressure = 0;
		}

		if (onGround) {
			//if (Input.GetButton ("Jump")) 
			if (Input.GetMouseButton(0))	
			{
				
				if (jumpPressure < maxJumpPressure) {
					jumpPressure += Time.deltaTime * 10f;
				} else {
					jumpPressure = maxJumpPressure;
				}
				anim.SetFloat ("jumpPres",jumpPressure + minJump);
				anim.speed = 0.1f + (jumpPressure / 2f);
				AudioManager.instance.PlaySound (jump, transform.position);
				Debug.Log (jumpPressure);
			} 
			else 
			{
				if (jumpPressure > 0f) {
					playerAnimator.SetTrigger ("isJumping");
					jumpPressure = jumpPressure + minJump;
					rb.velocity = new Vector3 (jumpPressure * 0.8f , jumpPressure , 0f);
					jumpPressure = 0f;
					onGround = false;
					anim.SetFloat ("jumpPres",0f);
					anim.SetBool ("onGround",onGround);
					anim.speed = 1f;
				}
			}
		}

		if (transform.position.y < 7.50f) {
			playerAnimator.SetTrigger ("nearlanding");
		}

		if (!isLevelComplete) {
			//update the timer value
			totalTime += Time.deltaTime;
			//display the timer value 
			timerText.text = "TIME: " + totalTime.ToString ();
			Debug.Log (totalTime);
		}
	}


	void OnCollisionEnter(Collision col){
		if(col.gameObject.CompareTag("ground"))
		{
			onGround = true;
			anim.SetBool ("onGround",onGround);
			AudioManager.instance.PlaySound (ground, transform.position);
		}
		if(col.gameObject.CompareTag("Target")){
			//set the isLevelComplete flag to true if the player hits an object with name Goal
			isLevelComplete = true;
			if(totalTime<16){
				star3.GetComponent<Image>().enabled = true;
				star2.GetComponent<Image>().enabled = true;
				star1.GetComponent<Image>().enabled = true;
			}
			else if(totalTime<21){
				star2.GetComponent<Image>().enabled = true;
				star1.GetComponent<Image>().enabled = true;
			}
			else if(totalTime<26){
				star2.GetComponent<Image>().enabled = true;
				Debug.Log ("star3");
			}
			buttonNext.SetActive(true);
		}


	}

	public void NextLevel(){
		//load the 2 level 
		if(SceneManager.GetActiveScene ().buildIndex == 1 || SceneManager.GetActiveScene ().buildIndex == 2){
			SceneManager.LoadScene (2);
		}

	}
}
