using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Systems.PlayerSystem.Controller
{
    public class InteractiveElement : MonoBehaviour
    {
        [SerializeField]
        private GameObject interactiveIcon;
        
        public UnityEvent onInteract;

        public Action OnBeginInteraction;

        #region Public Methods

        public void EnableInteractiveIcon(bool value)
        {
            interactiveIcon.SetActive(value);
        }

        #endregion
    }
}