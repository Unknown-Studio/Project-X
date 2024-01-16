using Suhdo.Generics;
using Suhdo.Player;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class PlayerCore : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerCollisionSenses _playerCollisionSenses;
        private PlayerCombat _playerCombat;

        public PlayerMovement PlayerMovement
        {
            get => GenericNotImplementedError<PlayerMovement>.TryGet(_playerMovement, transform.parent.name);
            private set => _playerMovement = value;
        }

        public PlayerCollisionSenses PlayerCollisionSenses
        {
            get => GenericNotImplementedError<PlayerCollisionSenses>.TryGet(_playerCollisionSenses, transform.parent.name);
            private set => _playerCollisionSenses = value;
        }

        public PlayerCombat PlayerCombat
        {
            get => GenericNotImplementedError<PlayerCombat>.TryGet(_playerCombat, transform.parent.name);
            private set => _playerCombat = value;
        }

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
