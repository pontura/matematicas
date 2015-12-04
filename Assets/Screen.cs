using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {

    public bool isActive;

    public void Reset()
    {

    }
    void OnEnable()
    {
        isActive = true;
        OnScreenEnable();
    }
    void OnDisable()
    {
        isActive = false;
    }
    public void Activate(bool active)
    {
        gameObject.SetActive(active);
    }

    public virtual void OnScreenEnable() {}
}
