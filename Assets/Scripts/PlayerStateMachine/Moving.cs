using UnityEngine;

public class Moving : Grounded
{
	public Moving (PlayerStateMachine _stateMachine) : base ("Moving", _stateMachine) { }
	
	public override void UpdateLogic ()
	{
		base.UpdateLogic ();

		if (moveInput.sqrMagnitude < Mathf.Epsilon)
		{
			stateMachine.ChangeState (sm.IdleState);
		}
	}

	public override void UpdatePhysics ()
	{
		base.UpdatePhysics ();

		sm.Rigidbody.velocity = new Vector3 (
			moveInput.x * ((PlayerStateMachine) stateMachine).Speed,
			sm.Rigidbody.velocity.y,
			moveInput.z * ((PlayerStateMachine) stateMachine).Speed);
	}
}