using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floater : MonoBehaviour {

	private Transform seaPlane;
	private Cloth planeCloth;
	[SerializeField]private int closeVertexIndex = -1;
	// Use this for initialization
	void Start () {
		seaPlane = GameObject.Find ("Sea").transform;
		planeCloth = seaPlane.GetComponent<Cloth> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetClosesetVer ();
	}

	void GetClosesetVer(){
		for(int i = 0 ; i < planeCloth.vertices.Length; i++){
			if(closeVertexIndex == -1){
				closeVertexIndex = i;

			}
			float distance = Vector3.Distance (planeCloth.vertices[i],transform.position);
			float closestDistance = Vector3.Distance (planeCloth.vertices[closeVertexIndex],transform.position);

			if(distance < closestDistance){
				closeVertexIndex = i;

			}
		}

		transform.position = new Vector3 (transform.position.x,planeCloth.vertices[closeVertexIndex].y,transform.position.z);
	}
}
