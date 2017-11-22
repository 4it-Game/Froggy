using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerCharactorController : MonoBehaviour {

	public float speed = 10.0f;
	public float jumpForce = 10.0f;
	public float gravity = 10.0f;
	public float rotateSpeed = 200;

	private Vector3 motion = Vector3.zero;

	private CharacterController controller
	{
		get
		{
			return GetComponent<CharacterController>();    
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Move();
		Rotate();
	}

	private void Move()
	{
		motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


		//controller.Move (motion);
		//controller.SimpleMove(motion);

		//jump
		if(Input.GetKey (KeyCode.Space) & controller.isGrounded)
		{
			motion.y = jumpForce;
			motion.y -= gravity * Time.deltaTime;
		}
		else{
			motion *= speed;
			motion = transform.TransformDirection(motion);
		}
			
		controller.Move(motion * Time.deltaTime);


	}

	private void Rotate()
	{
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, 0);
		//Camera.main.transform.Rotate(-1 * Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, 0, 0);

	}

}
