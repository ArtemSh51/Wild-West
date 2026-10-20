using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunSounder : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        _audioSource.Play();
    }
}
