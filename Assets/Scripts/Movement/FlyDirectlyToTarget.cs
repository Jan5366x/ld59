using UnityEngine;


public class FlyDirectlyToTarget : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Transform target;

    void Start()
    {
     
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
