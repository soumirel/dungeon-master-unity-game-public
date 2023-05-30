using System;
using System.Collections.Generic;
using Data;
using Elements;
using UnityEngine;

public class ElementsSystem : MonoBehaviour
{
    [SerializeField] private ElementParametersSO[] _elementsParameters;
    [SerializeField] private TransformationsListSO _transformationsList;

    private Dictionary<ElementType, Element> _elements;
    private Dictionary<Element, Dictionary<Element, Element>> _transformations;

    public void Awake()
    {
        InitializeElements();
        InitializeTransformations();
    }

    private void InitializeElements()
    {
        _elements = new Dictionary<ElementType, Element>();
        foreach (var elementParameters in _elementsParameters)
        {
            _elements.Add(elementParameters.ElementType,
                new Element(elementParameters.ElementType,
                    elementParameters.DamageScale,
                    elementParameters.SpeedScale,
                    elementParameters.AnimatorController
                ));
        }
    }


    private void InitializeTransformations()
    {
        _transformations = new Dictionary<Element, Dictionary<Element, Element>>();
        foreach (var transformation in _transformationsList.Transformations)
        {
            AddTransformation(_elements[transformation.FirstElement.ElementType],
                _elements[transformation.SecondElement.ElementType],
                _elements[transformation.ResultElement.ElementType]);

            AddTransformation(_elements[transformation.SecondElement.ElementType],
                _elements[transformation.FirstElement.ElementType],
                _elements[transformation.ResultElement.ElementType]);
        }
    }

    private void AddTransformation(Element keyElement, Element providedElement, Element resultElement)
    {
        if (!_transformations.TryGetValue(keyElement, out var keyElementTransformations))
        {
            _transformations[keyElement] = keyElementTransformations = new Dictionary<Element, Element>();
        }

        keyElementTransformations[providedElement] = resultElement;
    }

    public bool TryGetElement(ElementType elementType,
        out Element element)
    {
        return _elements.TryGetValue(elementType, out element);
    }

    public bool TryGetTransformations(Element element, out Dictionary<Element, Element> transformations)
    {
        return _transformations.TryGetValue(element, out transformations);
    }
}