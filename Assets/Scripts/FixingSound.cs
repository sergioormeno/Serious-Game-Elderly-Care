using UnityEngine;
using System.Collections;

public class FixingSound : MonoBehaviour {
	
		public AudioClip bb;

		public void PlaySound(bool hands){

			if (!hands) {
				GetComponent<AudioSource> ().PlayOneShot (bb, 1);
			}

		}
}


