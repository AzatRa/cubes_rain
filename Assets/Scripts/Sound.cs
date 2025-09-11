using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private float _volume = 1f;

    public void WaterDrop(Cube cube)
    {
        AudioSource.PlayClipAtPoint(_clip, cube.transform.position, _volume);
    }
}
