using Game.Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui.Player
{
    public class PlayerMain : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;

        [SerializeField] private TMP_Text _healtPoint;
        [SerializeField] private Slider _amaterasuSlider;
        [SerializeField] private Slider _tsukyomuSlider;
        [SerializeField] private Slider _yokaySlider;

        private void Awake()
        {
            _playerStats.StatsChange += PlayerStatsChange;
            _amaterasuSlider.onValueChanged.AddListener(delegate { AmaterasiSliderChange();});
            _tsukyomuSlider.onValueChanged.AddListener(delegate { TsukyomuSliderChange();});
            _yokaySlider.onValueChanged.AddListener(delegate { YokayiSliderChange();});
        }

        private void AmaterasiSliderChange()
        {
            _playerStats.AmaterasuChange(_amaterasuSlider.value * 100);
        }
        private void TsukyomuSliderChange()
        {
            _playerStats.TsukyomyChange(_tsukyomuSlider.value * 100);
        }
        private void YokayiSliderChange()
        {
            _playerStats.YokayChange(_yokaySlider.value * 100);
        }

        private void PlayerStatsChange()
        {
            if (_playerStats == null)
                return;
            _healtPoint.text = $"{_playerStats.CurrentHealtPoint}/{_playerStats.MaxHealtPoint}";
            _amaterasuSlider.value = _playerStats.CurrentAmaterasu / _playerStats.MaxAmaterasu;
            _tsukyomuSlider.value = _playerStats.CurrentTsukyomy / _playerStats.MaxTsukyomy;
            _yokaySlider.value = _playerStats.CurrentYokay / _playerStats.MaxYokay;
        }
    }
}