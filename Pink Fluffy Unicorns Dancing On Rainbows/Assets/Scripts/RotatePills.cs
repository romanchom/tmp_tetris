using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotatePills : MonoBehaviour {
    public float rotateSpeed;
    public Text score;
    public GameObject particle;

    protected static int scoreValue = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision other)
    {
        scoreValue++;
        score.text = scoreValue.ToString();
        GameObject go = GameObject.Instantiate(particle, transform.position, Quaternion.identity) as GameObject;
        (go.GetComponent(typeof(ParticleSystem)) as ParticleSystem).loop = false;
        (go.GetComponent(typeof(ParticleSystem)) as ParticleSystem).emissionRate = 400f;
        (go.GetComponent(typeof(ParticleSystem)) as ParticleSystem).startLifetime = 5f;
        (go.GetComponent(typeof(ParticleSystem)) as ParticleSystem).startSpeed = 100f;
        go.AddComponent(typeof(DestroyProps));
        Destroy(gameObject);
    }

}
