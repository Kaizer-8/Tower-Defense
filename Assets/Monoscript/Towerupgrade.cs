using UnityEngine;

public class Towerupgrade : MonoBehaviour
{
    private TowerBehavior _tower;
    public void TowerUpgrade(int damageAmountForUpgrade)
    {
        if (UIchanger.instance.TowerEnoughCash())
        {
            UIchanger.instance.TowerPlaceCost();
            _tower.TowerUpgrade(damageAmountForUpgrade);
        }
    }
    public void RangeUpgrade(int RangeAmountForUpgrade)
    {
        if (UIchanger.instance.TowerEnoughCash())
        {
            UIchanger.instance.TowerPlaceCost();
            _tower.RangeUpgrade(RangeAmountForUpgrade);
        }
    }

    public void CurrentUpgradeTower(TowerBehavior tower)
    {
        _tower = tower;
    }
}
