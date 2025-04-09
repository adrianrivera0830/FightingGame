
public abstract class BaseState<T> : IState where T : class
    {
        protected T ctx;
        
        public BaseState(T t)
        {
            ctx = t;
        }
        
        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual void OnLateUpdate()
        {
        }
    }
