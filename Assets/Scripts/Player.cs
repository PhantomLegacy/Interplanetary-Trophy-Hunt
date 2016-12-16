using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private const int MAX_HEALTH = 5;
	[SerializeField]
	int Health = MAX_HEALTH;
	[SerializeField]
	Image ImgHealth;
	[SerializeField]
	AudioSource myAudioSource;
	[SerializeField]
	AudioClip PlayerHurt;

	public void Damage(int points)
	{
		Health -= points;
		ImgHealth.fillAmount = (float)Health / (float)MAX_HEALTH;
        if (Health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("LevelSelect");
        }
        else
        {
            myAudioSource.clip = PlayerHurt;
            myAudioSource.Play();
        }
	}
}
