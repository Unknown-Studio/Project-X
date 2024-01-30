using Suhdo.Ultils;
using Unity.Mathematics;
using UnityEngine;

namespace Suhdo.Effects
{
    public class HitParticle : PoolableMonoBehaviour
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            if(anim == null) Debug.LogWarning($"Not have animator on {transform.name}");
        }

        private void OnEnable()
        {
            
        }

        public void OnFinishAnim()
        {
            Release();
        }
        
        public override void OnObjectPoolReturn()
        {
            transform.parent = null;
            transform.localRotation = quaternion.identity;
            transform.position = Vector3.zero;
        }
    }
}
