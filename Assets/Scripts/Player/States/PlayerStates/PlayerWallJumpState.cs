using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState
{
    private StateMachine stateMachine;
    private PlayerWallJumpRight _playerWallJumpRight;
    private PlayerWallJumpLeft _playerWallJumpLeft;
    private PlayerWallJumpBackward _playerWallJumpBackward;
    private PlayerWallJumpForward _playerWallJumpForward;
    
    public PlayerWallJumpState(PlayerContext context) : base(context)
    {
        stateMachine = new StateMachine();
        _playerWallJumpBackward = new PlayerWallJumpBackward(context);
        _playerWallJumpForward = new PlayerWallJumpForward(context);
        _playerWallJumpLeft = new PlayerWallJumpLeft(context);
        _playerWallJumpRight = new PlayerWallJumpRight(context);
        
        stateMachine.RegisterState(_playerWallJumpRight);
        stateMachine.RegisterState(_playerWallJumpLeft);
        stateMachine.RegisterState(_playerWallJumpBackward);
        stateMachine.RegisterState(_playerWallJumpForward);
        
        
    }

    public override void OnEnter()
    {
        if (_surfaceDetector.WallLeft)
        {
            stateMachine.SetCurrentState(_playerWallJumpLeft);

        }
        else if (_surfaceDetector.WallRight)
        {
            stateMachine.SetCurrentState(_playerWallJumpRight);

        }
        else if (_surfaceDetector.WallBackward)
        {
            stateMachine.SetCurrentState(_playerWallJumpBackward);

        }
        else if (_surfaceDetector.WallForward)
        {
            stateMachine.SetCurrentState(_playerWallJumpForward);
        }
    }

 
}