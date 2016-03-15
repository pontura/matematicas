using UnityEngine;
using System.Collections;

public class FraccionesDraggingObject : MonoBehaviour {

    public int id;
    public GameObject id1;
    public GameObject id2;
    public GameObject id3;

    void Start()
    {
        SetOff();
    }
    public void Init(int id)
    {
        gameObject.SetActive(true);
        this.id = id;

        id1.SetActive(false);
        id2.SetActive(false);
        id3.SetActive(false);

        switch (id)
        {
            case 1: id1.SetActive(true); break;
            case 2: id2.SetActive(true); break;
            case 3: id3.SetActive(true); break;
        }
    }
    public void SetOff()
    {
        gameObject.SetActive(false);
    }
}
