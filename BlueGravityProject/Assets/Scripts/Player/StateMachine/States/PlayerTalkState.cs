using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.StateMachineSystem
{
    public class PlayerTalkState : PlayerState
    {
        public PlayerTalkState(PlayerManager player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            player.canvasManager.SetDialoguePanel(true);
        }

        public override void Exit()
        {
            base.Exit();

            player.canvasManager.SetDialoguePanel(false);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            player.SetVelocityZero();

            if(player.InputController.InteractInput)
            {
                player.InputController.PressedInteract();
                stateMachine.ChangeState(player.IdleState);
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

