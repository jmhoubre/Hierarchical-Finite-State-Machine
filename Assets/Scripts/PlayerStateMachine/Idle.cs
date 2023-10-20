using UnityEngine;

public class Idle : Grounded
{
	public Idle (PlayerStateMachine _stateMachine) : base ("Idle", _stateMachine) { }

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();

		if (moveInput.sqrMagnitude > Mathf.Epsilon)
		{
			stateMachine.ChangeState (sm.MovingState);
		}
	}
}