using UnityEngine;
using System.Collections;

public class HeroSelect : MonoBehaviour {
	
	private UISprite selectHeroImage;
	private UILabel selectHeroName;
	
	void  Awake(){
		//find是找当前物体的子物体
		selectHeroImage = this.transform.parent.Find("hero0").GetComponent<UISprite>();
		selectHeroName = this.transform.parent.Find("hero_name").GetComponent<UILabel>();
	}
	
	private string[] heroNames = {
		"吉安娜","雷克萨","乌瑟尔","加尔鲁什","玛法里奥","古尔丹","萨尔","安杜因","瓦莉莎"
	};
	
	void OnClick(){
		string heroname = this.gameObject.name;
		selectHeroImage.spriteName = heroname;
		
		char heroIndexChar = heroname[4];
		int heroIndex = heroIndexChar - '0' - 1;
		selectHeroName.text = heroNames[heroIndex];
	}
}
