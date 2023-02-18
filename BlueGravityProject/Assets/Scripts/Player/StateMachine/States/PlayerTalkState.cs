using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.StateMachineSystem
{
    public class PlayerTalkState : PlayerState
    {
        public PlayerTalkState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            playerManager.InputController.ShiftActionMapToUI();

        }

        public override void Exit()
        {
            base.Exit();

            //player.InputController.ShiftActionMapToPlayer();
            //player.CanvasManager.SetDialoguePanel(false);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            playerManager.SetVelocityZero();

            //if(player.InputController.InteractInput)
            //{
            //    player.InputController.PressedInteract();
            //    stateMachine.ChangeState(player.IdleState);
            //}
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

