using System;
using System.Collections.Generic;
using Elements;
using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Lens : Building
    {
        private SpriteRenderer _baseSpriteRenderer;
        [SerializeField] private SpriteRenderer _sphereSpriteRenderer;
        
        protected Dictionary<Element, Element> transformations;

        public void Awake()
        {
            _baseSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Initialize(Element element, float maxHealth, Dictionary<Element, Element> transformations,
            Sprite baseSprite, Sprite sphereSprite)
        {
            this.element = element;
            this.maxHealth = maxHealth;
            this.transformations = transformations;

            _baseSpriteRenderer.sprite = baseSprite;
            _sphereSpriteRenderer.sprite = sphereSprite;

            health = new Health(maxHealth);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile))
            {
                if (transformations.TryGetValue(projectile.Element, out var resultElement))
                {
                    projectile.Element = resultElement;
                }
            }
        }
    }
}