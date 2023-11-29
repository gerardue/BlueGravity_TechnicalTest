using System;
using System.Linq;
using Game.Components.ItemsComponent.Data;
using Game.Systems.PlayerSystem.Data;
using UnityEngine;

namespace Game.Systems.PlayerSystem.Controller
{
    public class PlayerCustomizerController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField]
        private PlayerAnimatorData[] animatorData;

        [SerializeField]
        private BodySettings bodySettings;

        [SerializeField]
        private PlayerAnimationSettings playerAnimationSettings;

        [Header("Testing")]
        [SerializeField]
        private string bodyPart;
        [SerializeField]
        private int id;
        
        // Animation
        private Animator animator;
        private AnimationClip animationClip;
        private AnimatorOverrideController animatorOverrideController;
        private AnimationClipOverrides defaultAnimationClips;

        

        #region Public Methods

        public void CustomizePlayer(string aBodyPart, int aIdAnimation)
        {
            Debug.Log(aBodyPart + " " + aIdAnimation);
            UpdateBodyPart(aBodyPart, aIdAnimation);
        }

        #endregion

        #region Private Methods

        [ContextMenu("Set Customize")]
        private void SetCustomize()
        {
            UpdateBodyPart(bodyPart, id);
        }
        
        private void UpdateBodyPart(string aBodyPart, int aIdAnimation)
        {
            BodyParts.TryParse(aBodyPart, out BodyParts bodyPartId);
            animator = animatorData.Where(x => x.BodyPart == bodyPartId).First().Animator; // Select animator for specific body part
            
            animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = animatorOverrideController;
            
            defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
            animatorOverrideController.GetOverrides(defaultAnimationClips);

            var bodyAnimations = bodySettings.BodyData.Where(x => x.BodyPart == bodyPartId).First().BodyPartSettings;
            var animations = bodyAnimations.Where(x => x.Id == aIdAnimation).First().Animations;

            var playerStates = playerAnimationSettings.PlayerStates;
            var playerDirections = playerAnimationSettings.PlayerDirections;
            
            for (int stateId = 0; stateId < playerStates.Length; stateId++)
            {
                var anims = animations.Where(x => x.playerState == playerStates[stateId]).First().animations;

                for (int directionId = 0; directionId < playerDirections.Length; directionId++)
                {
                    animationClip = anims.Where(x =>
                        x.name.Contains(playerStates[stateId] + "" + playerDirections[directionId])).First();
                    
                    defaultAnimationClips["PlayerFemale" + aBodyPart + "_" + 1 + "_" + playerStates[stateId].ToString() +
                        playerDirections[directionId]] = animationClip; 
                }
            }
            
            animatorOverrideController.ApplyOverrides(defaultAnimationClips);
        }

        #endregion
        
    }
}