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

    public void LastSceneNameEquals(string s){
		lastScene = s; 
	}

	public string ReturnLastSceneName(){
		return lastScene;
	}

    public void LoadScene(string sc)
    {
        LastSceneNameEquals(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sc);
        GlobalPanelHandler.Instance.ResetValues();
    }

    void Start(){
		Scene scene = SceneManager.GetActiveScene ();		
		lastScene = scene.name; 
	}


}
