using UnityEngine;
using System.Collections;



public class Door3 : MonoBehaviour {

	private int m_LastIndex;
	private AudioSource source;  
	public AudioClip opend;
	public AudioClip closedd;
	int x;
	public GameStatus gs;


	private void Awake (){
		source = GetComponent<AudioSource> ();
	}

	public void Interact (int y) {

		if (!GetComponent<Animation> ().isPlaying) 
		{

			if (m_LastIndex == 0) 
			{
				GetComponent<Animation> ().Play ("DoorOpen3");
				m_LastIndex = 1;
				source.PlayOneShot (opend, 1f);
				if (x < 1) {
					x = x + y;
					gs.Stat.Tutorial = gs.Stat.Tutorial + y;
					x = x + 1;
				} 

			}else
			{
				GetComponent<Animation> ().Play ("DoorClose3");
				m_LastIndex = 0;
				source.PlayOneShot (closedd, 1f);



			}
		}
	}


}
