using UnityEngine;
using System.Collections;

public class SceneBackgrounds : MonoBehaviour {

    public MiningameBackground[] minigames;

    public GameObject Customizer;
    public GameObject Trip;

    void Start()
    {
        ResetScenes();
        Events.OnCustomizerActive += OnCustomizerActive;
    }
    void ResetScenes()
    {
        foreach (MiningameBackground minigameBg in minigames)
            minigameBg.gameObject.SetActive(false);

        Customizer.SetActive(false);
        Trip.SetActive(false);
    }
	void OnDestroy()
    {
        Events.OnCustomizerActive -= OnCustomizerActive;
    }
    void OnCustomizerActive(bool state)
    {
        Customizer.gameObject.SetActive(state);
    }
}
