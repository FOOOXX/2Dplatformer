using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointStorage;

    private Transform[] _points;
    private Transform _target;

    private float _speed;
    private int _currentPoint;

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
        _speed = 1f;
        _target = _points[_currentPoint];
    }

    private void Update()
    {
        Move();

        if (transform.position != _target.position)
            return;

        SetNextPoint();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void SetNextPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Length)
        {
            _currentPoint = 0;
        }

        _target = _points[_currentPoint];
    }
}
