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
        print("OnSaveBlockToDB title: " + title + "result: " + content);

        Hashtable blockData = new Hashtable();
        blockData.Add("title", title);
        blockData.Add("content", content);

        Hashtable data = new Hashtable();
        data.Add( Data.Instance.userData.totalBlocksNotes.ToString() , blockData);

        string url = SocialManager.Instance.FIREBASE + "/users/" + Data.Instance.userData.userID + "/block/.json";

        Debug.Log(url);

        HTTP.Request theRequest = new HTTP.Request("patch", url, data);

        theRequest.Send((request) =>
        {
            Hashtable jsonObj = (Hashtable)JSON.JsonDecode(request.response.Text);
            if (jsonObj == null)
            {
                Debug.LogError("server returned null or malformed response ):");
            }
            Debug.Log("block updated: " + request.response.Text);
        });
        AchievementsEvents.OnNewBlockSended();
        Events.OnBlockReset();
    }
}
