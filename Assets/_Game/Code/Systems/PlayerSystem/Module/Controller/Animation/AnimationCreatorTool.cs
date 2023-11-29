// using UnityEditor;
using UnityEngine;

namespace _Game.Code.Systems.PlayerSystem.Module.Controller
{
    public class AnimationCreatorTool : MonoBehaviour
    {
        
        public SheetAnimationSetup sheetAnimationSetup;
        public string outputFolder = "Assets/Animations"; // Folder where animations will be saved

        public int amountSpritesPerAnimation = 3;
        
        public string prefix = "Player";
        public string[] suffixesPosition = new []
        {
            "WalkFront", "WalkLeftDown", "WalkLeft", "WalkRightDown", 
            "WalkRight", "WalkLeftUp", "WalkBack", "WalkRightUp"
        }; 
        
        public string[] suffixes2 = new []
        {
            "IdleFront", "IdleLeftDown", "IdleLeft", "IdleRightDown", 
            "IdleRight", "IdleLeftUp", "IdleBack", "IdleRightUp"
        };
        
        // void Start()
        // {
        //     // CreateAnimations();
        // }
        //
        // [ContextMenu("Create Animations")]
        // public void CreateAnimations()
        // {
        //     for (int animationCategory = 0; animationCategory < sheetAnimationSetup.animationsData.Length; animationCategory++)
        //     {
        //         AnimationsData animationsData = sheetAnimationSetup.animationsData[animationCategory];
        //         string tempName = animationsData.nameAnimation; 
        //         for (int sheetAnimationId = 0; sheetAnimationId < animationsData.sheetAnimations.Length; sheetAnimationId++)
        //         {
        //             AnimationSheetData sheetAnimationData = animationsData.sheetAnimations[sheetAnimationId];
        //             for (int id = 0; id < sheetAnimationData.sprites.Length; id++)
        //             {
        //                 if ((id + 1) % 3 == 0)
        //                 {
        //                     CreateWalkAnimation(sheetAnimationData, id, sheetAnimationId, tempName);
        //                 }
        //             }
        //         }
        //     }
        //     
        //     Debug.Log("Animations created and saved to folder: " + outputFolder);
        // }
        //
        // [ContextMenu("Create Idle Animations")]
        // public void CreateIdleAnimations()
        // {
        //     for (int animationCategory = 0; animationCategory < sheetAnimationSetup.animationsData.Length; animationCategory++)
        //     {
        //         AnimationsData animationsData = sheetAnimationSetup.animationsData[animationCategory];
        //         string tempName = animationsData.nameAnimation; 
        //         for (int sheetAnimationId = 0; sheetAnimationId < animationsData.sheetAnimations.Length; sheetAnimationId++)
        //         {
        //             AnimationSheetData sheetAnimationData = animationsData.sheetAnimations[sheetAnimationId];
        //             for (int id = 0; id < sheetAnimationData.sprites.Length; id++)
        //             {
        //                 if ((id + 1) % 3 == 0)
        //                 {
        //                     CreateIdleAnimation(sheetAnimationData, id, sheetAnimationId, tempName);
        //                 }
        //             }
        //         }
        //     }
        //     
        //     Debug.Log("Animations created and saved to folder: " + outputFolder);
        // }
        //
        // private void CreateWalkAnimation(AnimationSheetData data, int id, int sheetAnimationId, string tempName)
        // {
        //     int suffixId = (id + 1) / amountSpritesPerAnimation;
        //     id -= (amountSpritesPerAnimation - 1); 
        //     AnimationClip animationClip = new AnimationClip();
        //     AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(animationClip);
        //     clipSettings.loopTime = true;
        //     animationClip.frameRate = 60; // Adjust frame rate as needed
        //
        //     AssetDatabase.CreateAsset(animationClip, outputFolder + prefix + tempName + "_" + (sheetAnimationId + 1) + "_" + suffixesPosition[suffixId - 1] + ".anim");  
        //
        //     ObjectReferenceKeyframe[] keyframes = new ObjectReferenceKeyframe[3];
        //     for (int i = 0; i < amountSpritesPerAnimation; i++)
        //     {
        //         keyframes[i].time =  i == 0 ? 0 : (0.0833f) * i;
        //         keyframes[i].value = data.sprites[id + i];
        //     }
        //     
        //     AnimationUtility.SetAnimationClipSettings(animationClip, clipSettings);
        //     AnimationUtility.SetObjectReferenceCurve(animationClip, new EditorCurveBinding
        //     {
        //         type = typeof(SpriteRenderer),
        //         path = "",
        //         propertyName = "m_Sprite"
        //     }, keyframes);
        // }
        //
        // private void CreateIdleAnimation(AnimationSheetData data, int id, int sheetAnimationId, string tempName)
        // {
        //     int suffixId = (id + 1) / amountSpritesPerAnimation;
        //     id--; 
        //     AnimationClip animationClip = new AnimationClip();
        //     // AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(animationClip);
        //     // clipSettings.loopTime = true;
        //     animationClip.frameRate = 12; // Adjust frame rate as needed
        //     
        //
        //     AssetDatabase.CreateAsset(animationClip, outputFolder + prefix + tempName + "_" + (sheetAnimationId + 1) + "_" + suffixes2[suffixId - 1] + ".anim");  
        //
        //     ObjectReferenceKeyframe[] keyframes = new ObjectReferenceKeyframe[1];
        //     for (int i = 0; i < 1; i++)
        //     {
        //         keyframes[i].time =  i == 0 ? 0 : (0.0833f) * i;
        //         keyframes[i].value = data.sprites[id];
        //     }
        //     
        //     // AnimationUtility.SetAnimationClipSettings(animationClip, clipSettings);
        //     AnimationUtility.SetObjectReferenceCurve(animationClip, new EditorCurveBinding
        //     {
        //         type = typeof(SpriteRenderer),
        //         path = "",
        //         propertyName = "m_Sprite"
        //     }, keyframes);
        // }
        
        // [ContextMenu("Animation")]
        // void CreateAnimation()
        // {
        //     AnimationClip animationClip = new AnimationClip();
        //     animationClip.frameRate = 12; // Adjust frame rate as needed
        //
        //     AssetDatabase.CreateAsset(animationClip, outputFolder + "/Animation" + ".anim");  
        //
        //     ObjectReferenceKeyframe[] keyframes = new ObjectReferenceKeyframe[3];
        //     for (int i = 0; i < sprites.Length; i++)
        //     {
        //         keyframes[i].time =  i == 0 ? 0 : (0.0833f) * i;
        //         keyframes[i].value = sprites[i];
        //     }
        //     
        //     
        //     AnimationUtility.SetObjectReferenceCurve(animationClip, new EditorCurveBinding
        //     {
        //         type = typeof(SpriteRenderer),
        //         path = "",
        //         propertyName = "m_Sprite"
        //     }, keyframes);
        // }
    }
}