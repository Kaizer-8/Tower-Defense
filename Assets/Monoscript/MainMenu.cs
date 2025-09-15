using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level1()
    {
        Debug.Log("hallo");
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
