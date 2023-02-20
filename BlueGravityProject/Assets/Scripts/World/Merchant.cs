using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.ShopSystem
{
    public class Merchant : MonoBehaviour
    {
        [field: SerializeField] public ShopStockManager ShopStockManager { get; private set; }
        private ShopStock shopStock;

        private void Start()
        {
            shopStock = new ShopStock();
            ShopStockManager.SetStock(shopStock);
        }
    }
}

