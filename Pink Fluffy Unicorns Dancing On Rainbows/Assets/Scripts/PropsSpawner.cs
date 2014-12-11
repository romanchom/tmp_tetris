using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PropsSpawner : MonoBehaviour {
    
    public GameObject props;
    public float frequency = 5f;
    public float chance = .5f;
    public Text score;

    protected float lastSpawn;
	// Use this for initialization
	void Start () {
        lastSpawn = frequency;
	}
	
	// Update is called once per frame
	void Update () {
        lastSpawn -= Time.deltaTime;

        if(lastSpawn <= 0)
        {
            lastSpawn = frequency;
            if(Random.Range(0f, 1f) <= chance)
            {
                GameObject go = GameObject.Instantiate(props, transform.position, Random.rotation) as GameObject;

                if (score)
                    (go.GetComponent(typeof(RotatePills)) as RotatePills).score = score;
            }
        }
	}
}
