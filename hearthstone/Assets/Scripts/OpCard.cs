using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpCard : MonoBehaviour {

    public Transform cardOriginal;

    public GameObject myCardPerfab;

    private List<GameObject> cardList = new List<GameObject>();

    /*public void AddCard(GameObject cardgo = null) {
        Debug.Log(cardgo.ToString());
        GameObject go = null;
        if (cardgo != null)
        {
            go = cardgo;
            go.transform.parent = this.transform;
            
        }
        else
        {
            go = NGUITools.AddChild(this.gameObject, myCardPerfab);
            //go.GetComponent<UISprite>().spriteName = 
        }
        cardList.Add(go);
        iTween.MoveTo(go, cardOriginal.position, 0.5f);
    }*/

    public void AddCard(GameObject go)
    {

        go.transform.parent = this.transform;
        cardList.Add(go);
        iTween.MoveTo(go, cardOriginal.position, 0.5f);
    }

    public void RemoveCard(GameObject go) {
        cardList.Remove(go);
    }
}
