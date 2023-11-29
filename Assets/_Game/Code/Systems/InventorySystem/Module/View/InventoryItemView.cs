using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Game.Systems.InventorySystem.View
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI nameItemText;
        
        [SerializeField]
        private Image icon;

        [SerializeField]
        private Button sellButton; 
        
        [SerializeField]
        private Button equipButton;

        private int itemId;
        private int price;

        private Action<int> onRemoveItem;
        
        public int ItemId => itemId;
        
        #region Public Methods

        public void Initialize(int aItemId, string aNameItem, int aPrice, Sprite aIcon, Action<int> aOnSell, 
            Action<int> aOnEquip, Action<int> aOnRemoveItem)
        {
            itemId = aItemId;
            nameItemText.text = aNameItem;
            price = aPrice;
            icon.sprite = aIcon; 
            onRemoveItem = aOnRemoveItem;
            
            sellButton.onClick.RemoveAllListeners();
            sellButton.onClick.AddListener(() =>
            {
                aOnSell?.Invoke(price);
                aOnRemoveItem?.Invoke(itemId);
                RecycleItem();
            });
            
            equipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() =>
            {
                aOnEquip?.Invoke(itemId);
            });
            
        }

        #endregion

        #region Private Methods

        private void RecycleItem()
        {
            ObjectPool.Instance.Recycle(gameObject);
        }

        #endregion
    }
}