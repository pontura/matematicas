using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
    const string PREFAB_PATH = "Data";
    static Data mInstance = null;

    [HideInInspector] public IslandsManager islandsManager;
    [HideInInspector] public Inventary inventary;
    [HideInInspector] public GameManager gameManager;
    [HideInInspector] public MainMenu mainMenu;

    public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                    go.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {     
        Application.LoadLevel(aLevelName);
    }
    void Awake()
    {
        
        if (!mInstance)
            mInstance = this;
        //otherwise, if we do, kill this thing
        else
        {
            Destroy(this.gameObject);
            return;
        }

        islandsManager = GetComponent<IslandsManager>();
        inventary = GetComponent<Inventary>();       
        mainMenu = GetComponent<MainMenu>();
        gameManager = GetComponent<GameManager>();

    }
}
