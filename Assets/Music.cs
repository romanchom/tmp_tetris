using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public AudioSource intro;
	public AudioSource loop;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		intro.Play();
		loop.PlayScheduled(AudioSettings.dspTime + intro.clip.length);
	}

}
