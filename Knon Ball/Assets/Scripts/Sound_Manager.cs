using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource enemyDeadSound;
    
    public void EnemyDeadSound()
    {
        enemyDeadSound.Play();
    }

}
