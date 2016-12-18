using UnityEngine;
using System.Collections;

public class TriggerCollider : MonoBehaviour {
    public Collider WinstonC;


    void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.tag == "Winston")
        {
            GameStatus.Instance.readyToEat=true;
        }
    }
}
