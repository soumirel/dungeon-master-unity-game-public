using System;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        //TODO: Как унифицировать Enemy до IDamagable?
        // Варианты решения: перенести ивент onAbsoluteHealthValueChanged
        // в класс Health и слушать объект _health.
        // Проблема этого решения -
        // по идее HealthBar не должен знать о реализации Health. 
        // Плюсы решения - 
        // о любом изменении хп не нужно дополнительно оповещать
        
        [SerializeField] private Enemy chainedObject;
        [SerializeField] private float _minValue = 0f;
        [SerializeField] private float _maxValue = 1f;

        private Slider _slider;

        public void Awake()
        {
            _slider = GetComponent<Slider>();
            SetUpSlider();
        }

        public void OnEnable()
        {
            chainedObject.OnAbsoluteHealthValueChanged += SetValue;
        }

        private void SetUpSlider()
        {
            _slider.minValue = _minValue;
            _slider.maxValue = _maxValue;
        }

        private void SetValue(float value)
        {
            _slider.value = Math.Clamp(value, _minValue, _maxValue);
        }

        public void OnDisable()
        {
            chainedObject.OnAbsoluteHealthValueChanged -= SetValue;
        }
    }
}