using System;
using Game.Components.ItemsComponent.Data;
using Game.Systems.InventorySystem.Data;
using Game.Systems.InventorySystem.View;
using UnityEngine;

namespace Game.Systems.InventorySystem.Handler
{
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField]
        private InventorySetup inventorySetup;

        [SerializeField]
        private InventoryView inventoryView;

        private Func<int, ItemSetup> onGetItem;
        private Action<int> onSell;
        private Action<int> onEquip;
        private Action<bool> onOpen;
        
        #region Public Methods

        public void Initialize(Func<int, ItemSetup> aOnGetItem, Action<int> aOnSell, Action<int> aOnEquip, Action<bool> aOnOpen)
        {
            onGetItem = aOnGetItem;
            onSell = aOnSell;
            onEquip = aOnEquip;
            onOpen = aOnOpen;
        }

        public void OpenInventory()
        { 
            SetupInventory();
            inventoryView.Initialize(onOpen);
        }

        public void CloseInventory()
        {
            inventoryView.Dispose();
        }

        public void AddItemToInventory(int aId)
        {
            inventorySetup.AddItem(aId);
        }
        
        #endregion

        #region Private Methods

        private void SetupInventory()
        {
            inventoryView.Dispose();
            
            for (int i = 0; i < inventorySetup.Items.Count; i++)
            {
                var item = onGetItem(inventorySetup.Items[i]);
                inventoryView.CreateItem(item.Id, item.NameItem, item.Price, item.Icon, onSell, onEquip, RemoveItemFromInventory);
            }
        }

        private void RemoveItemFromInventory(int aItemId)
        {
            var item = inventorySetup.Items.Find(x => x == aItemId);
            inventorySetup.Items.Remove(item);
        }

        #endregion
    }
}