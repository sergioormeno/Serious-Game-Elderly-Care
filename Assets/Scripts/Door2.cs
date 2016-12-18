using UnityEngine;
using System.Collections;


public class Door2 : MonoBehaviour {
   
	private AudioSource source;  
	public AudioClip opend;
	public AudioClip closedd;
    bool open = false;
    bool _onceCalled = false;
    int called = 0;


    private void Awake (){
		source = GetComponent<AudioSource> ();
	}


    public void Interact()
    {
        if (open == false)
        {
            LeanTween.rotate(gameObject, new Vector3(0, -90, 0), 0.5f);
            source.PlayOneShot(opend, 1f);
            open = true;
            OpenCalled();
        }
        else
        {
            open = false;
            LeanTween.rotate(gameObject, new Vector3(0, -180, 0), 0.5f);
            source.PlayOneShot(closedd, 1f);
        }

    }

    public void OpenCalled()
    {
        if (_onceCalled == false)
        {
            called = 1;
            GameStatus.Instance.Stat.Tutorial = GameStatus.Instance.Stat.Tutorial + called;
            _onceCalled = true;
        }
    }



}
