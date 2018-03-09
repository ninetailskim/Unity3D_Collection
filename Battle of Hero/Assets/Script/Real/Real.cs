using UnityEngine;
using System.Collections;

public class Real : MonoBehaviour {
	public bool canMove;//没有被冰封或者是眩晕
	public bool active;
	// Use this for initialization
	void Start () {
		canMove = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	bool getcanMove(){
		return canMove;
	}
}
