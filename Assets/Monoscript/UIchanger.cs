using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class UIchanger : MonoBehaviour
{
    public static UIchanger instance;
    [SerializeField]GameObject GameOverScreen;

    public TMP_Text MoneyText;
    public TMP_Text LivesText;

    int Lives = 3;
    int Money = 300;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MoneyText.text = Money.ToString() + "Money";
        LivesText.text = Lives.ToString() + "Lives";
    }
    public void AddMoney()
    {
        Money += 50;
        MoneyText.text = Money.ToString() + "Money";
    }
    public async void AddLives()
    {
        Lives -= 1;
        LivesText.text = Lives.ToString() + "Lives";
        if (Lives == 0)
        {
            GameOverScreen.GetComponent<Canvas>().enabled = true;
            Debug.Log("Game Over");
            await Task.Delay(3000);
            SceneManager.LoadScene("Main menu");
        }
    }
    public void TowerPlaceCost()
    {
       Money -= 100;
       MoneyText.text = Money.ToString() + "Money";
    }
    public bool TowerEnoughCash()
    {
        if (Money >= 100)
        {
            return true;
        }
        return false;
    }
    public void SellingTowerCashBack()
    {
        Money += 50;
        MoneyText.text = Money.ToString() + "Money";
    }
}
