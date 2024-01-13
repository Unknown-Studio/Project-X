using Suhdo.Player;
using Suhdo.StateMachineCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suhdo
{
    public class PlayerWallSlideState : PlayerGroundState
    {
        public PlayerWallSlideState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

    }
}
