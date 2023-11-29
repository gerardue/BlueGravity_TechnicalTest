using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Components.ItemsComponent.Data
{
    public enum ItemCategoryType
    {
        Hair,
        Cloth,
        Pants
    }
    
    [CreateAssetMenu(fileName = "ItemStore", menuName = "Game/Items/ItemStore")]
    public class ItemSetup : ScriptableObject
    {
        [SerializeField]
        private int id;
        [SerializeField]
        private int itemId;
        [SerializeField]
        private string nameItem;
        [SerializeField]
        private int price;
        [SerializeField]
        private ItemCategoryType itemCategory;
        [SerializeField]
        private Sprite icon;

        public int Id
        {
            get => id;
            set => id = value;   
        }

        public int ItemId => itemId; 
        public string NameItem => nameItem;
        public int Price => price;
        public ItemCategoryType ItemCategory => itemCategory;
        public Sprite Icon => icon;
    }
}