using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotationController : MonoBehaviour
{
    private Vector2 _lastTapPosition;
    private Quaternion _startRotation;

    void Awake()
    {
        _startRotation = transform.rotation;
    }
    

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 curTapPos = Input.mousePosition;
            if (_lastTapPosition == Vector2.zero)
            {
                _lastTapPosition = curTapPos;
            }
            float delta = _lastTapPosition.x - curTapPos.x;
            _lastTapPosition = curTapPos;
            RotationPlane(delta);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _lastTapPosition = Vector2.zero;
            StartRotation();
        }
    }
    public void RotationPlane(float delta)
    {
        transform.Rotate(new Vector3(0, 0, 1) * delta);
    }
    public void StartRotation()
    {
        transform.transform.rotation = _startRotation;
    }
}
