using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject CurrentPlacingTower;

    [SerializeField] private Camera PlayerCamera;
    void Start()
    {
        
    }

    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;
            if (Physics.Raycast(camray, out HitInfo, 100f))
            {
                CurrentPlacingTower.transform.position = HitInfo.point;
            }
            if (Input.GetMouseButton(0) && HitInfo.collider.gameObject != null)
            {
                if (!HitInfo.collider.gameObject.CompareTag("CannotPlace"))
                {
                    BoxCollider TowerCollider = CurrentPlacingTower.gameObject.GetComponent<BoxCollider>();
                    //BoxCollider.Instantiate(CurrentPlacingTower.transform);
                    CurrentPlacingTower = null;
                }
            }
        }
    }
    public void SetTowerToPlace(GameObject Tower)
    {
            CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);
    }
}
