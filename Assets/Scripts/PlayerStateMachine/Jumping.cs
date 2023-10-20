using HierarchicalFSM;

using UnityEngine;

public class Jumping : BaseState
{
	private PlayerStateMachine sm;

	private float jumpForce = 10f;
	private bool grounded;
	private int groundLayer = 1 << 6;

	public Jumping (PlayerStateMachine _stateMachine) : base ("Jumping", _stateMachine)
	{
		sm = (PlayerStateMachine) this.stateMachine;
	}

	public override void Enter ()
	{
		base.Enter ();

		Vector3 velocity = sm.Rigidbody.velocity;
		velocity.y += jumpForce;
		sm.Rigidbody.velocity = velocity;
	}

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();

		if (grounded)
			stateMachine.ChangeState (sm.IdleState);
	}
	public override void UpdatePhysics ()
	{
		base.UpdatePhysics ();

		RaycastHit[] hits = Physics.SphereCastAll (sm.transform.position, 1.05f, Vector3.down,
			1.5f, groundLayer, QueryTriggerInteraction.Ignore);

		grounded = sm.Rigidbody.velocity.y < Mathf.Epsilon && hits.Length > 0;
	}	
}