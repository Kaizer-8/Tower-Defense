using UnityEngine;

public class Towerupgrade : MonoBehaviour
{
    private TowerBehavior _tower;
    public void TowerUpgrade(int damageAmountForUpgrade)
    {
        _tower.TowerUpgrade(damageAmountForUpgrade);
    }
    public void RangeUpgrade(int RangeAmountForUpgrade)
    {
        _tower.RangeUpgrade(RangeAmountForUpgrade);
    }

    public void CurrentUpgradeTower(TowerBehavior tower)
    {
        _tower = tower;
    }
}
