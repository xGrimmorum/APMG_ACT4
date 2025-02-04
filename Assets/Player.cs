using UnityEngine;

public class Player : MonoBehaviour
{
    public float MS = 5f; // Speed of movement
    public float RotationSpeed = 200f; // Speed of rotation

    void Update()
    {
        // Movement: W/S or Up/Down Arrow
        float MoveInput = Input.GetAxis("Vertical");
        Vector3 MoveDirection = transform.up * MoveInput * MS * Time.deltaTime;
        transform.position += MoveDirection;

        // Rotation: A/D or Left/Right Arrow
        float RotationInput = Input.GetAxis("Horizontal");
        float RotationAngle = RotationInput * RotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -RotationAngle); // Negative to match 2D clockwise rotation
    }
}