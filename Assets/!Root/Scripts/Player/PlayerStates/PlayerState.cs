using Suhdo.CharacterCore;
using Suhdo.Player;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo
{
    public class PlayerState : CoreState
    {
        protected PlayerData playerData;
        protected PlayerController player;
        
        protected PlayerCollisionSenses CollisionSenses => _collisionSenses ??= Core.GetCoreComponent<PlayerCollisionSenses>();
        protected Movement Movement => _movement ??= Core.GetCoreComponent<Movement>();
        protected Stats Stats => _stats ??= Core.GetCoreComponent<Stats>();

        private PlayerCollisionSenses _collisionSenses;
        private Movement _movement;
        private Stats _stats;
            
        public PlayerState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName)
        {
            player = (PlayerController)entity;
            playerData = data;
        }
    }
}
