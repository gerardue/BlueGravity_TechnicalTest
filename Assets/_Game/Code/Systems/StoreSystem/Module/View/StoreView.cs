using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Game.Systems.StoreSystem.View
{
    public class StoreView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private GameObject storeUI;
        [SerializeField]
        private TextMeshProUGUI coinText;
        
        [Header("Item Prefab")]
        [SerializeField]
        private StoreItemView storeItem;
        
        [Header("Other components")]
        [SerializeField]
        private Transform parentItems;

        [SerializeField]
        private Button closeButton; 

        [Header("PopUp")]
        [SerializeField]
        private GameObject popUp; 

        private List<StoreItemView> items = new List<StoreItemView>();
        
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
            storeUI.SetActive(true);
            onOpen = aOnOpen; 
            onOpen?.Invoke(true);
        }

        public void Dispose()
        {
            foreach (StoreItemView item in items)
            {
                ObjectPool.Instance.Recycle(item.gameObject);
            }
            
            items.Clear();
            storeUI.SetActive(false);
            onOpen?.Invoke(false);
        }
        
        public void CreateItem(int aItemId, string aNameItem, int price, Sprite aIcon, Action<int> aOnBuy)
        {
            var item = ObjectPool.Instance.CreateObject(storeItem, parentItems);
            item.Initialize(aItemId, aNameItem, price, aIcon, aOnBuy);
            items.Add(item);
        }

        public void UpdateCoins(int currentAmountCoins)
        {
            coinText.text = currentAmountCoins.ToString(); 
        }
        
        public void OpenPopUp()
        {
            popUp.SetActive(true);
        }
        
        #endregion

        #region Private Methods

        
        #endregion
    }
}