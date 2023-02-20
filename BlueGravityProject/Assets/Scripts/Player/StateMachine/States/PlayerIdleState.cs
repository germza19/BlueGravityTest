using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Test.Player.StateMachineSystem
{
    public class PlayerIdleState : PlayerState
    {
        protected int XInput;
        protected int YInput;
        protected bool isTouchingWall;
        protected Vector2 facing;

        public PlayerIdleState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            XInput = playerManager.InputController.NormInputX;
            YInput = playerManager.InputController.NormInputY;
            isTouchingWall = playerManager.CheckIfTouchingWall();
        }

        public override void Enter()
        {
            base.Enter();

            playerManager.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            playerManager.SetVelocityZero();

            
            if ((XInput !=0 || YInput != 0 ) && !isTouchingWall)
            {
                playerManager.SetLastYDirection(XInput, YInput);
                playerManager.CheckIfShouldFlip(XInput);
                stateMachine.ChangeState(playerManager.MoveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override string StateName()
        {
            return base.StateName();
        }
    }
}

