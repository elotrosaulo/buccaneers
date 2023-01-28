using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] public int maxHealth;
        [SerializeField] public int currentHealth;
        [SerializeField] public List<HealthBarBehaviour> healthBar;

        private bool _waitingForDamage;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.ForEach(x => x.SetMaxHealth(maxHealth));
        }


        private void Update()
        {
            switch (currentHealth)
            {
                case 0:
                    return;
                case 1:
                    //giving the last stretch of 10 seconds before going totally dark  
                    StartCoroutine(ReduceHealthBySecond(10));
                    break;
            }

            if (!_waitingForDamage && currentHealth >=0)
            {
                StartCoroutine(ReduceHealthBySecond(1));
            }
        }
        
        private IEnumerator ReduceHealthBySecond(float waitTime)
        {
            _waitingForDamage = true;
            yield return new WaitForSeconds( waitTime );
            TakeDamage(1);
            _waitingForDamage = false;
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.ForEach(x => x.SetHealth(currentHealth));
        }
    }
}