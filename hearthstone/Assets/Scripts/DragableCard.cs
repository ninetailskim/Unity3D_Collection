using UnityEngine;
using System.Collections;

public class DragableCard : UIDragDropItem {

    protected override void OnDragDropRelease(GameObject surface){
        base.OnDragDropRelease(surface);


        if (surface != null && surface.tag == "MyFightCard"){
            //拖拽到了可发牌区域

            //首先要判断需要的水晶够不够
            int needCrystal = this.GetComponent<Card>().curCrystal;
            Hero1Crystal hero1crystal = GameObject.Find("hero1_crystal").GetComponent<Hero1Crystal>();

            bool Success = hero1crystal.GetCrystal(needCrystal);
            if (Success)
            {
                this.transform.parent.GetComponent<Mycard>().RemoveCard(this.gameObject);
                surface.GetComponent<MyFightCard>().AddCard(this.gameObject);
            }
            else
            {
                transform.parent.GetComponent<Mycard>().UpdateShow();
            }
        }
        else {
            transform.parent.GetComponent<Mycard>().UpdateShow(); ;
        }
    }

}
