using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdminBlock : MonoBehaviour {

    public Text field;
    public GameObject panel;
    public GameObject container;
    public BlockItem[] blockItems;

    void Start()
    {
        panel.SetActive(false);
    }
	public void Init (AdminEjercicios.Block block) {
        
        panel.SetActive(true);

        field.text = block.title;
        int num = container.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(container.transform.GetChild(0).gameObject);
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
