using UnityEngine;
using UnityEngine.InputSystem;

public class GunControl : MonoBehaviour
{
    public float angle = 0;
    public float moveSpeed = 100f;

    public GameObject bulletPrefab;
    
    InputAction moveAction;
    InputAction jumpAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        angle += moveAction.ReadValue<Vector2>().x * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (jumpAction.WasPressedThisFrame())
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        }
        
        
    }
}
