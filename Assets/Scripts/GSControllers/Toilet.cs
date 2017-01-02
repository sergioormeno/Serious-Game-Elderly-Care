using UnityEngine;
using System.Collections;

public class Toilet : MonoBehaviour {
	public GameStatus gs;


		public void Interact(){
		if (WinstonStats.Instance.myProp.vejiga <= 50) {
			Debug.Log ("Lo haz llevado al baño");
            WinstonStats.Instance.myProp.vejiga = WinstonStats.Instance.myProp.vejiga + (100 - WinstonStats.Instance.myProp.vejiga); 
		} else {
			Debug.Log("Aun no tiene ganas");

		}
	}


	void Awake(){

	}
}

