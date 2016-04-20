using UnityEngine;
using System.Collections;

public class FraccionesSlot : MonoBehaviour {

    public int id;
    public GameObject id1;
    public GameObject id2;
    public GameObject id3;

    //resultado + piedra puesta:
    public int resultPiedraID;
    public int piedraID;

    void Start()
    {
        SetOff();
    }
    public void Init(int id)
    {
        id1.SetActive(false);
        id2.SetActive(false);
        id3.SetActive(false);

        switch (id)
        {
            case 1: id1.SetActive(true); break;
            case 2: id2.SetActive(true); break;
            case 3: id3.SetActive(true); break;
        }

        this.piedraID = id;
    }
    public void SetOff()
    {
        id1.SetActive(false);
        id2.SetActive(false);
        id3.SetActive(false);
        this.piedraID = 0;
    }
}
