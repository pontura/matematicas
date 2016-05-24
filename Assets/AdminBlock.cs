using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class AdminBlock : MonoBehaviour {

    public Text field;
    public GameObject panel;
    public GameObject container;
    public BlockItem[] blockItems;

    public List<BlockItemData> blockItemsData;

    [Serializable]
    public class BlockItemData
    {
        public int id;
        public string value;
        public Vector2 position;
    }

    void Start()
    {
        panel.SetActive(false);
    }
	public void Init (AdminEjercicios.Block block) {

        blockItemsData.Clear();
        panel.SetActive(true);

        field.text = block.title;
        int num = container.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(container.transform.GetChild(0).gameObject);
        String[] itemsData = block.result.Split("*"[0]);
        if (itemsData != null && itemsData.Length > 0)
        {
            foreach (string itemDataAll in itemsData)
            {
                if (itemDataAll.Length > 1)
                {
                    String[] itemData = itemDataAll.Split("_"[0]);
                    BlockItemData blockItemData = new BlockItemData();
                    blockItemData.id = int.Parse(itemData[0]);
                    blockItemData.value = itemData[1];
                    blockItemData.position = new Vector2(int.Parse(itemData[2]), int.Parse(itemData[3]));
                    blockItemsData.Add(blockItemData);
                }
            }
        }
        foreach (BlockItemData blockItemData in blockItemsData)
        {
            BlockItem blockItem = Instantiate(blockItems[blockItemData.id]);
            blockItem.transform.SetParent(container.transform);
            blockItem.transform.localScale = Vector2.one;
            blockItem.transform.localPosition = blockItemData.position;
            blockItem.SetContent(blockItemData.value);
        }
	}
    public void AddItem(int id)
    {
        BlockItem bi = blockItems[id];
        BlockItem newBi = Instantiate(bi);
        newBi.id = id;
        newBi.transform.SetParent(container.transform);
    }
    public void Close()
    {
        panel.SetActive(false);
    }
}
