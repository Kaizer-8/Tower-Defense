using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class UIchanger : MonoBehaviour
{
    public static UIchanger instance;  

    public TMP_Text MoneyText;
    public TMP_Text LivesText;

    int Lives = 3;
    int Money = 100;
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
    public void AddLives()
    {
        Lives -= 1;
        LivesText.text = Lives.ToString() + "Lives";
    }
}
