using System;
using Game.Systems.PlayerSystem.View;
using UnityEngine;

namespace Game.Systems.PlayerSystem.Controller
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private InteractionView interactionView;
        
        private bool isReadyToInteract;
        private InteractiveElement interactiveElement; 
        
        #region Unity Methods

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Interactive"))
                return;
            
            interactiveElement = other.GetComponent<InteractiveElement>();
            interactionView.SetInteractiveElement(interactiveElement);
            interactiveElement.EnableInteractiveIcon(true);
            isReadyToInteract = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Interactive"))
                return;
            
            interactiveElement.EnableInteractiveIcon(false);
            interactionView.DisposeInteractiveElement();
            isReadyToInteract = false;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) && isReadyToInteract)
            {
                interactiveElement.OnBeginInteraction?.Invoke();
            }
        }

        #endregion

        #region Public Methods

        public bool IsInteracting()
        {
            return isReadyToInteract; 
        }

        #endregion
    }
}