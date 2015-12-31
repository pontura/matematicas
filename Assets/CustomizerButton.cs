using UnityEngine;
using System.Collections;

public class CustomizerButton : MonoBehaviour
{

    public int id;

    public void Prev()
    {
        Events.OnCustomizerButtonPrevClicked(id);
    }
    public void Next()
    {
        Events.OnCustomizerButtonNextClicked(id);
    }
}
