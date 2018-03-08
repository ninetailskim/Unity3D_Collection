using UnityEngine;
using System.Collections;

public class BlackMask : MonoBehaviour {

	public static BlackMask _instrance;
	
	void Awake(){
		_instrance = this;
		this.gameObject.SetActive(false);
	}
	
	public void Show(){
		this.gameObject.SetActive(true);		
	}
	
	public void Hide(){
		this.gameObject.SetActive(false);
	}
}
