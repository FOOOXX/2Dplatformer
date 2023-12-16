using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _pointStorage;

    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[_pointStorage.childCount];

        for (int i = 0; i < _pointStorage.childCount; i++)
        {
            _points[i] = _pointStorage.GetChild(i);
        }
    }

    private void Start()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_coin, _points[i].position, Quaternion.identity);
        }
    }
}
