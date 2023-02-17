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
        public PlayerIdleState(PlayerManager player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            XInput = player.InputController.NormInputX;
            YInput = player.InputController.NormInputY;
            isTouchingWall = player.CheckIfTouchingWall();
            Debug.Log(isTouchingWall);
        }

        public override void Enter()
        {
            base.Enter();

            player.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            player.SetVelocityZero();

            if ((XInput !=0 || YInput != 0 ) && !isTouchingWall)
            {
                stateMachine.ChangeState(player.MoveState);
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

