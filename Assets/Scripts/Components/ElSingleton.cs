using UnityEngine;

/// <summary>
/// Clase singleton basica (renombrada para no tener problema de conflicto en nombres -Boris).
/// </summary>
/// <typeparam name="T"></typeparam>
public class ElSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    /**
      Returns the instance of this singleton.
   */
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) +
                                   " is needed in the scene, but there is none.");
                }
            }

            return instance;
        }
    }
}
