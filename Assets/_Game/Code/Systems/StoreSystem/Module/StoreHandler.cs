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

        private int currentLvl = 0; 
        
        private Func<int> onGetLevelStore; // It takes the lvl player to configure the store
        private Action<int> onBuyItem;
        
        #region Public Methods
        
        public void Initialize(Action<int> aOnDebitItem, Action<int> aOnAddItem)
        {
            storeController.Initialize(aOnDebitItem, aOnAddItem);
        }

        public void OpenStore()
        {
            SetupStore();
            store.Initialize();
        }

        public void CloseStore()
        {
            store.Dispose();
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