using UnityEngine;
using UnityEngine.InputSystem;

public class GunControl : MonoBehaviour
{
    public float angle = 0;

    public GameObject bulletPrefab;

    InputAction moveAction;
    InputAction jumpAction;
    InputAction pauseAction;
    PlayerStats playerStats;

    public float remainingFireDelay = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        pauseAction = InputSystem.actions.FindAction("Pause");
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingFireDelay -= Time.deltaTime;
        angle -= moveAction.ReadValue<Vector2>().x * playerStats.gunSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (jumpAction.IsPressed() && remainingFireDelay < 0)
        {
            remainingFireDelay = playerStats.fireDelay;
            Instantiate(bulletPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        }

        if (pauseAction != null && pauseAction.WasPressedThisFrame())
        {
            transform.parent.GetComponentInChildren<GameOverButtons>().OpenGamePausedPanel();
        }
    }
}