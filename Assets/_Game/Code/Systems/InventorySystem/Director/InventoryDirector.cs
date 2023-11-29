using System;
using Game.Components.ItemsComponent.Data;
using Game.Systems.InventorySystem.Handler;
using UnityEngine;

namespace Game.Systems.InventorySystem.Director
{
    public class InventoryDirector : MonoBehaviour
    {
        [SerializeField]
        private InventoryHandler inventoryHandler;
        
        #region Public Methods
        
        public void Initialize(Func<int, ItemSetup> aOnGetItem, Action<int> aOnSell, Action<int> aOnEquip, Action<bool> aOnOpen)
        {
            inventoryHandler.Initialize(aOnGetItem, aOnSell, aOnEquip, aOnOpen);
        }
        
        public void OpenInventory()
        {
            inventoryHandler.OpenInventory();
        }
        
        public void CloseInventory()
        {
            inventoryHandler.CloseInventory();
        }
        
        public void AddItemToinventory(int aId)
        {
            inventoryHandler.AddItemToInventory(aId);
        }
        
        #endregion
    }
}