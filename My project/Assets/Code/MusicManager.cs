using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;


    float lenght = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayMusic()
	{
        int random;
        random = Random.Range(0, 2);
        if(random == 0)
		{
            AudioManager.Instance.PlayMusic(Music1);
        }
        if(random == 1)
		{
            AudioManager.Instance.PlayMusic(Music2);
        }
		else
		{
            AudioManager.Instance.PlayMusic(Music3);
        }
        
       
        
    }

	private void Update()
	{
		if (!AudioManager.Instance.MusicSource.isPlaying)
		{
            PlayMusic();
		}
	}
}
