namespace Suhdo.Weapons.Components
{
	public class Movement : WeaponComponent<MovementData, AttackMovement>
	{
		private Suhdo.Movement coreMovement;
		private Suhdo.Movement CoreMovement => coreMovement ??= Core.GetCoreComponent<Suhdo.Movement>();

		protected override void Start()
		{
			base.Start();
			
			eventHandler.OnStartMovement += HandleStartMovement;
			eventHandler.OnStopMovement += HandleStopMovement;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
			eventHandler.OnStartMovement -= HandleStartMovement;
			eventHandler.OnStopMovement -= HandleStopMovement;
		}

		private void HandleStartMovement()
		{
			CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
		}

		private void HandleStopMovement()
		{
			CoreMovement.SetVelocityZero();
		}
	}
}