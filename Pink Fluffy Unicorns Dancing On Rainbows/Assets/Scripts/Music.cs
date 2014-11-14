using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public AudioSource intro;
	public AudioSource loop;
	static bool adsda;

	// Use this for initialization
	void Start () {
		if (adsda) {
			Destroy(gameObject);
			return;
		}
		adsda = true;
		DontDestroyOnLoad(gameObject);
		intro.Play();
		loop.PlayScheduled(AudioSettings.dspTime + intro.clip.length);
	}

}
