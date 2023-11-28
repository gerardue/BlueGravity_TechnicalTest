using System;
using Game.Components.ItemsComponent.Data;
using Game.Store.Data;
using UnityEngine;

namespace Game.Systems.StoreSystem.Controller
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField]
        private StoreItemLibrary storeItemLibrary;

        private Action<int> onPurchase;
        private Action<int> onAddItem;
        
        #region Public Methods
        
        public void Initialize(Action<int> aOnPurchase, Action<int> aOnAddItem)
        {
            storeItemLibrary.InitializeItems();
            onPurchase = aOnPurchase;
            onAddItem = aOnAddItem; 
        }
        
        public void BuyItem(int itemId)
        {
            int price = storeItemLibrary.StoreItems[itemId].Price;
            onAddItem?.Invoke(itemId);
            onPurchase?.Invoke(-price);
        }
        
        public ItemSetup GetItem(int aItemId)
        {
            return storeItemLibrary.StoreItems[aItemId];
        }
        
        #endregion
    }
}