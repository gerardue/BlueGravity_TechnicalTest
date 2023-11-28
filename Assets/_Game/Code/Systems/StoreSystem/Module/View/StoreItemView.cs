using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Systems.StoreSystem.View
{
    public class StoreItemView : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TextMeshProUGUI nameText;

        [SerializeField]
        private TextMeshProUGUI priceText;
        
        [SerializeField]
        private Button buyButton;

        private int itemId;

        #region Public Methods

        public void Initialize(int aItemId, string aNameItem, int price, Sprite aIcon, Action<int> aOnBuy)
        {
            itemId = aItemId;
            nameText.text = aNameItem;
            icon.sprite = aIcon;

            priceText.text = price.ToString();
            
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() => aOnBuy?.Invoke(itemId));
        }

        #endregion

        #region Private Methods

       

        #endregion
    }
}