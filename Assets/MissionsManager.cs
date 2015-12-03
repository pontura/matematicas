using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionsManager : MonoBehaviour {

    public int activeId;

    public List<Mission> missions;

    void Start()
    {

    }
    public Mission GetActiveMission()
    {
        return missions[activeId];
    }

}
