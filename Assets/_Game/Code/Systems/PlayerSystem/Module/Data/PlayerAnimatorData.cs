using UnityEngine;

namespace Game.Systems.PlayerSystem.Data
{
    [System.Serializable]
    public class PlayerAnimatorData
    {
        [SerializeField]
        private BodyParts bodyPart;
        [SerializeField]
        private Animator animator;

        public BodyParts BodyPart => bodyPart;
        public Animator Animator => animator; 
    }
}