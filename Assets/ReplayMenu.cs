using UnityEngine;
using System.Collections;

public class ReplayMenu : MonoBehaviour {

    public void Replay()
    {
        Data.Instance.LoadLevel("Game");
    }
}
