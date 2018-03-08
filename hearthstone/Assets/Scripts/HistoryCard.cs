using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HistoryCard : MonoBehaviour {

    public Transform incard;
    public Transform outcard;
    public Transform card1;
    public Transform card2;

    public GameObject cardPrefab;

    private float yOffset;
    private List<GameObject> cardList = new List<GameObject>();

    void Start() {
        yOffset = card2.position.y - card1.position.y;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            StartCoroutine(AddCard());
        }
    }

    //写成协程是因为instantiate的初始化会冲掉原来的地址，所以要在它初始化之后（下一帧）再设地址
    public IEnumerator AddCard() {
        GameObject go =  GameObject.Instantiate(cardPrefab, incard.position, Quaternion.identity) as GameObject;
        yield return 0;//就是暂停一帧再继续执行
        go.transform.position = incard.position;
        iTween.MoveTo(go,card1.position,0.5f);
        cardList.Add(go);
        if (cardList.Count > 9) {
            //这个动画是异步的，所以销毁要在动画完成之后
            iTween.MoveTo(cardList[0],outcard.position,0.5f);
            Destroy(cardList[0],2);
            cardList.RemoveAt(0);

        }
        for (int i = 0; i < cardList.Count - 1; i++) { 
            iTween.MoveTo(cardList[i],cardList[i].transform.position + new Vector3(0,yOffset,0),0.2f);
        }
    }
}