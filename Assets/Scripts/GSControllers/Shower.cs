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

    BoxCollider shCollider;
    GameStatus gs;
    DiaryAnimation da;
    WinstonAnimator wa;
    WinstonStats ws;
    Winston w;



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

    void Start()
    {
        shCollider = GetComponent<BoxCollider>();
        ws = WinstonStats.Instance;
        wa = WinstonAnimator.Instance;
        gs = GameStatus.Instance;
        w = Winston.Instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            StartCoroutine(DucharWinston());
            shCollider.enabled = false;
        }
    }

    public IEnumerator DucharWinston()
    {
        w.TakingBath = true;
        wa.StopAgent();
        while (wa.animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);
        wa.animator.SetBool("bath", true);
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
        wa.animator.SetBool("bath", false);
        ShowerFountain.SetActive(false);
        gs.Stat.Duchar = 4;
        _timer.enabled = false;
    }

    public void OnColliderExit(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            shCollider.enabled = false;           

        }
    }

    public void incrementarHigiene()
    {
        if (ws.myProp.higiene == 0)
        {
            ws.myProp.higiene = 100;
            w.dirty = 0;
            StartCoroutine(ws.higControl());

        }
        else
        {
            ws.myProp.higiene = ws.myProp.higiene + (100 - ws.myProp.higiene);
            gs.Stat.Duchar = 0;
        }
    }

}
