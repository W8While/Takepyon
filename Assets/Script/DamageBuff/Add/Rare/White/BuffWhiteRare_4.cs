using System.Collections;
using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteRare_4 : DamageBuffBase, IDamageBuffAddWhite
    {
        private float _damage;

        private void Awake()
        {
            StartCoroutine(DamageChange());
        } 

        public float DamageBuffAddWhite()
        {
            return _damage;
        }

        private IEnumerator DamageChange()
        {
            while (true)
            {
                _damage = UnityEngine.Random.Range(-10, 30);
                yield return new WaitForSeconds(5);
            }
        }
    }
}
