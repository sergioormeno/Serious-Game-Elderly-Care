using UnityEngine;
using System.Collections;

public class PlayerCheckerTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameStatus.Instance.pActions.Actions = "Ha dejado sólo a Winston durante su baño";
        }
    }
}
