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

            if (Physics.Raycast(camray, out RaycastHit HitInfo, 100f))
            {

            }
        }
    }
    public void SetTowerToPlace(GameObject Tower)
    {
        CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);
    }
}
