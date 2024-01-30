using Suhdo.Generics;
using Suhdo.Ultils;
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

        public void StartParticleWithRandomRotation(PoolableMonoBehaviour particlePrefab)
        {
            var randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            var transform1 = particlePrefab.transform;
            transform1.parent = particleContainer;
            transform1.rotation = randomRotation;
            transform1.position = transform.position;
        }
    }
}
