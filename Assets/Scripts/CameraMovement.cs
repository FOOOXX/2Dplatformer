using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement _player;
    private Vector3 _distanceFromPlayer;

    private float _speed;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();

        _distanceFromPlayer = new(13, 0, -11);
        _speed = 0.2f;
    }

    private void LateUpdate()
    {
        Vector3 positionToGo = _player.transform.position + _distanceFromPlayer;
        Vector3 smoothPosition = Vector3.Lerp(_player.transform.position, positionToGo, _speed);

        transform.position = smoothPosition;
    }
}
