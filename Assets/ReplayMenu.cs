using UnityEngine;
using System.Collections;

public class ReplayMenu : MonoBehaviour {

    public Animator anim;
    public AnimationClip clip;

    void Start()
    {
        anim.Play(clip.name);
    }
    public void Replay()
    {
        Data.Instance.LoadLevel("Game");
       
    }
}
