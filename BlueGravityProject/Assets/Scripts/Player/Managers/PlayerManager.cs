using System.Collections;
using System.Collections.Generic;
using Test.Player.StateMachineSystem;
using Test.Player.Movement;
using UnityEngine;
using Test.UI.DialogueSystem;
using Test.UI;

namespace Test.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerTalkState TalkState { get; private set; }

        [SerializeField] public string stateName;

        [SerializeField] public PlayerData playerData;

        public CanvasManager canvasManager { get; private set; }
        public Animator Anim { get; private set; }
        public PlayerInputController InputController { get; private set; }
        public CircleCollider2D MovementCollider { get; private set; }
        public Rigidbody2D RB { get; private set; }

        [SerializeField] private Transform wallCheck;
        private Vector2 workspace;
        public Vector2 facingDirection;
        public Vector2 lastFacingDirection;



        private void Awake()
        {
            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
            TalkState = new PlayerTalkState(this, StateMachine, playerData, "Talk");

            canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();

            Anim = GetComponentInChildren<Animator>();
            RB = GetComponent<Rigidbody2D>();
            InputController = GetComponentInChildren<PlayerInputController>();
            MovementCollider = GetComponent<CircleCollider2D>();
        }
        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }
        private void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
            stateName = StateMachine.CurrentState.StateName();

            if(StateMachine.CurrentState != TalkState)
            {
                facingDirection = new Vector2(InputController.NormInputX, InputController.NormInputY);
            }
            else
            {
                facingDirection = Vector2.zero;
            }
            
        }
        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        public void SetVelocityZero()
        {
            RB.velocity = Vector2.zero;
        }
        public void SetVelocity(int xInput,int yInput,float velocity)
        {
            workspace.Set(xInput *velocity, yInput * velocity);
            RB.velocity = workspace;
        }

        public bool CheckIfTouchingWall()
        {
            return Physics2D.Raycast(wallCheck.position, facingDirection, playerData.wallCheckDistance, playerData.whatIsWall);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(wallCheck.position, (Vector2)wallCheck.position + ( playerData.wallCheckDistance * facingDirection));
        }
        public void SetLastDirection()
        {
            if(facingDirection.x != 0 || facingDirection.y != 0)
            {
                lastFacingDirection = facingDirection;
            }
        }

    }


}

