using System;
using Elements;
using Enemies;
using FieldBound;
using UnityEngine;
using UnityEngine.Pool;

namespace Buildings
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    public sealed class Projectile : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int Transforming = Animator.StringToHash("transforming");

        private Bounds _bounds;
        private Collider2D _collider2D;

        private IObjectPool<Projectile> _pool;

        private Element _element;
        private bool _isReleasedToPool;
        private bool _isCollided;
        
        public IObjectPool<Projectile> Pool
        {
            set => _pool = value;
        }

        public Bounds Bounds => _bounds;

        public Element Element
        {
            get => _element;
            set
            {
                var previousElement = _element;
                _element = value;
                _animator.runtimeAnimatorController = _element?.AnimatorController;

                if (_element != previousElement && previousElement != null)
                {
                    _animator.SetTrigger(Transforming);
                }
            }
        }
        public bool IsCollided
        {
            get => _isCollided;
            set => _isCollided = value;
        }

        public bool IsReleasedToPool
        {
            get => _isReleasedToPool;
            set => _isReleasedToPool = value;
        }

        public void Awake()
        {
            GetComponents();
        }

        private void GetComponents()
        {
            _bounds = GetComponent<Collider2D>().bounds;
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            if (!_isCollided)
            {
                MoveRight(_element.SpeedScale);
            }
        }

        private void MoveRight(float deltaTimeScale)
        {
            transform.Translate(deltaTimeScale * Time.deltaTime * Vector2.right);
        }


        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                _isCollided = true;
                _element.ApplyDamage(enemy);
                if (!_isReleasedToPool)
                {
                    _animator.SetTrigger(Hit);
                    //ReleaseToPool();
                }
            }
            else if (collision.TryGetComponent(out Bound bound))
            {
                if (bound.BoundType == BoundType.ProjectileBound)
                {
                    ReleaseToPool();
                }
            }
        }

        public void ReleaseToPool()
        {
            _isReleasedToPool = true;
            _pool.Release(this);
        }
    }
}