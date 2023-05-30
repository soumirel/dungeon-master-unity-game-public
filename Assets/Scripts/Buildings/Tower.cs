using System.Collections;
using Elements;
using UnityEngine;
using UnityEngine.Pool;

namespace Buildings
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class Tower : Building
    {
        public IObjectPool<Projectile> ProjectilePool
        {
            get
            {
                return pool ??= new ObjectPool<Projectile>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                    OnDestroyPoolObject, true, 10, maxPoolSize);
            }
        }
    
        protected float shotsInterval;

        [SerializeField] protected Projectile projectilePrefab;
        [SerializeField] protected int maxPoolSize = 20;
        protected IObjectPool<Projectile> pool;

        protected Bounds bounds;
        protected Vector3 position;

        protected Coroutine _shootCorutine;
        
        private SpriteRenderer _baseSpriteRenderer;

        protected Animator animator;
        private static readonly int ShootTrigger = Animator.StringToHash("shoot");

        public void Shoot()
        {
            var projectile = ProjectilePool.Get();
        }

        public void Awake()
        {
            bounds = GetComponent<Collider2D>().bounds;
            position = GetComponent<Transform>().position;
            _baseSpriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            _shootCorutine = null;
        }
        

        public void Initialize(Element element, float maxHealth, float shotsInterval,
            Sprite baseSprite, RuntimeAnimatorController animatorController)
        {
            this.element = element;
            this.maxHealth = maxHealth;
            this.shotsInterval = shotsInterval;

            _baseSpriteRenderer.sprite = baseSprite;
            animator.runtimeAnimatorController = animatorController;

            health = new Health(this.maxHealth);
        }

        public void OnDisable()
        {
            StopAllCoroutines();
        }

        public void StartShooting()
        {
            _shootCorutine = StartCoroutine(ShootRoutine());
        }

        public void StopShooting()
        {
            if (_shootCorutine != null)
            {
                StopCoroutine(_shootCorutine);
                _shootCorutine = null;
            }
        }

        protected IEnumerator ShootRoutine()
        {
            while (true)
            {
                animator.SetTrigger(ShootTrigger);
                Shoot();
                yield return new WaitForSeconds(shotsInterval);
            }
        }

        private Projectile CreatePooledItem()
        {
            var projectile = Instantiate(projectilePrefab);
            projectile.Pool = ProjectilePool;
            return projectile;
        }

        private void OnTakeFromPool(Projectile projectile)
        {
            projectile.Element = element;

            projectile.transform.position = new Vector3(
                position.x + bounds.extents.x + projectile.Bounds.size.x / 2,
                position.y,
                0);
            
            projectile.IsReleasedToPool = false;
            projectile.IsCollided = false;

            projectile.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(Projectile projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}