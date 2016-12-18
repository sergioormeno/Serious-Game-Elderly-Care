using UnityEngine;
using System.Collections;

public class Lavaplatos : MonoBehaviour {
	public GameStatus gs; 
	public PanelHandler ph;

	public void Interact(){
		if (gs.Stat.Cocinar == 3) {
			Debug.Log ("Haz lavado los platos");
			gs.Stat.Cocinar=0; 
			gs.Stat.Cocinar = 4;
		} else {
			Debug.Log("No hay platos por lavar");
		
		}
		
	}

	void Awake(){
	}
}
