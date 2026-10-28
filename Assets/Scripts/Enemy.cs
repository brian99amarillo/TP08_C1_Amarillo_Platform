using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected SettingsEnemySO settingsEnemy;

    protected float life;

    public float Damage => settingsEnemy.Damage; 

    protected virtual void Start()
    {
        life = settingsEnemy.MaxLife;
    }

    public virtual void TakeDamage(float amount)
    {
        life -= amount;
        Debug.Log("Daño recibido");

        if (life <= 0f)
        {
            Die();
        }
    }
    
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}