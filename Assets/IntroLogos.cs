using UnityEngine;
using System.Collections;

public class IntroLogos : MonoBehaviour {

	void Start () {
        Invoke("StartGame", 4);
	}
    void StartGame()
    {
        Data.Instance.LoadLevel("01_Main");
    }
}