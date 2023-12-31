using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;
    private float _speed;

    private void Start()
    {
        _offset = new(0, 0, -10);
        _speed = 0.2f;
    }

    private void LateUpdate()
    {
        Vector3 positionToGo = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionToGo, _speed);

        transform.position = smoothedPosition;

        transform.LookAt(_target.position);
    }
}