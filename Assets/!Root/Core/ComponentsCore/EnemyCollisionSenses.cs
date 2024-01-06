using Sirenix.OdinInspector;
using Suhdo.CharacterCore;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyCollisionSenses : EnemyCoreComponent
{
	[SerializeField] private LayerMask whatIsGround;

	[FoldoutGroup("Ground Check", expanded: false)] [SerializeField]
	private Transform groundCheck;
	[FoldoutGroup("Ground Check")] [SerializeField]
	private float groundCheckRadius;

	[FoldoutGroup("Wall Check", expanded: false)] [SerializeField]
	private Transform wallCheck;
	[FoldoutGroup("Wall Check")] [SerializeField]
	private float wallCheckDistance;
	
	[FoldoutGroup("Ledge Check", expanded: false)] [SerializeField]
	private Transform ledgeCheck;
	[FoldoutGroup("Ledge Check")] [SerializeField]
	private float ledgeCheckDistance;
	
	[FoldoutGroup("Player Check", expanded: false)] [SerializeField]
	private Transform attackPlayerPostion;
	[FoldoutGroup("Player Check")] [SerializeField]
	private float attackRadius;
	[FoldoutGroup("Player Check")] [Space(10)][SerializeField]
	private Transform playerCheck;
	[FoldoutGroup("Player Check")] [SerializeField]
	private float maxAgroDistance;
	[FoldoutGroup("Player Check")] [SerializeField]
	private float minAgroDistance;
	[FoldoutGroup("Player Check")] [SerializeField]
	private float closeRangeActionDistance;
	[FoldoutGroup("Player Check")] [SerializeField]
	private LayerMask whatIsPlayer;
	
	#region Public variables

	public LayerMask WhatIsGround => whatIsGround;
	
	public LayerMask WhatIsPlayer => whatIsPlayer;

	public Transform GroundCheck
	{
		get => groundCheck;
		private set => groundCheck = value;
	}

	public Transform WallCheck
	{
		get => wallCheck;
		private set => wallCheck = value;
	}

	public Transform AttackPlayerPosition => attackPlayerPostion;
	public float AttackRadius => attackRadius;

	public bool Ground => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

	public bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * EnemyCore.EnemyMovement.FacingDirection,
		wallCheckDistance, whatIsGround);

	public bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -EnemyCore.EnemyMovement.FacingDirection,
		wallCheckDistance, whatIsGround);

	public bool Ledge => Physics2D.Raycast(ledgeCheck.position, Vector2.down,
		ledgeCheckDistance, whatIsGround);

	public bool PlayerInMaxAgroRange => Physics2D.Raycast(playerCheck.position,
		Vector2.right * EnemyCore.EnemyMovement.FacingDirection,
		maxAgroDistance, whatIsPlayer);
	
	public bool PlayerInMinAgroRange => Physics2D.Raycast(playerCheck.position,
		Vector2.right * EnemyCore.EnemyMovement.FacingDirection,
		minAgroDistance, whatIsPlayer);

	public bool PlayerInCloseRangeAction => Physics2D.Raycast(playerCheck.position,
		Vector2.right * EnemyCore.EnemyMovement.FacingDirection,
		closeRangeActionDistance, whatIsPlayer);
	
	#endregion
	
	#region Gizmos

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
		Gizmos.DrawLine(wallCheck.position,
			wallCheck.position + (Vector3)(Vector2.right * EnemyCore.EnemyMovement.FacingDirection * wallCheckDistance));
		Gizmos.DrawLine(wallCheck.position,
			wallCheck.position + (Vector3)(Vector2.right * -EnemyCore.EnemyMovement.FacingDirection * wallCheckDistance));
		Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * ledgeCheckDistance));
		Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * EnemyCore.EnemyMovement.FacingDirection * closeRangeActionDistance), .2f);
		Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * EnemyCore.EnemyMovement.FacingDirection * minAgroDistance), .2f);
		Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * EnemyCore.EnemyMovement.FacingDirection * maxAgroDistance), .2f);
		Gizmos.DrawWireSphere(attackPlayerPostion.position, attackRadius);
	}

	#endregion
}
