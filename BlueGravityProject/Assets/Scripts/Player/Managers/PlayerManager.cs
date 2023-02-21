using System.Collections;
using System.Collections.Generic;
using Test.Player.StateMachineSystem;
using Test.Player.Movement;
using UnityEngine;
using Test.DialogueSystem;
using Test.UI;
using Test.Player.Skins;
using Test.Player.InventorySystem;

namespace Test.Player
{
    public class PlayerManager : MonoBehaviour, IShopCustomer
    {
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerTalkState TalkState { get; private set; }

        [field: SerializeField] public string stateName { get; set; }

        [field: SerializeField] public PlayerData playerData { get; private set; }

        [field: SerializeField] public CanvasManager CanvasManager { get; private set; }
        //public DialogueManager DialogueManager { get; private set; }
        [field: SerializeField] public InventoryManager ShopInventoryManager { get; private set; }
        [field: SerializeField] public PlayerInventory PlayerInventory { get; private set; }

        public Animator Anim { get; private set; }
        public PlayerInputController InputController { get; private set; }
        public AppearanceController AppearanceController { get; private set; }
        public CapsuleCollider2D MovementCollider { get; private set; }
        public Rigidbody2D RB { get; private set; }
        [field: SerializeField] public RenderedArea HeadRenderArea { get; private set; }
        [field: SerializeField] public RenderedArea BodyRenderedArea { get; private set; }

        public Inventory inventory { get; private set; }


        [SerializeField] private Transform wallCheck;
        private Vector2 workspace;
        public Vector2 facingDirection;
        public int lastXFacingDirection;
        public int lastYFacingDirection;
        public int StartGoldAmount;
        public int currentGoldAmount;



        private void Awake()
        {
            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
            TalkState = new PlayerTalkState(this, StateMachine, playerData, "Talk");

            Anim = GetComponentInChildren<Animator>();
            RB = GetComponent<Rigidbody2D>();
            InputController = GetComponentInChildren<PlayerInputController>();
            AppearanceController = GetComponentInChildren<AppearanceController>();
            MovementCollider = GetComponent<CapsuleCollider2D>();
            lastXFacingDirection = 1;
            inventory = new Inventory();
            ShopInventoryManager.SetInventory(inventory);
            StartGoldAmount = 200;
            currentGoldAmount = StartGoldAmount;
            GetGoldAmount();
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
                ChangeRenderedArea();
            }
            GetGoldAmount();
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
        public void SetLastYDirection(int xInput,int yInput)
        {
            if (xInput == 0)
            {
                lastYFacingDirection = yInput;
            }
            else
            {
                lastYFacingDirection = 0;
            }

        }
        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != lastXFacingDirection)
            {
                Flip();
                lastXFacingDirection = xInput;
            }
        }
        private void Flip()
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        public void ChangeRenderedArea()
        {
            if(InputController.NormInputX != 0)
            {
                HeadRenderArea.SetIsSide();
                BodyRenderedArea.SetIsSide();
            }
            else
            {
                if(InputController.NormInputY != 0)
                {
                    if (InputController.NormInputY > 0)
                    {
                        HeadRenderArea.SetIsBack();
                        BodyRenderedArea.SetIsBack();
                    }
                    else
                    {
                        HeadRenderArea.SetIsFront();
                        BodyRenderedArea.SetIsFront();
                    }
                }

            }
        }

        public int GetGoldAmount()
        {
            return currentGoldAmount;
        }

        public void BoughtItem(Item.ItemType itemType)
        {
            Debug.Log("boughtItem" + itemType);
        }

        public void SelledItem(Item.ItemType itemType)
        {
            Debug.Log("SelledItem" + itemType);
        }

        public bool TrySpendGoldAmount(int spendGoldAmount)
        {
            if(GetGoldAmount() >= spendGoldAmount)
            {
                currentGoldAmount -= spendGoldAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SellItem(int goldAmount)
        {
            currentGoldAmount += goldAmount;
        }
    }


}

