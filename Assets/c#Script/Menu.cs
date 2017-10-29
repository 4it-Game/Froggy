using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject menuView; 

	public void StartGame(){
		menuView.SetActive (false);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
