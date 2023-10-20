namespace HierarchicalFSM
{
	/// <summary>
	/// Cette classe est la classe des états de la machine à état.	
	/// </summary>
	public class BaseState
	{
		public string Name;
		protected StateMachine stateMachine;

        public BaseState(string _name, StateMachine _stateMachine)
        {
			Name = _name;
			stateMachine = _stateMachine;
        }

		public virtual void Enter () { }
		public virtual void Exit () { }
		public virtual void UpdateLogic () { }
		public virtual void UpdatePhysics () { }		
	}
}