using UnityEngine;

public class TowerUpgradeUI : MonoBehaviour
{
    public int ProjectileSpeed;
    public int Dmg = 1;
    public int Radius;
    public int FireRate;
    void Update()
    {
        if (Input.GetMouseButton(0) && CompareTag("Tower"))
        {
            //makes the buttons visable to upgrade the towers.
        }       
    }
    public void RadiusUpgrade()
    {
        
    }
    public void DamageUpgrade(int amount)
    {
        amount++;
        Dmg = amount;
        Debug.Log("true"); // increases the amount of dmg towers deal
        Debug.Log(amount);
    }
}
