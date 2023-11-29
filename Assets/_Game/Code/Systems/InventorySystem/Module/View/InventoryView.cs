using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

        [SerializeField]
        private Button closeButton; 
        
        private List<InventoryItemView> items = new List<InventoryItemView>();

        private Action<bool> onOpen;

        #region Unity Methods

        private void OnEnable()
        {
            closeButton.onClick.AddListener(Dispose);
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveAllListeners();
        }

        #endregion
        
        #region Public Methods
        
        public void Initialize(Action<bool> aOnOpen)
        {
            inventoryUI.SetActive(true);
            onOpen = aOnOpen;
            onOpen?.Invoke(true);
        }
        
        public void Dispose()
        {
            foreach (InventoryItemView item in items)
            {
                ObjectPool.Instance.Recycle(item.gameObject);
            }
            items.Clear();
            inventoryUI.SetActive(false);
            onOpen?.Invoke(false);
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