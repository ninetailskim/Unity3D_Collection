public class Mulading : Hero {
	Mulading(){}
	Mulading(int H,int A,int B,int S,int I,int P,int SI,int G){
		Hero(H,A,B,S,I,P,SI,G);
	}
	
	public void SSkill(){
		SPEC *= 2;
	} 
	
	public void BSkill(){
		this.ATT *= 2;
	}
}
