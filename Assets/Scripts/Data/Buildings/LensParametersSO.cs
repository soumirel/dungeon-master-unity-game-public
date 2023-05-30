using Elements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [CreateAssetMenu(fileName = "LensSO", menuName = "SO/LensParametersSO")]
    public class LensParametersSO : BuildingParametersSO
    {
        [SerializeField] private Sprite _sphereSprite;

        public Sprite SphereSprite => _sphereSprite;
    }
}