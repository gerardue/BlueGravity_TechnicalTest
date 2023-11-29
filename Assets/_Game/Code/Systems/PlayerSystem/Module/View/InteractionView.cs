using System;
using System.Collections;
using System.Collections.Generic;
using Game.Systems.PlayerSystem.Controller;
using Game.Systems.PlayerSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Systems.PlayerSystem.View
{
    public class InteractionView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private GameObject ui;
        [SerializeField]
        private TextMeshProUGUI messageText;
        [SerializeField]
        private Button interactButton;
        [SerializeField]
        private Button cancelButton;
        [SerializeField]
        private string messageToPrint;

        [Header("Runtime data")]
        [SerializeField]
        private PlayerRuntimeData runtimeData;
        
        private InteractiveElement interactiveElement;
        
        private float letterSpeed = 0.01f; 
        
        #region Unity Methods

        private void OnEnable()
        {
            interactButton.onClick.AddListener(() =>
            {
                interactiveElement.onInteract.Invoke();
                ui.SetActive(false);
            });
            cancelButton.onClick.AddListener(CloseInteractiveWireframe);
        }

        private void OnDisable()
        {
            interactButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region Public Methods
        
        public void SetInteractiveElement(InteractiveElement aInteractiveElement)
        {
            interactiveElement = aInteractiveElement; 
            interactiveElement.OnBeginInteraction += OpenInteractiveWireframe;
        }

        public void DisposeInteractiveElement()
        {
            interactiveElement.OnBeginInteraction -= OpenInteractiveWireframe;
        }
        
        #endregion

        #region Private Methods

        private void CloseInteractiveWireframe()
        {
            ui.SetActive(false);
            runtimeData.SetPlayerBusy(false);
        }
        
        private void OpenInteractiveWireframe()
        {
            messageText.text = string.Empty; 
            ui.SetActive(true);
            StartCoroutine(TypeText());
            runtimeData.SetPlayerBusy(true);
        }
        
        private IEnumerator TypeText()
        {
            for (int i = 0; i <= messageToPrint.Length; i++)
            {
                string currentText = messageToPrint.Substring(0, i);
                messageText.text = currentText;
                yield return new WaitForSeconds(letterSpeed);
            }
        }

        #endregion
    }
}