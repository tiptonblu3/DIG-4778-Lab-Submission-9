using UnityEngine;

public class EnemyMethods : MonoBehaviour
{
    public EnemyStats enemyStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (transform.position.x >= 0)
        {
            enemyStats.right = false;
        }
        else
        {
            enemyStats.right = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Kill();
    }

    public void Move()
    {
        if (enemyStats.right)
        {
            transform.Translate(Vector3.right * Time.deltaTime * enemyStats.speed);
        }
        else
        {
            transform.Translate(-Vector3.right * Time.deltaTime * enemyStats.speed);
        }
    }

    public void Kill()
    {
        if (transform.position.x >= 11 || transform.position.x <= -11)
        {
            Destroy(this.gameObject);
        }
    }

}
