using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SotomaYorch.Mechanics
{
    public class HealthManager : MonoBehaviour
    {
        #region UnityEvents

        [Header("Unity Event")]
        [SerializeField] protected UnityEvent onDeathUnityEvent;

        #endregion

        #region Parameters

        public int maxHealth = 3;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected int currentHealth;

        #endregion

        #region UnityMethods

        void Start()
        {
            currentHealth = maxHealth;
        }

        #endregion
        
        #region PublicMethods

        public void ReduceHealth()
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                onDeathUnityEvent?.Invoke();
            }
        }

        public void ReduceHealth(int value)
        {
            currentHealth -= value;
            if (currentHealth <= 0)
            {
                onDeathUnityEvent?.Invoke();
            }
        }

        public void CureHealth()
        {
            currentHealth++;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void CureHealth(int value)
        {
            currentHealth += value;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        #endregion
    }
}