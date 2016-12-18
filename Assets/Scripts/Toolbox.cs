using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour {
	public Material material; 
	public Material material2;
	public InputHandler handler;  
	public PanelHandler ph;



	void Install(){
		GetComponent<Renderer> ().material = material2;
		GetComponent<BoxSound> ().PlaySound (handler.hempty);
		handler.hempty = true; 
		if (PanelHandler.Instance.tf2.isOn == true) {
			GameStatus.Instance.Stat.Fixing = 3;
		} 

	}

	void Interact(){
		if (!GameStatus.Instance.bar1 || !GameStatus.Instance.bar2) {
			GetComponent<Renderer> ().material = material;
			GetComponent<BoxSound> ().PlaySound (handler.hempty);
			handler.hempty = false;
            GameStatus.Instance.Stat.Fixing = 1;
        } else {
			Debug.Log ("Ya haz instalado las barras"); 
			
		}		
	}
}
