using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/ Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        public float movementVelocity = 10f;
        public float maxVelocity = 25f;

        [Header("Check Variables")]
        public float wallCheckDistance = 0.5f;
        public LayerMask whatIsWall;
    }
}


