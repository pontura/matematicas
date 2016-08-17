using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {

    public int[] secs;
    public GameObject[] texts;
    public int num;
    public GameObject loading;

	void Start () {
        Data.Instance.VolumenIntro();
        foreach (GameObject go in texts)
            go.SetActive(false);
        texts[num].SetActive(true);
        Invoke("Next", secs[num]);
	}
	void Next () {
        foreach (GameObject go in texts)
            go.SetActive(false);
        num++;
        if (num >= texts.Length)
            Ready();
        else
        {
            texts[num].SetActive(true);
            Invoke("Next", secs[num]);
        }

	}
    public void Ready()
    {
        Events.OnSoundFX("click");
        loading.SetActive(true);
        GetComponent<AudioSource>().Stop();
        Invoke("Delay", 0.1f);
    }
    public void Delay()
    {
        Data.Instance.LoadLevel("Game");        
    }
}
