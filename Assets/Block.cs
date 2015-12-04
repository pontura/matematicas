using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Block : Screen
{
    public Animation anim;
    override public void OnScreenEnable()
    {
        anim.Play("OpenBlock");
    }
    public void Close()
    {
        anim.Play("CloseBlock");
        Invoke("Reset", 0.5f);
    }
    void Reset()
    {
        gameObject.SetActive(false);
    }
}
