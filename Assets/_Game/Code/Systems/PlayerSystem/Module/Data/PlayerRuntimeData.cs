using UnityEngine;

namespace Game.Systems.PlayerSystem.Data
{
    [CreateAssetMenu(fileName = "PlayerRuntimeData", menuName = "Game/Player/Runtime Data")]
    public class PlayerRuntimeData : ScriptableObject
    {
        [SerializeField]
        private bool isPlayerBusy;

        public void SetPlayerBusy(bool value)
        {
            isPlayerBusy = value; 
        }

        public bool IsPlayerBusy()
        {
            return isPlayerBusy;
        }
    }
}