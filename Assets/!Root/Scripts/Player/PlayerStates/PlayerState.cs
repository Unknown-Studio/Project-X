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
        protected readonly PlayerCore PlayerCore;
            
        public PlayerState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName)
        {
            player = (PlayerController)entity;
            playerData = data;
            PlayerCore = player.PlayerCore;
        }
    }
}
