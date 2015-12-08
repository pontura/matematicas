﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipBox : MonoBehaviour {

    private Image containerImage;
    public Sprite item1;
    public Sprite item2;
    public Sprite item3;
    public Sprite item4;
    public Sprite item5;

	void Start () {
        containerImage = GetComponent<Image>();
        Empty();
	}
    public bool IsAvailable()
    {
        if (!containerImage.enabled) 
            return true;
        return false;
    }
    public void Empty()
    {
        containerImage.enabled = false;
    }
    public void Add(int id)
    {
        containerImage.enabled = true;

        print("ADD" + id);
        switch (id)
        {
            case 1: containerImage.sprite = item1; break;
            case 2: containerImage.sprite = item2; break;
            case 3: containerImage.sprite = item3; break;
            case 4: containerImage.sprite = item4; break;
            case 5: containerImage.sprite = item5; break;
        }
	}
}