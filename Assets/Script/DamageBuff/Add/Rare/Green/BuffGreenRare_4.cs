using System.Collections;
using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenRare_4 : DamageBuffBase, IDamageBuffAddGreen
    {
        private float _damage;

        private void Awake()
        {
            StartCoroutine(DamageChange());
        }

        public float DamageBuffAddGreen()
        {
            return _damage;
        }

        private IEnumerator DamageChange()
        {
            while (true)
            {
                _damage = UnityEngine.Random.Range(-20, 50);
                yield return new WaitForSeconds(5);
            }
        }

    }
}