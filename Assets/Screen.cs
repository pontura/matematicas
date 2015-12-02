using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {

    public void Reset()
    {

    }
    public void Activate(bool active)
    {
        gameObject.SetActive(active);
    }
}
