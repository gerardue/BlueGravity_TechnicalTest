using Game.Systems.UISystem.Director;
using Game.Systems.GameStateSystem.Director;
using Game.Systems.InventorySystem.Director;
using Game.Systems.PlayerSystem.Director;
using Game.Systems.StoreSystem.Director;
using UnityEngine;

namespace Game.GameDirectors.GamePlayDirector
{
    public class GameplayDirector : MonoBehaviour
    {
        [SerializeField]
        private PlayerDirector playerDirector;
        
        [SerializeField]
        private StoreDirector storeDirector;

        [SerializeField]
        private InventoryDirector inventoryDirector; 

        [SerializeField]
        private GameStateDirector gameStateDirector;

        [SerializeField]
        private UIDirector uiDirector;
        
        #region Unity Methods
        
        private void Awake()
        {
            playerDirector.Initialize(storeDirector.GetItem);
            inventoryDirector.Initialize(storeDirector.GetItem, gameStateDirector.UpdateCoin, playerDirector.EquipItem);
            storeDirector.Initialize(gameStateDirector.UpdateCoin, inventoryDirector.AddItemToinventory);
            uiDirector.Initialize(storeDirector.OpenStore, inventoryDirector.OpenInventory);
        }
        
        private void OnEnable()
        {
            gameStateDirector.OnUpdateCoin += storeDirector.UpdateCoins;
        }

        private void OnDisable()
        {
            gameStateDirector.OnUpdateCoin -= storeDirector.UpdateCoins;
        }

        #endregion
        
        #region Public Methods

        

        #endregion

        #region Private Methods

        

        #endregion
    }
}