using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
	public class EnemyStunState : EnemyState
	{
		protected D_EnemyStunState stateData;
		protected bool isTimeOver;
		
		public EnemyStunState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyStunState data)
			: base(stateMachine, entity, animBoolName)
		{
			stateData = data;
		}

		public override void Enter()
		{
			base.Enter();

			isTimeOver = false;
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();

			isTimeOver = Time.time - StartTime >= stateData.StunTime;
			
			if(isDetectingGround) Movement.SetVelocityZero();
		}
	}
}