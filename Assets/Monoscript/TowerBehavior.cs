using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public GameObject Projectile;
    public Transform Tower;
    public float fireRate = 1f;
    public float range = 5f;
    public int towerDamage;
    private float fireCooldown;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        Transform target = FindClosestEnemy();

        if (target && fireCooldown <= 0f)
        {
          TowerProjectile.Spawn(Projectile, Tower.position, Quaternion.identity, target, towerDamage);
          fireCooldown = 1f / fireRate;
        }
    }

    public void TowerUpgrade(int damageAmountForUpgrade)
    {
        towerDamage += damageAmountForUpgrade;
    }


    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist && dist <= range)
            {
                minDist = dist;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}
