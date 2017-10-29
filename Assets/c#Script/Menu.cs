using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject menuView; 

	public void StartGame(){
		menuView.SetActive (false);
<<<<<<< HEAD
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
		SceneManager.LoadScene(1, LoadSceneMode.Additive);
>>>>>>> f4a816efcd961a6b8528349cfba8479b1a1da973
	}
}
