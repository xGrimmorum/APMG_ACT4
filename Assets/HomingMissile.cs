using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float Speed = 8f;
    public float RotationSpeed = 200f;
    public float DetectionRadius = 1f;
    public int GoldReward = 10;
    public float Lifetime = 5f;

    private Transform Target;
    private float Timer = 0f;

    void Start()
    {

        Target = FindClosestEnemy();
    
    }

    void Update()
    {

        if (Target == null) return;

        Vector2 Direction = (Target.position - transform.position).normalized;
        float TargetAngle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, TargetAngle), RotationSpeed * Time.deltaTime);
        transform.position += transform.right * Speed * Time.deltaTime;

        if ((Target.position - transform.position).magnitude <= DetectionRadius)
        {

            TurretUpgrade.Instance.EarnGold(GoldReward);
            Destroy(Target.gameObject);
            Destroy(gameObject);
        
        }

        Timer += Time.deltaTime;

        if (Timer >= Lifetime)
        {

            Destroy(gameObject);
        
        }

    }

    Transform FindClosestEnemy()
    {

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float ClosestDistance = Mathf.Infinity;
        Transform ClosestEnemy = null;

        foreach (GameObject Enemy in Enemies)
        {

            float Distance = Vector2.Distance(transform.position, Enemy.transform.position);

            if (Distance < ClosestDistance)
            {

                ClosestDistance = Distance;
                ClosestEnemy = Enemy.transform;

            }

        }

        return ClosestEnemy;
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Enemy"))
        {
            Destroy(Collision.gameObject);
            Destroy(gameObject);
        }
    }
}
