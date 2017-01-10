using UnityEngine;
using System.Collections;

public class PlayerCheckerTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameStatus.Instance.playerActions.Actions = "Ha dejado sólo a Winston durante su baño";
            Destroy(gameObject);
        }
    }
}
