using UnityEngine;
using System.Collections;

public class Hero {
	//生命值
	protected int maxHP;
	protected int curHP;
	
	//攻击力
	protected int maxATT;
	protected int curATT;
	
	//速度
	protected int maxSPE;
	protected int curSPE;
	
	//大技能冷却回合
	protected int BSTime;
	protected int BSBTime;
	private bool BSchecked;
	
	//小技能冷却回合
	protected int SSTime;
	protected int SSBTime;
	protected bool SSchecked;
	
	//冰防
	protected int antiIce;
	protected int curAIdegree;
	protected bool isIced;
	protected int iceTime;
	
	//毒防
	protected int antiPoi;
	protected int curAPdegree;
	protected bool isPoid;
	protected int poiTime;
	
	//晕防
	protected int antiSic;
	protected int curASdegree;
	protected bool isSicd;
	protected int sicTime;
	
	//命中
	protected int goal;
	//特质
	protected int SPEC;
	
	//构造函数
	Hero(){}
	Hero(int H,int A,int BST,int SST,int ice,int poi,int sic,int go){
		HP = H;
		ATT = A;
		BSTime = BST;
		SSTime = SST;
		iceAnti = ice;
		poiAnti = poi;
		sicAnti = sic;
		goal = go;
	}
	
	//改变生命值
	public int getmaxHP(){
		return maxHP;
	}
	public int getcurHP(){
		return curHP;
	}
	//返回当前攻击力
	public int getcurATT(){
		return curATT;
	}
	//返回当前速度
	public int getcurSPE(){
		return curSPE;
	}
	//是否冰冻
	public bool getISICED(){
		return isIced;
	}
	//是否中毒
	public bool getISPOID(){
		return isPoid;
	}
	//是否眩晕
	public bool getISSICD(){
		return isSicd;
	}
	//冰冻回合
	public int geticeTime(){
		return iceTime;
	}
	//眩晕回合
	public int getsicTIme(){
		return sicTime;
	}
	//中毒回合
	public int getpoiTime(){
		return poiTime;
	}
	//获得技能冷却时间
	public int getSSTime(){
		return SSTime;
	}
	//获得大技能冷却时间
	public int getBSTime(){
		reutrn BSTime;
	}
	//大技能倒计时
	public int getBSBTime(){
		return BSBTime;;
	}
	//小技能倒计时
	public int getSSBTime(){
		return SSBTime;
	}
	
	public void changeHP(int change){
		HP += change;
	}
	
	public void changeATT(int change){
		curATT += change;
	}
	
	public void changeSPE(int change){
		curSPE += change;
	}
	
	//友情技能
	public void friend(){
		
	}
	
	//小技能
	public void SSkill(){
		
	} 
	
	//大技能
	public void BSkill(){
		
	}
}
