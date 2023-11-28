using UnityEngine;

namespace Game.Components.ItemsComponent.Data
{
    [CreateAssetMenu(fileName = "ItemStore", menuName = "Game/Items/ItemStore")]
    public class ItemSetup : ScriptableObject
    {
        [SerializeField]
        private int id;
        [SerializeField]
        private string nameItem;
        [SerializeField]
        private int price;
        [SerializeField]
        private Sprite icon;

        public int Id
        {
            get => id;
            set => id = value;   
        }
        
        public string NameItem => nameItem;
        public int Price => price;
        public Sprite Icon => icon;
    }
}