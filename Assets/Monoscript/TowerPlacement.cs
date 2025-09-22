using System;
using Unity.VisualScripting;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject CurrentPlacingTower;

    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private LayerMask PlacementCheckMask;
    [SerializeField] private LayerMask PlacementCollideMask;
    Inputmanager InputManager;
    private bool RemoveTowers;

    private void Start()
    {
       InputManager = Inputmanager.Instance;
    }
    void Update()
    {
        Ray camray = PlayerCamera.ScreenPointToRay(InputManager.GetmousePosition());
        RaycastHit HitInfo;
        if (Physics.Raycast(camray, out HitInfo, 100f, PlacementCheckMask))
        {
            if (UIchanger.instance.TowerEnoughCash() == true)
            {
                if (CurrentPlacingTower != null && HitInfo.collider.gameObject.tag != "CannotPlace" && HitInfo.collider.gameObject.tag != "Tower")
                {
                    CurrentPlacingTower.transform.position = HitInfo.point;
                    if (!HitInfo.collider.gameObject.CompareTag("CannotPlace") && !HitInfo.collider.gameObject.CompareTag("Tower") && Input.GetMouseButton(0))
                    {
                        UIchanger.instance.TowerPlaceCost();
                        BoxCollider TowerCollider = CurrentPlacingTower.gameObject.GetComponent<BoxCollider>();
                        TowerCollider.isTrigger = true;

                        Vector3 BoxCenter = CurrentPlacingTower.gameObject.transform.position + TowerCollider.center;
                        Vector3 HalfExtents = TowerCollider.size / 2;
                        if (Physics.CheckBox(BoxCenter, HalfExtents, Quaternion.identity, PlacementCheckMask, QueryTriggerInteraction.Ignore))
                        {
                            TowerCollider.isTrigger = false;
                            CurrentPlacingTower = null;
                        }
                    }
                }

                else if (CurrentPlacingTower != null)
                {
                    CurrentPlacingTower.transform.position = new Vector3(0, 0, -1000);
                }
            }
                if (CurrentPlacingTower == null && RemoveTowers && HitInfo.transform.CompareTag("Tower"))
                {
                    if (Input.GetMouseButton(0))
                    {
                        UIchanger.instance.SellingTowerCashBack();
                        Destroy(HitInfo.collider.gameObject);
                    }
                }
            }
        }
    
    
    public void SetTowerToPlace(GameObject Tower)
    {
            CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);
    }
    public void RemoveTower()
    {
        RemoveTowers = !RemoveTowers;
        CurrentPlacingTower = null;
    }
    public void SwitchRemoveMode()
    {
        RemoveTowers = false;
    }
}