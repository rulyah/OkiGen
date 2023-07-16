using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip _correctSound;
    [SerializeField] private AudioClip _incorrectSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayCorrectSound()
    {
        _sfxSource.PlayOneShot(_correctSound);
    }

    public void PlayIncorrectSound()
    {
        _sfxSource.PlayOneShot(_incorrectSound);
    }
}