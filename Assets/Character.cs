using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void Idle()
    {
        anim.Play("character_idle", 0, 0);
    }
    public void Walk()
    {
        anim.Play("character_walk", 0, 0);
    }
    public void Wrong()
    {
        anim.Play("character_wrong", 0, 0);
    }
    public void Right()
    {
        anim.Play("character_right", 0, 0);
    }
}
