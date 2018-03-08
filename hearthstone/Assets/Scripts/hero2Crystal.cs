using UnityEngine;
using System.Collections;

public class hero2Crystal : MonoBehaviour {
    public int usableNumber = 0;

    public int totalNumber = 0;

    public int maxNumber = 10;

    public UISprite[] crystals;

    private UILabel label;

    void Awake() {
        usableNumber = 0;
        totalNumber = 0;
        label = this.GetComponent<UILabel>();
    }

    void Start(){
        GameController._instance.OnNewRound += this.OnNewRound;
        label.text = usableNumber + "/" + totalNumber;
    }

    public void UpdateShow() {
        label.text = usableNumber + "/" + totalNumber;
    }

    public void Refresh()
    {
        if (totalNumber < maxNumber)
        {
            totalNumber++;
        }
        usableNumber = totalNumber;
        UpdateShow();
    }

    public bool GetCrystal(int number) {
        if (usableNumber >= number)
        {
            usableNumber -= number;
            UpdateShow();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnNewRound(string heroName) {
        if (heroName == "hero2") {
            Refresh();
        }
    }

}
