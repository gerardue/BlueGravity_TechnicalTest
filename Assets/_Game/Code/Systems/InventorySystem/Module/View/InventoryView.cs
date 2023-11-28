using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Game.Systems.InventorySystem.View
{
    public class InventoryView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private GameObject inventoryUI;
        
        [Header("Item Prefab")]
        [SerializeField]
        private InventoryItemView inventoryItem;
        
        [Header("Other components")]
        [SerializeField]
        private Transform parentItems;
        
        private List<InventoryItemView> items = new List<InventoryItemView>();
        
        #region Public Methods
        
        public void Initialize()
        {
            inventoryUI.SetActive(true);
        }
        
        public void Dispose()
        {
            Debug.Log(items.Count);
            foreach (InventoryItemView item in items)
            {
                ObjectPool.Instance.Recycle(item.gameObject);
            }
            items.Clear();
            // inventoryUI.SetActive(false);
        }
        
        public void CreateItem(int aItemId, string aNameItem, int price, Sprite aIcon, Action<int> aOnSell, 
            Action<int> aOnEquip, Action<int> onRemoveItem)
        {
            var item = ObjectPool.Instance.CreateObject(inventoryItem, parentItems);
            item.Initialize(aItemId, aNameItem, price, aIcon, aOnSell, aOnEquip, onRemoveItem);
            items.Add(item);
        }
        
        #endregion
    }
}