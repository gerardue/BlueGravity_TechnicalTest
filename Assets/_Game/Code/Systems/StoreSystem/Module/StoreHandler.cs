using System;
using Game.Systems.StoreSystem.Controller;
using Game.Components.ItemsComponent.Data;
using Game.Systems.StoreSystem.View;
using Game.Store.Data;
using UnityEngine;

namespace Game.Systems.StoreSystem.Handler
{
    public class StoreHandler : MonoBehaviour
    {
        [SerializeField]
        private StoreController storeController;
        
        [SerializeField]
        private StoreItemLibrary storeItemsLibrary;
        
        [SerializeField]
        private StoreView store;
        
        private Func<int, bool> onBuyItem;
        private Action<bool> onOpen;
        
        #region Public Methods
        
        public void Initialize(Func<int, bool> aOnDebitItem, Action<int> aOnAddItem, Action<bool> aOnOpen)
        {
            storeController.Initialize(aOnDebitItem, aOnAddItem, store.OpenPopUp);
            onOpen = aOnOpen;
        }

        public void OpenStore()
        {
            SetupStore();
            store.Initialize(onOpen);
        }

        public void UpdateCoins(int aCurrentAmountCoins)
        {
            store.UpdateCoins(aCurrentAmountCoins);
        }
        
        #endregion

        #region Private Methods
        
        private void SetupStore()
        {
            store.Dispose();
            
            foreach (ItemSetup item in storeItemsLibrary.StoreItems)
            {
                store.CreateItem(item.Id, item.NameItem, item.Price, item.Icon, storeController.BuyItem);
            }
        }
        
        #endregion
    }
}