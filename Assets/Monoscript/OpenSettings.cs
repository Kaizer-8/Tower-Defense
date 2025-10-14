using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    [SerializeField] GameObject Settings;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnebleMainMenu();
        }
    }
    public void EnebleMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Settings.SetActive(!Settings.activeSelf);
        }
        
    }
}
//Cursor.lockState = Settings.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
