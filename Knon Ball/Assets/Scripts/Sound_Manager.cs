using UnityEngine;
using UnityEngine.Audio;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource enemyDeadSound;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource triangleExplosionSound;
    [SerializeField] private GameObject sliders;

    [SerializeField] private AudioMixerGroup musicMixer, soundEffectMixer;

    public void EnemyDeadSound()
    {
        enemyDeadSound.Play();
    }

    public void TriangleExplosionSound()
    {
        triangleExplosionSound.Play();
    }

    public void ShowVolumeSliders()
    {
        if (!sliders.gameObject.activeInHierarchy)
        {
            sliders.gameObject.SetActive(true);
        }
        else
        {
            sliders.gameObject.SetActive(false);
        }     
    }

    public void SetVolumeMusic(float slidervalue)
    {
        musicMixer.audioMixer.SetFloat("Music", Mathf.Log10(slidervalue) * 20);
    }

    public void SetVolumeSoundEffect(float slidervalue)
    {
        soundEffectMixer.audioMixer.SetFloat("Sound Effect", Mathf.Log10(slidervalue) * 20);
    }

}
