using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Pool _pool;
    [SerializeField] private Sound _sound;
    [SerializeField] private float _spawnInterval = 0.1f;

    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            Cube cube = _pool.Get();

            cube.OnDropped += OnCubeDrop;
            cube.OnCollision += OnCubeCollision;
            _colorChanger.Rain(cube);
            _spawner.Spawn(cube);
            _timer = 0f;
        }
    }

    private void OnCubeDrop(Cube cube)
    {
        cube.OnDropped -= OnCubeDrop;
        cube.ResetEvents();
        _pool.Release(cube);
    }

    private void OnCubeCollision(Cube cube)
    {
        cube.OnCollision -= OnCubeCollision;

        _colorChanger.Drop(cube);
        _sound.WaterDrop(cube);
    }
}
