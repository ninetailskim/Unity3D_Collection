using UnityEngine;
using System.Collections;

public enum GameState { 
    CardGenerating,//发牌
    PlayCard,//出牌
    End//游戏结束阶段
}

public class GameController : MonoBehaviour {

    public static GameController _instance;

    public GameState gameState = GameState.CardGenerating;
    public float cycleTime = 60f;
    public Mycard myCard;
    public OpCard opCard;

    //定义委托
    public int roundIndex = 0;//流转次数
    public delegate void OnNewRoundEvent(string heroName);
    public event OnNewRoundEvent OnNewRound;

    private float timer = 0;
    private UISprite wickpopeSprite;
    private float wickpopeLength;
    private string currenHeroName = "hero1";//当前回合英雄
    private cardGenerator cardGenerator;

    //Awake方法是早与Start的
    void Awake() {
        _instance = this;
        wickpopeSprite = this.transform.Find("wickpope").GetComponent<UISprite>();
        wickpopeLength = wickpopeSprite.width;
        wickpopeSprite.width = 0;
        this.cardGenerator = this.GetComponent<cardGenerator>();
        //给当前回合的英雄发牌
        StartCoroutine( GenerateCardForHero1());
    }

    void Update() {
        if (gameState == GameState.PlayCard) {
            timer += Time.deltaTime;
            if (timer > cycleTime)
            {
                TransformPlayer();
            }
            else {
                if (cycleTime -  timer <= 15f) {
                    wickpopeSprite.width = (int)(((cycleTime - timer) / 15f) * wickpopeLength);
                }
            }
        }
    }

    public void TransformPlayer() {
        timer = 0;
        if (currenHeroName == "hero1")
        {
            currenHeroName = "hero2";
        }
        else
        {
            currenHeroName = "hero1";
        }
        roundIndex ++;
        OnNewRound(currenHeroName);
        if (roundIndex >= 2)
        {
            StartCoroutine(DealCard());
        }
    }

    IEnumerator DealCard(){
        gameState = GameState.CardGenerating;
        if(currenHeroName == "hero1"){
            GameObject Cardgo = cardGenerator.RandomGenerateCard();
            yield return new WaitForSeconds(2f);
            myCard.AddCard(Cardgo);
        }else{
            GameObject Cardgo = cardGenerator.RandomGenerateCard();
            yield return new WaitForSeconds(2f);
            opCard.AddCard(Cardgo);
        }
        gameState = GameState.PlayCard;
        timer = 0;
    }

    private IEnumerator GenerateCardForHero1() {
        GameObject cardGo =  cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        //把这张卡片放在卡片管理内
        myCard.AddCard(cardGo);
        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        //把这张卡片放在卡片管理内
        Debug.Log(cardGo.ToString());
        opCard.AddCard(cardGo);
        
        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        opCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        opCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();
        yield return new WaitForSeconds(2f);
        opCard.AddCard(cardGo);

        gameState = GameState.PlayCard;
        timer = 0;
    }
}
