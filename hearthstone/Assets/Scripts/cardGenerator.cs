using UnityEngine;
using System.Collections;

public class cardGenerator : MonoBehaviour {

    public GameObject cardPrefab;

    public string[] cardName;

    public UISprite[] spriteName;

    public Transform fromCard;

    public Transform toCard;

    private UISprite nowGenerateCard;

    private bool isTransform = false;
    public float transformTime = 2f;
    private float timer = 0f;

    public int transformSpeed = 20;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomGenerateCard();
        }
        if (isTransform)
        {
            timer += Time.deltaTime;
            int index = (int)(timer / (1f / transformSpeed));
            nowGenerateCard.spriteName = cardName[index %= cardName.Length];
            if (timer > transformTime)
            {
                nowGenerateCard.spriteName = cardName[Random.Range(0,cardName.Length)];
                nowGenerateCard.GetComponent<Card>().InitProperty();
                nowGenerateCard.GetComponent<Card>().RestShow();
                timer = 0;
                isTransform = false;
            }
        }
    }

    public GameObject RandomGenerateCard()
    {
        //不用协程来做,用NGUI的自带的函数，AddChild的两个参数，第一个是要生成的物体的父类物体，第二个是要生成的物体的prefab
        GameObject go = NGUITools.AddChild(this.gameObject, cardPrefab);
        go.transform.position = fromCard.position;
        //这儿其实没咋看懂就是一个UIsprite的赋值
        nowGenerateCard = go.GetComponent<UISprite>();
        //iTween.MoveTo的三个参数，第一个是要移动的物体，第二个是移动的目的位置，第三个是动画时间
        iTween.MoveTo(go, toCard.position, 1f);
        isTransform = true;
        return go;
    }
}
