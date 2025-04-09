using Animancer;
using UnityEngine;

[CreateAssetMenu (fileName = "StateAnimations", menuName = "State Animations")]
    public class StateAnimations : ScriptableObject
    {
        public TransitionAsset idle;
        public TransitionAsset sprint;
        public TransitionAsset jump;
        public TransitionAsset airborneUp;
        public TransitionAsset airborneDown;
        public TransitionAsset wallrunLeft;
        public TransitionAsset wallrunRight;
        public TransitionAsset wallrunUp;
        public TransitionAsset wallJumpUp;
        public TransitionAsset wallJumpBack;
        public TransitionAsset wallJumpRight;
        public TransitionAsset wallJumpLeft;

    }
