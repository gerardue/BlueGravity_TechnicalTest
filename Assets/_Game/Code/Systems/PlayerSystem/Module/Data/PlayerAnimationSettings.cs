using UnityEngine;

namespace Game.Systems.PlayerSystem.Data
{
    public enum PlayerStateType
    {
        Idle, 
        Walk
    }

    public enum PlayerDirectionTypes
    {
        Back,
        Front,
        Left,
        LeftDown,
        LeftUp,
        Right,
        RightDown,
        RightUp
    }
    
    [CreateAssetMenu(fileName = "PlayerAnimationSettings", menuName = "Game/Player/Animation Settings")]
    public class PlayerAnimationSettings : ScriptableObject
    {
        [SerializeField]
        private PlayerStateType[] playerStates;

        [SerializeField]
        private PlayerDirectionTypes[] playerDirections;

        public PlayerStateType[] PlayerStates => playerStates;
        public PlayerDirectionTypes[] PlayerDirections => playerDirections; 
    }
}