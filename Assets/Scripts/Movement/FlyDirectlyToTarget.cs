using UnityEngine;


public class FlyDirectlyToTarget : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
