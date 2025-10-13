using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] public int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
       // amount = 2;
        currentHealth -= amount;// min comparatage the tower dmg
        Debug.Log($"{gameObject.name} took {amount} damage, health = {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        UIchanger.instance.AddMoney();
        Debug.Log($"{gameObject.name} has been destroyed!");
        Destroy(gameObject);
    }
}

