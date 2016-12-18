using UnityEngine;
using System.Collections;

public class Fixing : MonoBehaviour {
	public Material Material;
	public Material Material2; 
	public InputHandler handler;
	public PanelHandler ph;



	void Install(){
		if (GameStatus.Instance.bar1 == false) {
			GetComponent<FixingSound> ().PlaySound (handler.hempty); 
			GetComponent<Renderer> ().material = Material2;
            GameStatus.Instance.bar1 = true;
		} else {
			if (GameStatus.Instance.bar2 == false) {
				GetComponent<FixingSound> ().PlaySound (handler.hempty); 
				GetComponent<Renderer> ().material = Material2;
                GameStatus.Instance.bar2 = true;
                GameStatus.Instance.Stat.Fixing = 2;
            }
		}
	}

}

