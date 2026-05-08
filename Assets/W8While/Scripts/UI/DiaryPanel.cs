using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class DiaryPanel : InteractionUI
    {
        [Header("UI")]
        [SerializeField] private TMP_Text _dairyPage0ne;
        [SerializeField] private TMP_Text _dairyPageTwo;

        private List<IClickInteractionDairy> _interactions;

        private void Awake()
        {
            GetInterfaceFromClass<IClickInteractionDairy>(out _interactions);
            foreach (IClickInteractionDairy dairy in _interactions)
            {
                dairy.StartDairyReading += StartDairyReading;
                dairy.StopDairyReading += StopDairyReading;
            }
            gameObject.SetActive(false);
        }

        private void StartDairyReading(DairyBase dairy)
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
            _dairyPage0ne.text = dairy.Pages[0];
            _dairyPageTwo.text = dairy.Pages[1];
        }


        private void StopDairyReading()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            foreach (IClickInteractionDairy dairy in _interactions)
            {
                dairy.StartDairyReading -= StartDairyReading;
                dairy.StopDairyReading -= StopDairyReading;
            }
        }
    }
}