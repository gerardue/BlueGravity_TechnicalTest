using System;
using Game.Components.ItemsComponent.Data;
using UnityEngine;

namespace Game.Systems.PlayerSystem.Controller
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerCustomizerController customizerController;

        private Func<int, ItemSetup> onGetItem;
        
        #region Public Methods

        public void Initialize(Func<int, ItemSetup> aOnGetItem)
        {
            onGetItem = aOnGetItem; 
        }
        
        public void EquipItem(int id)
        {
            var item = onGetItem?.Invoke(id); 
            customizerController.CustomizePlayer(item.ItemCategory.ToString(), item.Id);
        }

        #endregion
    }
}