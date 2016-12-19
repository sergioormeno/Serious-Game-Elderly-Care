using UnityEngine;
using System.Collections;

public class Towel : MonoBehaviour {

    public void Interact()
    {
        gameObject.SetActive(false);
        GameStatus.Instance.Stat.Duchar=5; 
    }
}
