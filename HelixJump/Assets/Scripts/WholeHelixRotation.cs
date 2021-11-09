using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeHelixRotation : MonoBehaviour
{
    private float _prevXMousePos;
    public int RotationSpeed;

    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _prevXMousePos = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            var _currentPos = Input.mousePosition.x;
            var _deltaPos = -(_currentPos - _prevXMousePos) / Screen.width;
            transform.Rotate(new Vector3(0, _deltaPos * Time.deltaTime * RotationSpeed, 0));
        }
        if (Input.GetMouseButton(0))
        {
            _prevXMousePos = Input.mousePosition.x;
        }
    }
}
