using UnityEngine;
using System.Collections;

public class SitTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            WinstonAnimator.Instance.readyToEat = true;
            Destroy(gameObject);
        }
    }
}
