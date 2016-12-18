using UnityEngine;
using System.Collections;

public class PossShowerTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            GameStatus.Instance.Stat.Duchar = 2;
            Debug.Log(GameStatus.Instance.Stat.Duchar);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Winston")
        {
            DestroyObject(gameObject);
        }
    }
}
