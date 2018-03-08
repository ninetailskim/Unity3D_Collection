using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public TweenScale logoTweenScale;
	
	public TweenPosition selecthero;
	
	public UISprite hero1;
	
	private bool isCanShowSelectRole = false;
	// Use this for initialization
	void Start () {
		logoTweenScale.AddOnFinished(this.OnLogoTweenFinish);
	}
	
	// Update is called once per frame
	void Update () {
		if(isCanShowSelectRole && Input.GetMouseButtonDown(0)){
			//显示角色选择界面
			selecthero.PlayForward();
			isCanShowSelectRole = false;
		}
	}
	private void OnLogoTweenFinish(){
		isCanShowSelectRole = true;
	}
	
	IEnumerator LoadPlayScene(){
		yield return new WaitForSeconds(3f);
		Application.LoadLevel(1);
	}
	
	public void OnClick(){
		
		VSShow._instance.Show(hero1.spriteName,"hero" + Random.Range(1,10));
		StartCoroutine(LoadPlayScene());
	}
}
