using System;
using System.Collections;
using System.Collections.Generic;
using Game.Systems.StoreSystem.Controller;
using Game.Systems.StoreSystem.Handler;
using Game.Components.ItemsComponent.Data;
using UnityEngine;

namespace Game.Systems.StoreSystem.Director
{
    public class StoreDirector : MonoBehaviour
    {
        [SerializeField]
        private StoreHandler storeHandler;
        [SerializeField]
        private StoreController storeController; 

        #region Public Methods

        public void Initialize( Action<int> aOnDebitItem, Action<int> aOnAddItem)
        {
            storeHandler.Initialize(aOnDebitItem, aOnAddItem);
        }
        
        public void OpenStore()
        {
            storeHandler.OpenStore();
        }
        
        public void CloseStore()
        {
            storeHandler.CloseStore();
        }
        
        public void UpdateCoins(int aCurrentAmountCoins)
        {
            storeHandler.UpdateCoins(aCurrentAmountCoins);
        }
        
        public ItemSetup GetItem(int aItemId)
        {
            return storeController.GetItem(aItemId);
        }
        
        #endregion
    }
}
