using UnityEngine;
using System.Collections;

public class MotherScript : MonoBehaviour {
	
	
	static public int good = 0;
	static bool  reset = false;
	static public int now = 0;
	static int[] order={3,5,1,2,4};
	static public bool[] whichDone= new bool[5];
	
	void  Start (){
		for (int i= 0; i < whichDone.Length; ++i) { whichDone[i] = false; }
		Shuffle(order);
	}
	
	void  Update (){
		if(good==5){
			//guiText.text="Brawo, udało Ci się!";
		}
		if(good<=order.Length-1){
			now=order[good];
		}
		Debug.Log("Good:"+good);
		Debug.Log("ktore(NOW)"+now);
	}
	
	void  Shuffle (int[] deck){
		for (int i = 0; i < deck.Length; i++) {
			int temp = deck[i];
			int randomIndex = Random.Range(0, deck.Length);
			deck[i] = deck[randomIndex];
			deck[randomIndex] = temp;
		}
	}
}