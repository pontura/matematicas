using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockSaver : MonoBehaviour
{
    private GameObject container;

    void Start()
    {
        container = GetComponent<Block>().container;
        Events.OnSaveBlock += OnSaveBlock;
    }
    void OnDestroy()
    {
        Events.OnSaveBlock -= OnSaveBlock;
    }
    void OnSaveBlock(string title)
    {
        string result = "";
        foreach(BlockItem blockItem in container.GetComponentsInChildren<BlockItem>())
        {
            string content = "";

            if (blockItem.inputField != null)
                content = blockItem.inputField.text;
            if (blockItem.GetComponent<InputFieldCustom>())
                content = blockItem.GetComponent<InputFieldCustom>().GetContent();

            result += "*" + blockItem.id + "_" + content + "_" + (int)blockItem.transform.localPosition.x + "_" + (int)blockItem.transform.localPosition.y;
        }
        
        Events.OnSaveBlockToDB(title, result);
    }
}
