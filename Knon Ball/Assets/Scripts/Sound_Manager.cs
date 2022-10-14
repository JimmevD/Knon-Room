using UnityEngine;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource enemyDeadSound;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private Slider volumeSlider;

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
