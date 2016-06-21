using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BlocksManager : MonoBehaviour {

    public List<Data> data;

    [Serializable]
    public class BlockData
    {
        public string title;
        public string content;
    }

    void Start()
    {
        Events.OnSaveBlockToDB += OnSaveBlockToDB;
    }
    void OnDestroy()
    {
        Events.OnSaveBlockToDB -= OnSaveBlockToDB;
    }
    
    void OnSaveBlockToDB(string title, string content)
    {
        AchievementsEvents.OnNewBlockSended();
        Events.OnBlockReset();
    }
}
