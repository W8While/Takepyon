using System.Collections;
using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerRare_2 : DamageBuffBase, IDamageBuffMultiplay
    {
        private float _damage;

        private void Awake()
        {
            StartCoroutine(DamageChange());
        }

        public float DamageBuffAddMultiplay()
        {
            return _damage;
        }

        private IEnumerator DamageChange()
        {
            while (true)
            {
                _damage = UnityEngine.Random.Range(-1f, 4f);
                yield return new WaitForSeconds(20);
            }
        }
    }
}
