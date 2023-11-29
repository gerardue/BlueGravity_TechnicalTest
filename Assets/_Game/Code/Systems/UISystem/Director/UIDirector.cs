using System;
using Game.Systems.UISystem.View;
using UnityEngine;

namespace Game.Systems.UISystem.Director
{
    public class UIDirector : MonoBehaviour
    {
        [SerializeField]
        private MenusHandlerView menusHandlerView;

        [SerializeField]
        private HudView hudView;

        #region Public Methods

        public void Initialize(Action aOnInventory)
        {
            menusHandlerView.Initialize(aOnInventory);
        }
        
        public void UpdateCoinText(int coins)
        {
            hudView.UpdateCoinText(coins);
        }
        
        public void UpdateHappiness(int currentHappiness, int maxHappiness)
        {
            hudView.UpdateHappiness(currentHappiness, maxHappiness); 
        }

        #endregion
    }
}