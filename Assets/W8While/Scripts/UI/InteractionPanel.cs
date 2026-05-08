using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class InteractionPanel : InteractionUI
    {
        [Header("UI")]
        [SerializeField] private TMP_Text _interactionText;

        private List<IInteractionFocus> _interactions;

        private void Awake()
        {
            GetInterfaceFromClass<IInteractionFocus>(out _interactions);
            foreach (IInteractionFocus interaction in _interactions)
            {
                interaction.StartInteractionUI += StartInteraction;
                interaction.StopInteractionUI += StopInteraction;
            }
            gameObject.SetActive(false);
        }

        private void StartInteraction(string interactionText)
        {
            _interactionText.text = interactionText;
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
        }
        private void StopInteraction()
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            foreach (IInteractionFocus interaction in _interactions)
            {
                interaction.StartInteractionUI -= StartInteraction;
                interaction.StopInteractionUI -= StopInteraction;
            }
        }
    }
}
