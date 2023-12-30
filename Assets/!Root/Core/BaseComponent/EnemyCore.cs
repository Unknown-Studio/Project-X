using UnityEngine;

namespace Suhdo.CharacterCore
{
	public class EnemyCore : MonoBehaviour
	{
		public EnemyMovement EnemyMovement { get; private set; }
		public EnemyCollisionSenses EnemyCollisionSenses { get; private set; }

		private void Awake()
		{
			EnemyMovement = GetComponentInChildren<EnemyMovement>();
			EnemyCollisionSenses = GetComponentInChildren<EnemyCollisionSenses>();

			if (!EnemyMovement || !EnemyCollisionSenses)
				Debug.LogError("Missing core component!");
		}

		protected virtual void OnValidate()
		{
			EnemyMovement = GetComponentInChildren<EnemyMovement>();
			EnemyCollisionSenses = GetComponentInChildren<EnemyCollisionSenses>();

			if (!EnemyMovement || !EnemyCollisionSenses)
				Debug.LogError("Missing core component!");
		}

		public void LogicUpdate()
		{
			EnemyMovement.LogicUpdate();
		}
	}
	
}
