using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    private AudioSource audioSrc;

    private float musicVolume = 0.1f;

	void Start () {

        audioSrc = GetComponent<AudioSource>();
	}
	
	void Update () {

        audioSrc.volume = musicVolume;
	}

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
