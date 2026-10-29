using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected SettingsEnemySO settingsEnemy;
    [SerializeField] private Image barLife;

    protected float life;

    public float Damage => settingsEnemy.Damage; 

    protected virtual void Start()
    {
        life = settingsEnemy.MaxLife;
    }

    public virtual void TakeDamage(float amount)
    {
        life -= amount;
        UpdateHealthBar(life, settingsEnemy.MaxLife);
        Debug.Log("Daño recibido");

        if (life <= 0f)
        {
            Die();
        }
    }

    private void UpdateHealthBar(float currentLife, float maxLife)
    {
        barLife.fillAmount = currentLife / maxLife;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}