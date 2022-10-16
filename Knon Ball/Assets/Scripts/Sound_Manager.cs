using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource enemyDeadSound;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private Slider volumeSlider;

    //[SerializeField] private AudioMixerGroup;

    public void EnemyDeadSound()
    {
        enemyDeadSound.Play();
    }

    public void ChangeVolume(bool showSlider)
    {
        if (showSlider)
        {
            if (!volumeSlider.gameObject.activeInHierarchy)
            {
                volumeSlider.gameObject.SetActive(true);
            }
            else
            {
                volumeSlider.gameObject.SetActive(false);
            }
        }

        if (!showSlider)
            backgroundMusic.volume = volumeSlider.value;
    }

}
