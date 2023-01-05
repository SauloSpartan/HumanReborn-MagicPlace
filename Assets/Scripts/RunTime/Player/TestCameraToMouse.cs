using UnityEngine;

public class TestCameraToMouse : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;

    private Vector2 _mouseScreenPosition;
    private Vector2 _mean;
    private float _transition;


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
        _transition = 4f * Time.deltaTime;

        _mean = new Vector2(Mathf.Lerp(transform.position.x, (((_player.transform.position.x + _mouseScreenPosition.x) / 2f) * 0.9115f), _transition), Mathf.Lerp(transform.position.y, (((_player.transform.position.y + _mouseScreenPosition.y) / 2f) * 0.85f), _transition));

        transform.position = _mean;
    }
}
