using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    public int curCrystal;
    public int hp;
    public int harm;

    private UISprite sprite;
    private UILabel hpLabel;
    private UILabel harmLabel;

    //这个地方到底是什么，get和set我忘了是什么意思了
    private string CardName {
        get {
            if (sprite == null) {
                sprite = this.GetComponent<UISprite>();
            }  
            return sprite.spriteName;
        }
    }

    void Awake() {
        InitProperty();
        hpLabel = this.transform.Find("hpLabel").GetComponent<UILabel>();
        harmLabel = this.transform.Find("harmLabel").GetComponent<UILabel>();
        RestShow();
    }

    void OnHover(bool isOver) {
        if (isOver){
            Descard._instance.ShowCard(CardName);
        }
        else {
            Descard._instance.HideCard();
        }
    }

    public void SetDepth(int depth) {
        this.GetComponent<UISprite>().depth = depth;
        hpLabel.depth = depth + 1;
        harmLabel.depth = depth + 1;
    }

    public void RestPos()
    {
        harmLabel.GetComponent<UIAnchor>().enabled = true;
        hpLabel.GetComponent<UIAnchor>().enabled = true;
    }

    public void RestShow() {
        harmLabel.text = harm + "";
        hpLabel.text = hp + "";
    }

    //14节的内容，神马玩意
    public void InitProperty() {
        string[] s = CardName.Split('_');
        curCrystal = int.Parse(s[1]);
        harm = int.Parse(s[2]);
        hp = int.Parse(s[3]);
    }
}
