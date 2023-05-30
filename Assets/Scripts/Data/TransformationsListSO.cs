using System;
using Data;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationsSO", menuName = "SO/TransformationsSO")]
public class TransformationsListSO : ScriptableObject
{
    [Serializable]
    public class ElementTransformation
    {
        public ElementParametersSO FirstElement => firstElement;

        public ElementParametersSO SecondElement => secondElement;

        public ElementParametersSO ResultElement => resultElement;

        [SerializeField] private ElementParametersSO firstElement;
        [SerializeField] private ElementParametersSO secondElement;
        [SerializeField] private ElementParametersSO resultElement;

    }
    
    public ElementTransformation[] Transformations => _transformations;

    [SerializeField] private ElementTransformation[] _transformations;
}