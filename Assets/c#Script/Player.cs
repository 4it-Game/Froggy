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

	private Rigidbody rb;

	private Animator anim;

	// Use this for initialization
	void Start () {
		onGround = true;
		jumpPressure = 0f;
		minJump = 3f;
		maxJumpPressure = 10f;
		rb = GetComponent<Rigidbody> ();

		powerImage.fillAmount = 0;

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		powerImage.fillAmount = jumpPressure / 10f;

		if (jumpPressure == 10) {
			jumpPressure = 0;
		}

		if (onGround) {
			if (Input.GetButton ("Jump")) 
			{
				if (jumpPressure < maxJumpPressure) {
					jumpPressure += Time.deltaTime * 10f;
				} else {
					jumpPressure = maxJumpPressure;
				}
				anim.SetFloat ("jumpPres",jumpPressure + minJump);
				anim.speed = 0.1f + (jumpPressure / 10f);
				Debug.Log (jumpPressure);
			} 
			else 
			{
				if (jumpPressure > 0f) {
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
	}


	void OnCollisionEnter(Collision col){
		if(col.gameObject.CompareTag("ground"))
		{
			onGround = true;
			anim.SetBool ("onGround",onGround);
		}
		if(col.gameObject.CompareTag("water"))
		{
			SceneManager.LoadScene (0);
		}


	}
}
