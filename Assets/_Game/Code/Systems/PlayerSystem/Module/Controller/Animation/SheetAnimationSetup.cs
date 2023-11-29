using UnityEngine;

namespace _Game.Code.Systems.PlayerSystem.Module.Controller
{
    [System.Serializable]
    public class AnimationsData
    {
        public string nameAnimation;
        public AnimationSheetData[] sheetAnimations; 
    }
    
    [System.Serializable]
    public class AnimationSheetData
    {
        public Sprite[] sprites;
    }
    
    [CreateAssetMenu(fileName = "SheetAnimationSetup", menuName = "Game/Sheet Animation Setup")]
    public class SheetAnimationSetup : ScriptableObject
    {
        public AnimationsData[] animationsData;
    }
}