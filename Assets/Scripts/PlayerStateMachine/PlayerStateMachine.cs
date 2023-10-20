using HierarchicalFSM;

using UnityEngine;


public class PlayerStateMachine : StateMachine
{
	[SerializeField] private float speed = 4f;
	
	[HideInInspector]
	public Idle IdleState;
	[HideInInspector]
	public Moving MovingState;
	[HideInInspector]
	public Jumping JumpingState;

	public Rigidbody Rigidbody { get; private set; }
	public float Speed { get => speed;private set { } }

	private void Awake ()
	{
		IdleState = new Idle (this);
		MovingState = new Moving (this);
		JumpingState = new Jumping (this);

		Rigidbody = GetComponent<Rigidbody> ();
	}

	protected override BaseState GetInitialState () => IdleState;
}