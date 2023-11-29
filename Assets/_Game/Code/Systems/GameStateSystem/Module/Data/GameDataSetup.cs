using UnityEngine;

namespace Game.Systems.GameStateSystem.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game/GameData")]
    public class GameDataSetup : ScriptableObject
    {
        [SerializeField]
        private int coins;

        public int Coins
        {
            get => coins;
            set => coins = value;
        }
    }
}