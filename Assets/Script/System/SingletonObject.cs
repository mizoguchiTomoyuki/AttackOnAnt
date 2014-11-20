using UnityEngine;
using System.Collections;

public class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour{
	private static T instance = null;

	// インスタンス取得
	public static T Instance {
		get {
			if(instance == null)
			{
				instance = FindObjectOfType<T>();
				if(instance == null)
				{
					Debug.LogWarning(typeof(T) + " is nothing.");
				}
			}

			return instance;	
		}
	}

	void Awake()
	{
		if(this == Instance)
		{
			//Debug.Log("OK.");
		}
		else
		{
			//Debug.Log("Del.");
			Destroy( this.gameObject );
		}
#if false
		if( instance == null)
		{
			//instance = this;
		}else{
			Destroy( this.gameObject );
		}
#endif
	}

	// Destroyで削除されたときに呼び出される
	void OnDestroy()
	{
		if( instance == this )
		{
			instance = null;
			//Debug.LogWarning(typeof(T) + " Destroy.");
		}
	}

	protected void DetachInstance()
	{
		if(this == instance)
		{
			instance = null;
		}
	}
}
