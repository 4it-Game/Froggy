using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waterSplit : MonoBehaviour {

	bool oneAndOnly = false;
	public ParticleSystem waterDrops;
	private Vector3 playerPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
	
		if(col.gameObject.CompareTag("player"))
		{
			if (!oneAndOnly) {
				playerPos = col.transform.position;
				col.gameObject.SetActive (false);
				Instantiate (waterDrops, playerPos, Quaternion.identity);
				oneAndOnly = true;
				//this.gameObject.SetActive(false);
				StartCoroutine (WaitForIt(1.0f));
				//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}


		}
	}

	IEnumerator WaitForIt(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy (GameObject.FindGameObjectWithTag("waterSplit"));
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
