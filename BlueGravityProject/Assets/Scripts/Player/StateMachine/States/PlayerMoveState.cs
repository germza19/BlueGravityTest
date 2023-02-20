using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Test.Player.StateMachineSystem
{
    public class PlayerMoveState : PlayerState
    {

        protected int XInput;
        protected int YInput;
        protected bool isTouchingWall;

        public PlayerMoveState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
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
            playerManager.SetLastYDirection(XInput,YInput);
            playerManager.CheckIfShouldFlip(XInput);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            playerManager.SetLastYDirection(XInput,YInput);
            playerManager.CheckIfShouldFlip(XInput);
            if ((XInput == 0 && YInput == 0) || isTouchingWall)
            {
                stateMachine.ChangeState(playerManager.IdleState);
            }
            else
            {                
                playerManager.SetVelocity(XInput, YInput, playerData.movementVelocity);
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

