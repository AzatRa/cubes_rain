using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [Header("Насройки задержки исчезаниея куба после падения")]
    [SerializeField] private float _minDelay = 2f;
    [SerializeField] private float _maxDelay = 5f;

    public event Action<Cube> OnCollision;
    public event Action<Cube> OnDropped;

    private bool _dropped = false;
    private Coroutine _coroutine;

    public void Reset()
    {
        _dropped = false;

        if (_coroutine != null )
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void ResetEvents()
    {
        OnDropped = null;
        OnCollision = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_dropped || collision.gameObject.TryGetComponent<Cube>(out _))
            return;

        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _dropped = true;

            OnCollision?.Invoke(this);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        float delay = UnityEngine.Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        OnDropped?.Invoke(this);
    }
}