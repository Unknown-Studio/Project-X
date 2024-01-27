using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class ParticlesManager : CoreComponent
    {
        [SerializeField] private Transform particleContainer;

        protected override void Awake()
        {
            base.Awake();

            if (particleContainer == null)
                UnityEngine.Debug.LogError(particleContainer.name + " is null!!!");
        }

        public GameObject StartParticle(GameObject particlePrefab, Vector2 position, Quaternion rotation)
        {
            return Instantiate(particlePrefab, position, rotation, particleContainer);
        }

        public GameObject StartParticle(GameObject particlePrefab)
        {
            return Instantiate(particlePrefab, transform.position, Quaternion.identity);
        }

        public GameObject StartParticleWithRandomRotation(GameObject particlePrefab)
        {
            var randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            return Instantiate(particlePrefab, transform.position, randomRotation, particleContainer);
        }
    }
}
