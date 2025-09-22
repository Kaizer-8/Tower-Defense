using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public float speed = 8.5f;
    public float radius = 1;
    float radiusSq;
    Transform Enemy1;


    void OnEnable()
    {
        radiusSq = radius * radius;
    }

    void Update()
    {
        if (!Enemy1)
        {
            return;
        }

        Vector3 direction = Enemy1.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
        if (direction.sqrMagnitude < radiusSq)
        {
            EnemyHealth enemyHealth = Enemy1.GetComponent<EnemyHealth>();
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(1); //deals one damage, will be different depending on the towers. again, later lol
            }

            Destroy(gameObject); 
        }

    }

    public void SetTarget(Transform target)
    {
        Enemy1 = target;
    }

    public static TowerProjectile Spawn(GameObject Projectile, Vector3 position, Quaternion rotation, Transform target)
    {
        GameObject go = Instantiate(Projectile, position, rotation);
        TowerProjectile p = go.GetComponent<TowerProjectile>();

        if (!p) p = go.AddComponent<TowerProjectile>();

        p.SetTarget(target);

        return p;
    }
}