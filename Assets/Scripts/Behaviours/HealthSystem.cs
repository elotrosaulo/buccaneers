using System.Collections;
using UnityEngine;

namespace Behaviors
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] public int maxHealth;
        [SerializeField] public int currentHealth;
        [SerializeField] public HealthBarBehaviour healthBar;

        private bool waitingForDamage;
        
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }


        void Update()
        {
            if (!waitingForDamage)
            {
                StartCoroutine(ReduceHealthBySecond());
            }
        }
        
        private IEnumerator ReduceHealthBySecond()
        {
            waitingForDamage = true;
            yield return new WaitForSeconds( 1.0f );
            TakeDamage(1);
            waitingForDamage = false;
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}