using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shower : MonoBehaviour {

    public GameObject ShowerFountain;
    public GameObject ShowerPanel2;
    public AudioSource src;
    public AudioClip _showerSound;
    public Text _timer;
    string tiempo;
    int t=20;

    public int T
    {
        get
        {
            return t;
        }

        set
        {
            t = value;
            tiempo = t + "segs.";
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            StartCoroutine(DucharaWinston());
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public IEnumerator DucharaWinston()
    {
        Winston.Instance.TakingBath = true;
        while (WinstonAnimator.Instance.animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);
        WinstonAnimator.Instance.animator.SetBool("bath", true);
        src.PlayOneShot(_showerSound);
        ShowerFountain.SetActive(true);
        _timer.enabled = true;
        while (T > 0)
        {
            _timer.text = tiempo;
            yield return new WaitForSeconds(1f);
            T--;           
        }        
        src.Stop();
        incrementarHigiene();
        WinstonAnimator.Instance.animator.SetBool("bath", false);
        ShowerFountain.SetActive(false);
        GameStatus.Instance.Stat.Duchar = 4;
        _timer.enabled = false;
    }

    public void OnColliderExit(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            GetComponent<BoxCollider>().enabled = false;
            

        }
    }

    public void incrementarHigiene()
    {
        if (WinstonStats.Instance.myProp.higiene == 0)
        {
            WinstonStats.Instance.myProp.higiene = 100;
            Winston.Instance.dirty = 0;
            Winston.Instance.StartCoroutine(WinstonStats.Instance.higControl());

        }
        else
        {
            WinstonStats.Instance.myProp.higiene = WinstonStats.Instance.myProp.higiene + (100 - WinstonStats.Instance.myProp.higiene);
            GameStatus.Instance.Stat.Duchar = 0;
        }
    }

}
