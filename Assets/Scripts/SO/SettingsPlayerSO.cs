using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsPlayer", menuName = "Settings/GameSettingsPlayer")]
public class SettingsPlayerSO : ScriptableObject
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float life = 100f;
    [SerializeField] private float startPositionx = -9f;
    [SerializeField] private float startPositiony = 1.25f;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float damage = 25f;
    public Vector2 StartPosition => startPosition;

    public float Speed { get { return speed; } }
    public float JumpForce { get { return jumpForce; } }
    public float Life { get { return life; } }
    public float Damage { get { return damage; } }

    private void OnEnable()
    {
        startPosition = new Vector2(startPositionx, startPositiony);
    }
}
