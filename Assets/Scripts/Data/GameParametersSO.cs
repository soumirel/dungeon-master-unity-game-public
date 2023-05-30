using TMPro;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "StartParametersSO", menuName = "SO/StartParametersSO")]
    public class GameParametersSO : ScriptableObject
    {
        [SerializeField] private int _startMoney = 0;

        [SerializeField] private float _cashbackСoefficient = 1f;


        public int StartMoney => _startMoney;
        public float CashbackСoefficient => _cashbackСoefficient;
    }
}