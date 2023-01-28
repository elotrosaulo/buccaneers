using System.Collections;
using UnityEngine;

namespace Behaviors
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] public int maxHealth;
        [SerializeField] public int currentHealth;
        [SerializeField] public HealthBarBehaviour healthBar;

        private bool _waitingForDamage;
        
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }


        void Update()
        {
            if (currentHealth == 1)
            {
                //giving the last stretch of 10 seconds before going totally dark  
                StartCoroutine(ReduceHealthBySecond(10));
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
            healthBar.SetHealth(currentHealth);
        }
    }
}