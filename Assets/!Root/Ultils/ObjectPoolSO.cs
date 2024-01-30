using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace Suhdo.Ultils
{
    [CreateAssetMenu(menuName = "ObjectPool", fileName = "ObjectPool")]
    public class ObjectPoolSO : ScriptableObject
    {
        public PoolableMonoBehaviour Prefab;
        public int DefaultCapacity = 10;
        [Space] public Vector3 DefaultSpawnLocation;
        [Space] public bool UseDefaultSpawnRotation;
        public Quaternion DefaultSpawnRotation;

        private ObjectPool<PoolableMonoBehaviour> _objectPool;

        private void OnEnable()
        {
            _objectPool = new ObjectPool<PoolableMonoBehaviour>(
                CreatePoolObject,
                OnTakeFromPool,
                OnReturnPool,
                OnDestroyObject,
                false,
                DefaultCapacity
                );
        }

        private void OnDestroy()
        {
            ClearPool();
        }

        private void OnDisable()
        {
            ClearPool();
        }
        
        private PoolableMonoBehaviour CreatePoolObject()
        {
            PoolableMonoBehaviour obj = Instantiate(Prefab, DefaultSpawnLocation,
                UseDefaultSpawnRotation ? DefaultSpawnRotation : Quaternion.identity);
            obj.gameObject.SetActive(true);
            obj.RegisterPool(this);
            obj.OnObjectPoolCreate();
            return obj;
        }

        private void OnTakeFromPool(PoolableMonoBehaviour obj)
        {
            obj.gameObject.SetActive(true);
            obj.OnObjectPoolTake();
        }

        private void OnReturnPool(PoolableMonoBehaviour obj)
        {
            obj.OnObjectPoolReturn();
            obj.gameObject.SetActive(false);
        }
        
        private void OnDestroyObject(PoolableMonoBehaviour obj)
        {
            obj.OnObjectPoolDestroy();
            Destroy(obj);
        }

        public PoolableMonoBehaviour Get()
        {
            return _objectPool.Get();
        }

        public void Release(PoolableMonoBehaviour obj)
        {
            _objectPool.Release(obj);
        }

        public void ClearPool()
        {
            if(_objectPool != null)
                _objectPool.Clear();
        }
    }

    public abstract class PoolableMonoBehaviour : MonoBehaviour
    {
        public UnityAction<PoolableMonoBehaviour> onRelease;

        private ObjectPoolSO pool;

        public void RegisterPool(ObjectPoolSO pool)
        {
            this.pool = pool;
        }

        public void Release()
        {
            if(pool != null)
                pool.Release(this);
            if (onRelease != null)
            {
                onRelease(this);
                onRelease = null;
            }
        }
        
        public virtual void OnObjectPoolCreate(){}
        public virtual void OnObjectPoolTake(){}
        public abstract void OnObjectPoolReturn();
        public virtual void OnObjectPoolDestroy(){}
        public virtual void OnPostGet(){}
    }
}
