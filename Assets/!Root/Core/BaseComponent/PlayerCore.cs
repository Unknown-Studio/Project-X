using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class PlayerCore : MonoBehaviour
    {
        public PlayerMovement PlayerMovement { get; private set; }
        public PlayerCollisionSenses PlayerCollisionSenses { get; private set; }

        private void Awake()
        {
            PlayerMovement = GetComponentInChildren<PlayerMovement>();
            PlayerCollisionSenses = GetComponentInChildren<PlayerCollisionSenses>();

            if (!PlayerMovement || !PlayerCollisionSenses)
                Debug.LogError("Missing core component!");
        }

        protected virtual void OnValidate()
        {
            PlayerMovement = GetComponentInChildren<PlayerMovement>();
            PlayerCollisionSenses = GetComponentInChildren<PlayerCollisionSenses>();

            if (!PlayerMovement || !PlayerCollisionSenses)
                Debug.LogError("Missing core component!");
        }

        public void LogicUpdate()
        {
            PlayerMovement.LogicUpdate();
        }
    }
}
