﻿using System;
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

        private bool _waitingForDamage, _stopLightDamage = true;


        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.ForEach(x => x.SetMaxHealth(maxHealth));
        }

        private void OnEnable()
        {
            PlayerActionsBehaviour.OnStopLightDamage += StopLightDamage;
        }
        
        private void OnDisable()
        {
            PlayerActionsBehaviour.OnStopLightDamage -= StopLightDamage;
        }

        private void StopLightDamage(bool shouldStopDamage)
        {
            _stopLightDamage = shouldStopDamage;
        }
        
        private void Update()
        {
            if (!_waitingForDamage && _stopLightDamage)
            {
               switch (currentHealth)
               {
                   case 0:
                       return;
                   case 1:
                       //giving the last stretch of 10 seconds before going totally dark  
                       StartCoroutine(ReduceHealthBySecond(10));
                       break;
                   default:
                       StartCoroutine(ReduceHealthBySecond(1));
                       break;
               }
            }
        }
        
        private IEnumerator ReduceHealthBySecond(float waitTime)
        {
            _waitingForDamage = true;
            yield return new WaitForSeconds( waitTime );
            TakeDamage(1);
            _waitingForDamage = false;
        }

        private void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.ForEach(x => x.SetHealth(currentHealth));
        }
    }
}