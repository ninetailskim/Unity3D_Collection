using UnityEngine;
using System.Collections;

public class Hero1Crystal : MonoBehaviour {

	public int usableNumber = 1;
	
	public int totalNumber = 1;
	
	public int maxNumber = 10;
	
	public UISprite[] crystals;

    public UILabel label;

	void Awake(){
		maxNumber = crystals.Length;
        label = this.GetComponent<UILabel>();
	}
	
    void Start(){
        //把这个脚本的方法注册到gamecontroller的事件里面
        GameController._instance.OnNewRound += this.OnNewRound;
    }

	void Update(){
		UpdateShow();
	}

    public void Refresh(){
        if (totalNumber < maxNumber){
            totalNumber++;
        }
        usableNumber = totalNumber;
        UpdateShow();
    }

    public bool GetCrystal(int number) {
        if (usableNumber >= number){
            usableNumber -= number;
            UpdateShow();
            return true;
        }
        else
        {
            return false;
        }
    }

	void UpdateShow(){
		for(int i = totalNumber;i < maxNumber;i ++){
			crystals[i].gameObject.SetActive(false);
			//一旦设置成了false就不会去渲染它了
		}
		for(int i = 0;i < totalNumber;i ++){
			crystals[i].gameObject.SetActive(true);
		}
		for(int i = usableNumber;i < totalNumber;i ++){
			crystals[i].spriteName = "TextInlineImages_normal";
		}
		for(int i = 0;i < usableNumber;i ++){
			if(i == 9){
				crystals[i].spriteName = "TextInlineImages_10";	
			}
			else{
				crystals[i].spriteName = "TextInlineImages_0" + (i + 1);	
			}
			
		}

        label.text = usableNumber + "/" + totalNumber;
	}

    public void OnNewRound(string heroName) {
        if (heroName == "hero1") {
            Refresh();
        }
    }
}
