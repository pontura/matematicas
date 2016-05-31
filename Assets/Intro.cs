using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {

    public GameObject[] texts;
    public int num;

	void Start () {
        foreach (GameObject go in texts)
            go.SetActive(false);
        texts[num].SetActive(true);
	}
	
	public void Next () {
        foreach (GameObject go in texts)
            go.SetActive(false);
        num++;
        if (num >= texts.Length)
            Ready();
        else
        {
            texts[num].SetActive(true);
        }
	}
    void Ready()
    {
        Data.Instance.LoadLevel("Game");
    }
}
