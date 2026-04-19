using UnityEngine;


public class FlyDirectlyToTarget : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject target;
    public GameObject onPlayerHitPrefab;
    public bool isFake;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target)
        {
            var transformPosition = target.transform.position - transform.position;
            if (transformPosition.magnitude < 0.1f)
            {
                if (!isFake)
                {
                    Instantiate(onPlayerHitPrefab, target.transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
                return;
            }

            Vector3 direction = transformPosition.normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}