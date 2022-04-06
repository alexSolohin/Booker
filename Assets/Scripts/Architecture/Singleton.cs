using UnityEngine;

public class Singleton : MonoBehaviour { }

public class Singleton<T> : Singleton where T : Singleton
{
    public static T Instance;

    protected virtual void Awake()
    {
        Instance = this as T;
        
        if (transform.parent == null)
        {
            DontDestroyOnLoad(this);
        }
    }
}


