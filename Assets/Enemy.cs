using UnityEngine;

public enum MovementType { Quadratic, Cubic }

public class Enemy : MonoBehaviour
{

    public float Speed = 2f;
    private MovementType MovementType;
    private Transform Target;
    private Vector3 ControlPoint1, ControlPoint2; // Control points for curved motion
    private float a; // Time parameter for interpolation

    public void SetTarget(Transform EndPoint)
    {
        
        Target = EndPoint;
        InitializeControlPoints();

    }

    public void SetMovementType(MovementType type)
    {

        MovementType = type;

    }

    void InitializeControlPoints()
    {

        Vector3 StartPos = transform.position;
        Vector3 EndPos = Target.position;

        if (MovementType == MovementType.Quadratic)
        {
            ControlPoint1 = StartPos + (EndPos - StartPos) / 2 + new Vector3(0, Random.Range(2f, 4f), 0);
        }

        else if (MovementType == MovementType.Cubic)
        {
            ControlPoint1 = StartPos + (EndPos - StartPos) / 3 + new Vector3(0, Random.Range(2f, 4f), 0);
            ControlPoint2 = StartPos + 2 * (EndPos - StartPos) / 3 + new Vector3(0, Random.Range(-2f, -4f), 0);
        }

    }

    void Update()
    {

        a += Time.deltaTime * Speed / Vector3.Distance(transform.position, Target.position);

        if (MovementType == MovementType.Quadratic)
        {
            transform.position = QuadraticLerp(transform.position, ControlPoint1, Target.position, a);
        }

        else if (MovementType == MovementType.Cubic)
        {
            transform.position = CubicLerp(transform.position, ControlPoint1, ControlPoint2, Target.position, a);
        }

        if (a >= 1f)
        {
            PlayerHealth.Instance.TakeDamage(1); // Reduce HP when an enemy reaches the end
            Destroy(gameObject);
        }

    }

    Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {

        Vector3 a0 = Vector3.Lerp(a, b, t);
        Vector3 a1 = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(a0, a1, t);

    }

    Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {

        Vector3 p0 = Vector3.Lerp(a, b, t);
        Vector3 p1 = Vector3.Lerp(b, c, t);
        Vector3 p2 = Vector3.Lerp(c, d, t);
        Vector3 q0 = Vector3.Lerp(p0, p1, t);
        Vector3 q1 = Vector3.Lerp(p1, p2, t);

        return Vector3.Lerp(q0, q1, t);

    }
}
