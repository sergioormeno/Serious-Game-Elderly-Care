using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SCManager : ElSingleton<SCManager> {
    static bool _onceCaled = false;

	private string lastScene;
	public int TypeOfGame; // 0 = casual, 1 = ranked;

    void Awake()
    {
        if (!_onceCaled)
        {
            DontDestroyOnLoad(gameObject);
            _onceCaled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LastScene(string s){
		lastScene = s; 
	}

	public string RLastScene(){
		return lastScene;
	}

	void Start(){
		Scene scene = SceneManager.GetActiveScene ();		
		lastScene = scene.name; 
	}
}
