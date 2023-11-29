using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Systems.UISystem.View
{
    public class HudView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI coinsText;

        [SerializeField]
        private Image happiness;

        #region Public Methods

        public void UpdateCoinText(int coins)
        {
            coinsText.text = coins.ToString();
        }
        
        public void UpdateHappiness(int currentHappiness, int maxHappiness)
        {
            happiness.fillAmount = currentHappiness / maxHappiness; 
        }
        
        #endregion
    }
}