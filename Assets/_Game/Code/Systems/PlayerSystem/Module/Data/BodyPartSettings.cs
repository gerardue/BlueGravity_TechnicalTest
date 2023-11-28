using UnityEngine;

namespace Game.Systems.PlayerSystem.Data
{
    [System.Serializable]
    public class BodyPartAnimations
    {
        public PlayerStateType playerState;
        public AnimationClip[] animations;
    }
    
    [CreateAssetMenu(fileName = "BodyPart", menuName = "Game/Player/Body Part")]
    public class BodyPartSettings : ScriptableObject
    {
        [SerializeField]
        private int id;

        [SerializeField]
        private BodyPartAnimations[] animations;

        public int Id => id;
        public BodyPartAnimations[] Animations => animations;
    }
}