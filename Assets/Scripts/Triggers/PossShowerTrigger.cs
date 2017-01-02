using UnityEngine;
using System.Collections;

public class PossShowerTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            GameStatus.Instance.Stat.Duchar = 2;         
            WinstonAnimator.Instance.readyToShower = true;
            DestroyObject(gameObject);
        }
    }
}
