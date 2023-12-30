using UnityEngine;

namespace Suhdo.CharacterCore
{
	public class EnemyCoreComponent : MonoBehaviour
	{
		protected EnemyCore EnemyCore;

		protected virtual void Awake()
		{
			EnemyCore = transform.parent.GetComponent<EnemyCore>();
			if(EnemyCore == null) Debug.LogError("There are no Core on the parent!");
		}

		protected virtual void OnValidate()
		{
			EnemyCore = transform.parent.GetComponent<EnemyCore>();
			if(EnemyCore == null) Debug.LogError("There are no Core on the parent!");
		}
	}
	
}
