using UnityEngine;
using System.Collections;

public class BoxSound : MonoBehaviour {

	public AudioClip pick;
	public AudioClip drop;

	public void PlaySound(bool hands){

		if (hands) {
			GetComponent<AudioSource> ().PlayOneShot (pick, 1);
		}else{
			GetComponent<AudioSource> ().PlayOneShot (drop, 1);
		}
	
	}
}
