using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    public float Speed = 10f;
    public float DetectionRadius = 1f;
    public Transform Player;
    public float Lifetime = 5f;
    public int GoldReward = 10;

    private float Timer = 0f;

    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in Enemies)
        {
            if ((Enemy.transform.position - transform.position).magnitude <= DetectionRadius)
            {
                TurretUpgrade.Instance.EarnGold(GoldReward);
                Destroy(Enemy);
                Destroy(gameObject);
                return;
            }

            if (Enemy == null) // If the target is destroyed before impact
            {
                Destroy(gameObject);
            }

        }

        Timer += Time.deltaTime;
        if (Timer >= Lifetime)
        {

            Destroy(gameObject);

        }

    }
}
