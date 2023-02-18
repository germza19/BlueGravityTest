using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.StateMachineSystem
{
    public class PlayerState
    {
        protected PlayerManager playerManager;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;
        private string animBoolName;

        protected bool isAnimationFinished;
        protected bool isExitingState;

        protected float startTime;


        public PlayerState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.playerManager = playerManager;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            playerManager.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
            isAnimationFinished = false;
            isExitingState = false;
        }
        public virtual void Exit()
        {
            playerManager.Anim.SetBool(animBoolName, false);
            isExitingState = true;
        }
        public virtual void LogicUpdate()               // Called every frame , like update
        {

        }
        public virtual void PhysicsUpdate()             // Called like fixedUpdate
        {
            DoChecks();
        }
        public virtual void DoChecks()                  // Called from enterState and PhysicsUpdate
        {

        }
        public virtual void AnimationTrigger()
        {

        }
        public virtual void AnimationFinishedTrigger()
        {
            isAnimationFinished = true;
        }
        public virtual string StateName()
        {
            return animBoolName;
        }
    }

}
