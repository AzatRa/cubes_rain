using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Центр спауна")]
    [SerializeField] private Transform _spawnPoint;
    [Header("Границы спауна")]
    [SerializeField] private Vector3 _volume = new(49, 99, 49);

    private Pool _pool;

    private void Awake()
    {
        _pool = GetComponent<Pool>();
    }

    public void Spawn(Cube cube)
    {
        cube.Reset();

        Vector3 spawnPosition = new Vector3(
            Random.Range(_spawnPoint.position.x - _volume.x, _spawnPoint.position.x + _volume.x),
            _spawnPoint.position.y,
            Random.Range(_spawnPoint.position.z - _volume.z, _spawnPoint.position.z + _volume.z)
        );

        cube.transform.position = spawnPosition;
        cube.transform.rotation = Quaternion.identity;
        cube.gameObject.SetActive(true);
    }
}
