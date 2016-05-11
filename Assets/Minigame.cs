﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minigame : MonoBehaviour {

    public Text desc;
    public Text descSmall;

    void OnEnable()
    {
       // desc.text = "";
      //  descSmall.text = "";
    }

    virtual public void Reset()
    {

    }
    virtual public string GetDescriptionForBlock()
    {
        if (desc.text.Length > 0)
            return desc.text;
        else
            return descSmall.text;
    }
}
