using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Mycard : MonoBehaviour {

    public GameObject myCardPerfab;

    public Transform card1;

    public Transform card2;

    private float xOffset;

    private static int i = 0;

    private List<GameObject> myCards = new List<GameObject>();

    void Start() {
        xOffset = card2.position.x - card1.position.x; 
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            AddCard();
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            LoseCard();
        }
    }

    public string[] cardNames;

    public void AddCard(GameObject cardGo = null) {
        //初始位置就是在父节点的（0，0，0）
        GameObject go = null;
        if (cardGo == null) {
            go = NGUITools.AddChild(this.gameObject, myCardPerfab);
            go.GetComponent<UISprite>().spriteName = cardNames[Random.Range(0, cardNames.Length)];
        }
        else{
            go = cardGo;
            go.transform.parent = this.transform;
        }
        go.GetComponent<UISprite>().depth += (2 * i ++);
        go.transform.Find("hpLabel").GetComponent<UILabel>().depth = go.GetComponent<UISprite>().depth + 1;
        go.transform.Find("harmLabel").GetComponent<UILabel>().depth = go.GetComponent<UISprite>().depth + 1;
        //Debug.Log(go.GetComponent<UISprite>().depth);
        Vector3 toPosition = card1.position + new Vector3(xOffset, 0f, 0f) * myCards.Count;

        iTween.MoveTo(go, toPosition,0.5f);

        myCards.Add(go);
    }

    public void LoseCard() {
        int index = Random.Range(0,myCards.Count);
        Destroy(myCards[index]);
        myCards.RemoveAt(index);
        UpdateShow();
    }

    public void UpdateShow() {
        for (int i = 0; i < myCards.Count; i++) {
            iTween.MoveTo(myCards[i], card1.position + new Vector3(xOffset, 0, 0) * i, 0.5f);
        }
    }

    public void RemoveCard(GameObject go){
        myCards.Remove(go);
    }
}
