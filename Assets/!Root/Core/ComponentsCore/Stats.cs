using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo
{
    public class Stats : CoreComponent
    {
        [SerializeField] private float maxHealth;
        private float currentHealth;

        protected override void Awake()
        {
            base.Awake();

            currentHealth = maxHealth;
        }

        public void DecreaseHealth(float value)
        {
            currentHealth -= value;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log("Health is zero !!!");
            }
        }

        public void IncreaseHealth(float value)
        {
            currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        }
    }
}
