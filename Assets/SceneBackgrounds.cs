using UnityEngine;
using System.Collections;

public class SceneBackgrounds : MonoBehaviour {

    public MiningameBackground[] minigames;

	void Start () {
        foreach(MiningameBackground minigameBg in minigames)
            minigameBg.gameObject.SetActive(false);
	}
}
