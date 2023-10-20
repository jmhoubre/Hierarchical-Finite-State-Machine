using HierarchicalFSM;

using UnityEngine;

public class Grounded : BaseState
{
	protected PlayerStateMachine sm;
	protected Vector3 moveInput;

	public Grounded(string _name, PlayerStateMachine _stateMachine) : base (_name, _stateMachine)
    {
		sm = (PlayerStateMachine) stateMachine;
	}

	public override void Enter ()
	{
		moveInput = Vector3.zero;
	}

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();

		moveInput = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")).normalized;

		if (Input.GetKeyDown (KeyCode.Space))
		{
			stateMachine.ChangeState (sm.JumpingState);
		}
	}
}