using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _folloTarget;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _dampingTime;
    [SerializeField] private Vector3 _velocity;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        MoveCamera(true);
    }

    public void ResetCameraPosition()
    {
        MoveCamera(false);
    }

    private void MoveCamera(bool smoothness)
    {
        Vector3 destination = new Vector3(_folloTarget.position.x - _offset.x, _folloTarget.position.y - _offset.y, transform.position.z);
        if (smoothness)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, _dampingTime);
        }
        else
        {
            transform.position = destination;
        }
    }
}
