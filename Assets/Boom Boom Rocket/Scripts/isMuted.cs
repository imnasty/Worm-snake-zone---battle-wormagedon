using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isMuted : MonoBehaviour
{
	public GameObject sounde;
	public GameObject mutes;
	public static float volumesound;
	
	public void Start()
	{
		volumesound = PlayerPrefs.GetFloat("Sound", 1);
		AudioListener.volume = volumesound;
		if (volumesound == 0)
		{
			sounde.SetActive(false);
			mutes.SetActive(true);
		}
		else
		{
			sounde.SetActive(true);
			mutes.SetActive(false);
		}

	}

	public void mute()
	{
		AudioListener.volume = 0;
		volumesound = AudioListener.volume;
		PlayerPrefs.SetFloat("Sound", volumesound);
	}

	public void notmute()
	{
		AudioListener.volume = 1;
		volumesound = AudioListener.volume;
		PlayerPrefs.SetFloat("Sound", volumesound);

	}
}
