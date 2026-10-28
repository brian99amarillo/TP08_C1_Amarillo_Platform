using UnityEngine;

public class EnemySlimeGreen : Enemy
{
    [SerializeField] private float speed = 0f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected override void Die()
    {
        // acá van las partículas, el sonido y la animación de muerte del Walker
        base.Die(); // después ejecuta lo del padre (destruir el objeto)
    }
}
