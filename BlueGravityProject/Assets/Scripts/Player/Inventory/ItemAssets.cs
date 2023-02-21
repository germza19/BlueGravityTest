using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.InventorySystem
{
    public class ItemAssets : MonoBehaviour
    {
        public static ItemAssets Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public GameObject pfItemButton;

        //public int headIndex = 0;
        //public int bodyIndex = 1;

        public Sprite farmerHeadSprite;
        public Sprite farmerBodySprite;

        public Sprite samuraiHeadSprite;
        public Sprite samuraiBodySprite;

        public Sprite skullHeadsprite;
        public Sprite skullBodySprite;

        public Sprite soldierHeadSprite;
        public Sprite soldierBodySprite;


    }

}
