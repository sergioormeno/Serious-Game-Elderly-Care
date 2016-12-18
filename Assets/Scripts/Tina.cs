using UnityEngine;
using System.Collections;

public class Tina : MonoBehaviour {
	public GameStatus gs;
	public Winston wins;
	public GameObject water; 
	public AudioClip WaterSound; 
	public AudioClip WaterSoundOut; 
	public PanelHandler ph;
	public WinstonStats ws;


	public void Interact(){
		if ((WinstonStats.Instance.myProp.higiene <= 50) & (gs.Stat.Duchar == 0)) {
			StartCoroutine (FillBath ());
		} else {
			if (gs.Stat.Duchar == 2) {
				Debug.Log ("Haz bañado a winson");
				StartCoroutine (outBath ());
				if (WinstonStats.Instance.myProp.higiene == 0) {
                    WinstonStats.Instance.myProp.higiene = 100; 
					wins.dirty = 0;
					wins.StartCoroutine (ws.higControl ());
 
				} else {
                    WinstonStats.Instance.myProp.higiene = WinstonStats.Instance.myProp.higiene + (100 - WinstonStats.Instance.myProp.higiene); 	
					gs.Stat.Duchar = 0; 
				}
			} else {
				if (WinstonStats.Instance.myProp.higiene >= 50) {
					Debug.Log ("winston esta limpio");
				} else {
					
				}

			}
		}
	
	}

	void Awake(){
	}

	public IEnumerator FillBath(){
		
		water.GetComponent<Animation> ().Play ("inbath");
		GetComponent<AudioSource> ().PlayOneShot (WaterSound, 1f);
		while (water.GetComponent<Animation>().IsPlaying("inbath")==true) {
			Debug.Log ("Estas llenando la tina");
			yield return new WaitForSeconds (1f); 
		}
		GetComponent<AudioSource>().Stop();
		gs.Stat.Duchar = 1;
		Debug.Log ("Ya puedes bañar a Winston");


	}

	public IEnumerator outBath(){

		water.GetComponent<Animation> ().Play ("outbath");
		GetComponent<AudioSource> ().PlayOneShot (WaterSoundOut, 1f);
		while (water.GetComponent<Animation>().IsPlaying("outbath")==true) {
			Debug.Log ("Estas vaciando la tina");
			yield return new WaitForSeconds (1f); 
		}
		GetComponent<AudioSource>().Stop();
		gs.Stat.Duchar = 3;
		Debug.Log ("Haz bañado a Winston");


	}
}
