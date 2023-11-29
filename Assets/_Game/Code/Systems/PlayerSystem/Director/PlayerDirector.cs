using System;
using Game.Components.ItemsComponent.Data;
using Game.Systems.PlayerSystem.Controller;
using Game.Systems.PlayerSystem.Data;
using UnityEngine;

namespace Game.Systems.PlayerSystem.Director
{
    public class PlayerDirector : MonoBehaviour
    {
        [SerializeField]
        private PlayerCustomizerController customizerController;

        [SerializeField]
        private PlayerRuntimeData runtimeData;
        
        private Func<int, ItemSetup> onGetItem;
        
        #region Public Methods
        
        public void Initialize(Func<int, ItemSetup> aOnGetItem)
        {
            onGetItem = aOnGetItem;
        }
        
        public void EquipItem(int id)
        {
            var item = onGetItem?.Invoke(id); 
            customizerController.CustomizePlayer(item.ItemCategory.ToString(), item.ItemId);
        }
        
        public void SetPlayerBusy(bool value)
        {
            runtimeData.SetPlayerBusy(value);
        }
        
        #endregion
    }
}