using UnityEngine;
using System.Collections;

public class DestroyProps : MonoBehaviour {

    protected float time;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time > 10f)
            Destroy(gameObject);
	}
}
