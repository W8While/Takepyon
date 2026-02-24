using Game.Enemy;
using Game.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class StardustHandshakeInstance : WeaponBase
    {
        private StardustHandshakeData _skillData => (StardustHandshakeData)WeaponScriptibleObjects;

        private List<Aspect> oldPosition = new List<Aspect>();
        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            _playerStats.AspectChange += AspectChange;
            oldPosition = CheckPos();
        }

        private void AspectChange(Aspect aspect)
        {

            List<Aspect> newPosition = new List<Aspect>();
            newPosition = CheckPos();

            for (int i = 0; i < newPosition.Count; i++)
            {
                if (oldPosition[i] != newPosition[i])
                {
                    GetDamageEnemyAll();
                    break;
                }
            }
            oldPosition = newPosition;
        }

        private List<Aspect> CheckPos()
        {
            List<Aspect> position = new List<Aspect>();
            float _amaterasuValue = _playerStats.GetAspectValue(Aspect.Amaterasu);
            float _tsukyomuValue = _playerStats.GetAspectValue(Aspect.Tsukyomu);
            float _yokayValue = _playerStats.GetAspectValue(Aspect.Yokay);
            if (_amaterasuValue >= _tsukyomuValue)
            {
                if (_amaterasuValue >= _yokayValue)
                {
                    position.Add(Aspect.Amaterasu);
                    if (_tsukyomuValue >= _yokayValue)
                    {
                        position.Add(Aspect.Tsukyomu);
                        position.Add(Aspect.Yokay);
                    }
                    else
                    {
                        position.Add(Aspect.Yokay);
                        position.Add(Aspect.Tsukyomu);
                    }
                }
                else
                {
                    position.Add(Aspect.Yokay);
                    position.Add(Aspect.Amaterasu);
                    position.Add(Aspect.Tsukyomu);
                }
            }
            else
            {
                if (_tsukyomuValue >= _yokayValue)
                {
                    position.Add(Aspect.Tsukyomu);
                    if (_amaterasuValue >= _yokayValue)
                    {
                        position.Add(Aspect.Amaterasu);
                        position.Add(Aspect.Yokay);
                    }
                    else
                    {
                        position.Add(Aspect.Yokay);
                        position.Add(Aspect.Amaterasu);
                    }
                }
            }
            position.Reverse();
            return position;
        }
    }
}