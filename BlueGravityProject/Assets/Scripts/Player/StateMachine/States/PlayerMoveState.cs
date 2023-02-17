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
        public PlayerMoveState(PlayerManager player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            XInput = player.InputController.NormInputX;
            YInput = player.InputController.NormInputY;
            isTouchingWall = player.CheckIfTouchingWall();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if ((XInput == 0 && YInput == 0) || isTouchingWall)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                player.SetVelocity(XInput, YInput, playerData.movementVelocity);
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

