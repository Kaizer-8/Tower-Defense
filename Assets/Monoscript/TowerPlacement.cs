using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject CurrentPlacingTower;

    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private LayerMask PlacementCheckMask;
    [SerializeField] private LayerMask PlacementCollideMask;

    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;
            if (Physics.Raycast(camray, out HitInfo, 100f, PlacementCheckMask) && HitInfo.collider.gameObject.tag != "CannotPlace")
            {
                CurrentPlacingTower.transform.position = HitInfo.point;
                if (Input.GetMouseButton(0) && HitInfo.collider.gameObject != null)
                {
                    if (!HitInfo.collider.gameObject.CompareTag("CannotPlace"))
                    {
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
            }
            else
            {
                CurrentPlacingTower.transform.position = new Vector3(0, 0, -1000);
            }
        }
    }
    public void SetTowerToPlace(GameObject Tower)
    {
            CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);
    }
}
//&& HitInfo.collider.gameObject != null