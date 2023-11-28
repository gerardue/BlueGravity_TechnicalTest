using UnityEngine;

namespace Game.Systems.PlayerSystem.Data
{
    public enum BodyParts
    {
        Hair,
        Cloth,
        Pants
    }
    
    [System.Serializable]
    public struct BodyData
    {
        public string name; 
        public BodyParts BodyPart;
        public BodyPartSettings[] BodyPartSettings;
    }
    
    [CreateAssetMenu(fileName = "BodySettings", menuName = "Game/Player/Body Settings")]
    public class BodySettings : ScriptableObject
    {
        [SerializeField]
        private BodyData[] bodyData;

        public BodyData[] BodyData => bodyData; 
    }
}