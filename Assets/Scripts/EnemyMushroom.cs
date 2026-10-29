using UnityEngine;

public class EnemyMushroom : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start(); // Inicializa life con settingsEnemy.MaxLife

        //transform.right = new Vector2(-direction, 0f);
        //StartCoroutine(RutineMovement());
    }

    // rutina de ataque
}
