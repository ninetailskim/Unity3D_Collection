using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    protected UISprite sprite;
    public UILabel hpLabel;
    private int hpcount = 30;
    public int maxHp = 30;
    public int minHp = 0;

    void Awake()
    {
        sprite = this.GetComponent<UISprite>();
        hpLabel = this.transform.Find("hp").GetComponent<UILabel>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(Random.Range(1,5));
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            PlusHp(Random.Range(1, 4));
        }

    }


    //这个方法用来吸收伤害值
    public void TakeDamage(int damage)
    {
        hpcount -= damage;
        if (hpcount <= minHp)
        {
            //处理游戏结束的逻辑
        }
        hpLabel.text = hpcount + "";
    }

    public void PlusHp(int hp)
    {
        hpcount += hp;
        if (hpcount >= maxHp)
        {
            hpcount = maxHp;
        }
        hpLabel.text = hpcount + "";
    }
}
