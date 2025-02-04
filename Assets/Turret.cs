using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Missile; // Prefab of the projectile
    public Transform FirePoint; // Point where projectiles spawn
    public float RotationSpeed = 5f; // Speed of turret rotation
    public float FireRange = 10f; // Range to fire
    public float FireAngleThreshold = 5f; // Angle tolerance for firing
    public float FireCooldown = 2f; // Cooldown duration

    private float CDTimer = 0f;
    private Transform TargetEnemy; // Target enemy

    public float FireRate = 1f;
    public float Range = 5f;
    public float BulletDistance = 3f;


    void Update()
    {
        FindNearestEnemy();

        if (TargetEnemy == null) return; // If no enemy, do nothing

        // Rotate turret towards enemy
        Vector2 DirectionToEnemy = (TargetEnemy.position - transform.position).normalized;
        float TargetAngle = Mathf.Atan2(DirectionToEnemy.y, DirectionToEnemy.x) * Mathf.Rad2Deg;
        float angle = Mathf.LerpAngle(transform.eulerAngles.z, TargetAngle, RotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Check distance and angle to enemy
        float DistanceToEnemy = Vector2.Distance(transform.position, TargetEnemy.position);
        float AngleToEnemy = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, TargetAngle));

        if (DistanceToEnemy <= FireRange && AngleToEnemy <= FireAngleThreshold && CDTimer <= 0f)
        {
            Fire();
        }

        // Reduce cooldown timer
        if (CDTimer > 0f)
        {
            CDTimer -= Time.deltaTime;
        }
    }

    void FindNearestEnemy()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float ClosestDistance = Mathf.Infinity;
        Transform ClosestEnemy = null;

        foreach (GameObject Enemy in Enemies)
        {
            float distance = Vector2.Distance(transform.position, Enemy.transform.position);
            if (distance < ClosestDistance)
            {
                ClosestDistance = distance;
                ClosestEnemy = Enemy.transform;
            }
        }

        TargetEnemy = ClosestEnemy; // Assign closest enemy as the target
    }

    void Fire()
    {
        if (TargetEnemy == null) return;

        // Spawn projectile and set its direction
        Instantiate(Missile, FirePoint.position, FirePoint.rotation);
        CDTimer = FireCooldown;
    }
}
