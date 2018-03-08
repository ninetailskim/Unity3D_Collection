using UnityEngine;
using System.Collections;

public class Descard : MonoBehaviour {
    public static Descard _instance;

    public float showTime = 2f;

    public UISprite sprite;
    private float timer = 0;
    private bool isShow = false;
    private bool isOut = false;
    private UILabel hpLabel;
    private UILabel harmLabel;


    void Awake() {
        sprite = this.GetComponent<UISprite>();
        _instance = this;
        this.gameObject.SetActive(false);
        sprite.alpha = 0;
        hpLabel = this.transform.Find("hpLabel").GetComponent<UILabel>();
        harmLabel = this.transform.Find("harmLabel").GetComponent<UILabel>();
    }

    void Update() { 
        if(isShow && isOut){
            timer += Time.deltaTime;
        }
        if (timer >= showTime)
        {
            sprite.alpha = 0;
            timer = 0;
            isShow = false;
            this.gameObject.SetActive(false);
        }
        else if(isOut){
            //alphe的值是百分比，所以是0~1
            sprite.alpha = (showTime - timer) / showTime;

        }
    }

    public void ShowCard(string cardname) {

        //_instance.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,2);
        this.gameObject.SetActive(true);
        sprite.spriteName = cardname;
        hpLabel.text = cardname.Split('_')[3];
        harmLabel.text = cardname.Split('_')[2];
        sprite.alpha = 1;
        isShow = true;
        timer = 0;
        isOut = false;
    }

    public void HideCard() {
        isOut = true;
        //this.gameObject.SetActive(false);
    }

    IEnumerator disCard()
    {
        yield return 0;
        //iTween.FadeTo的三个参数，第一个目标物体，第二个是变化的目标值，第三个是秒数
        iTween.FadeTo(this.gameObject, 0, 1f);
    }

}
