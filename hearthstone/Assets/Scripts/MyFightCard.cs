using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MyFightCard : MonoBehaviour {
    public Transform card01;
    public Transform card02;

    private float xOffset = 0;
    private List<GameObject> cardList = new List<GameObject>();

    void Start() {
        xOffset = card02.position.x - card01.position.x;
    }


    public void AddCard(GameObject go) {
        go.GetComponent<UISprite>().width = 96;
        go.GetComponent<UISprite>().height = 135;
        go.GetComponent<Card>().RestPos();
        go.transform.parent = this.transform;
        cardList.Add(go);
        Vector3 targetPos = CalcPosition();
        iTween.MoveTo(go, targetPos, 0.5f);

    }

    Vector3 CalcPosition() {
        int index = cardList.Count;
        if (index % 2 == 0) {
            float myxOffset = (index / 2) * xOffset;
            Vector3 pos = new Vector3(card01.position.x - myxOffset,card01.position.y,card01.position.z);
            return pos;
        }
        else{
            float myxOffset = (index / 2) * xOffset;
            Vector3 pos = new Vector3(card01.position.x + myxOffset, card01.position.y, card01.position.z);
            return pos;
        }

    }
}
