using UnityEngine;

public class TestCameraToMouse : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;

    private Vector2 _mouseScreenPosition;
    private Vector2 _mean;
    private float _positionX;
    private float _positionY;


    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _player = GameObject.Find("Test-Body");
    }

    void Update()
    {
        AverageToMouse();
    }

    /// <summary>
    /// Function that makes object follow the average position of mouse and player
    /// </summary>
    void AverageToMouse()
    {
        _mouseScreenPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _positionX = ((_player.transform.position.x + _mouseScreenPosition.x) / 2f) * 0.9115f;
        _positionY = ((_player.transform.position.y + _mouseScreenPosition.y) / 2f) * 0.85f;

        _mean = new Vector2(_positionX, _positionY);
        
        transform.position = _mean;
    }
}
