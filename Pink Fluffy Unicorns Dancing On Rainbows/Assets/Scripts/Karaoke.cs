using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Karaoke : MonoBehaviour {

    public AudioSource intro;
    public AudioSource song;

    public Text pink;
    public Text fluffy;
    public Text unicorns;
    public Text dancing;
    public Text on;
    public Text rainbows;


    public float pinkTime = 0f;
    public float fluffyTime = .5f;
    public float unicornsTime = 1f;
    public float dancingTime = 2f;
    public float onTime = 2.55f;
    public float rainbowsTime = 2.8f;

    protected bool playing = false;

    protected float idleY = -412.09f;
    protected float currentY = -330f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(!playing && song.isPlaying && !intro.isPlaying)
        {
            playing = true;

            pink.gameObject.SetActive(true);
            fluffy.gameObject.SetActive(true);
            unicorns.gameObject.SetActive(true);
            dancing.gameObject.SetActive(true);
            on.gameObject.SetActive(true);
            rainbows.gameObject.SetActive(true);
        }

        if(song.time > rainbowsTime)
        {
            ClearAllText();
            rainbows.fontStyle = FontStyle.Bold;
            rainbows.fontSize = 25;

            rainbows.rectTransform.anchoredPosition = new Vector2(rainbows.rectTransform.anchoredPosition.x, currentY);

            return;
        }

        if (song.time > onTime)
        {
            ClearAllText();
            on.fontStyle = FontStyle.Bold;
            on.fontSize = 25;

            on.rectTransform.anchoredPosition = new Vector2(on.rectTransform.anchoredPosition.x, currentY);
            
            return;
        }

        if (song.time > dancingTime)
        {
            ClearAllText();
            dancing.fontStyle = FontStyle.Bold;
            dancing.fontSize = 25;

            dancing.rectTransform.anchoredPosition = new Vector2(dancing.rectTransform.anchoredPosition.x, currentY);
            
            return;
        }

        if (song.time > unicornsTime)
        {
            ClearAllText();
            unicorns.fontStyle = FontStyle.Bold;
            unicorns.fontSize = 25;

            unicorns.rectTransform.anchoredPosition = new Vector2(unicorns.rectTransform.anchoredPosition.x, currentY);
            
            return;
        }

        if (song.time > fluffyTime)
        {
            ClearAllText();
            fluffy.fontStyle = FontStyle.Bold;
            fluffy.fontSize = 25;

            fluffy.rectTransform.anchoredPosition = new Vector2(fluffy.rectTransform.anchoredPosition.x, currentY);
            
            return;
        }

        if (song.time > pinkTime)
        {
            ClearAllText();
            pink.fontStyle = FontStyle.Bold;
            pink.fontSize = 25;

            pink.rectTransform.anchoredPosition = new Vector2(pink.rectTransform.anchoredPosition.x, currentY);
            
            return;
        }
	}

    void ClearAllText()
    {
        pink.fontStyle = FontStyle.Normal;
        fluffy.fontStyle = FontStyle.Normal;
        unicorns.fontStyle = FontStyle.Normal;
        dancing.fontStyle = FontStyle.Normal;
        on.fontStyle = FontStyle.Normal;
        rainbows.fontStyle = FontStyle.Normal;

        pink.fontSize = 20;
        fluffy.fontSize = 20;
        unicorns.fontSize = 20;
        dancing.fontSize = 20;
        on.fontSize = 20;
        rainbows.fontSize = 20;

        pink.rectTransform.anchoredPosition     = new Vector2(pink.rectTransform.anchoredPosition.x,        idleY);
        fluffy.rectTransform.anchoredPosition   = new Vector2(fluffy.rectTransform.anchoredPosition.x,      idleY);
        unicorns.rectTransform.anchoredPosition = new Vector2(unicorns.rectTransform.anchoredPosition.x,    idleY);
        dancing.rectTransform.anchoredPosition  = new Vector2(dancing.rectTransform.anchoredPosition.x,     idleY);
        on.rectTransform.anchoredPosition       = new Vector2(on.rectTransform.anchoredPosition.x,          idleY);
        rainbows.rectTransform.anchoredPosition = new Vector2(rainbows.rectTransform.anchoredPosition.x,    idleY);
    }
}
