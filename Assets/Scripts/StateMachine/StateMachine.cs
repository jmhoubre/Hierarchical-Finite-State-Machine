using UnityEngine;

namespace HierarchicalFSM
{	
	public class StateMachine : MonoBehaviour
	{
		protected BaseState currentState;

		private void Start ()
		{
			currentState = GetInitialState ();
			currentState?.Enter ();
		}

		private void Update ()
		{
			currentState?.UpdateLogic ();				
		}

		private void FixedUpdate ()
		{
			currentState?.UpdatePhysics ();
		}

		protected virtual BaseState GetInitialState () => null;

		public void ChangeState (BaseState _newState)
		{
			if (_newState == null || currentState == null)
				return;

			currentState.Exit ();
			currentState = _newState;
			currentState.Enter ();
		}

		private void OnGUI ()
		{
			GUILayout.BeginArea (new Rect (10f, 10f, 200f, 100f));
			string content = currentState != null ? currentState.Name : "(no current state)";
			GUILayout.Label ($"<color='black'><size=40>{content}</size></color>");
			GUILayout.EndArea ();
		}
	}
}