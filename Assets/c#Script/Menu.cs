using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject menuView; 

	public void StartGame(){
		menuView.SetActive (false);

		SceneManager.LoadScene (1);
	}
	public void EndGame(){
		Application.Quit ();
	}


}
