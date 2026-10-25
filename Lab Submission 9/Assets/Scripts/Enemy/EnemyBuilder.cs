using UnityEngine;

public class EnemyBuilder
{
    private GameObject _prefab;
    private Vector3 _position;
    private int _speed = 3;
    private bool _moveRight;

    public EnemyBuilder FromPrefab(GameObject prefab)
    {
        _prefab = prefab;
        return this;
    }

    public EnemyBuilder AtPosition(Vector3 position)
    {
        _position = position; // Log Position
        _moveRight = position.x < 0; // Log Direction determined by starting side
        return this;
    }

    public EnemyBuilder WithSpeed(int speed)
    {
        _speed = speed; // Log the Speed
        return this;
    }

    public GameObject Build()
    {
        GameObject instance = Object.Instantiate(_prefab, _position, Quaternion.identity);

        // Configure the components step-by-step
        EnemyStats stats = instance.GetComponent<EnemyStats>();
        if (stats != null)
        {
            stats.speed = _speed; // Assign the new speed
            stats.right = _moveRight; // Assign the move direction
        }

        return instance;
    }
}