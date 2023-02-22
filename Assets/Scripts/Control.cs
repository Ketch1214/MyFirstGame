using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform Level;
    public float Sensivity;

    private Vector3 _previousMousePosition;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * Sensivity, 0);
        }

        _previousMousePosition = Input.mousePosition;
    }
}
