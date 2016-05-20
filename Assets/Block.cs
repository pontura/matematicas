using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Block : Screen
{
    public Animation anim;
    public BlockItem[] blockItems;
    public BlockItem draggingBlockItem;
    public GameObject container;
    public GameObject Helper;

    void Start()
    {
        Events.OnBlockStatus += OnBlockStatus;
        Events.OnBlockReset += OnBlockReset;
        Events.OnBlockSendRequest += OnBlockSendRequest;
    }
    void OnDestroy()
    {
        Events.OnBlockStatus -= OnBlockStatus;
        Events.OnBlockSendRequest -= OnBlockSendRequest;
        Events.OnBlockReset -= OnBlockReset;
    }
    void OnBlockStatus(bool show)
    {
        print("OnBlockStatus" + show);
        gameObject.SetActive(show);
    }
    public void Open()
    {
        anim.Play("OpenBlock");
    }
    public void Close()
    {
        anim.Play("CloseBlock");
        Invoke("Reset", 0.5f);
    }
    void Reset()
    {
        gameObject.SetActive(false);
    }
    static private KeyCode[] validKeyCodes;
    private void Init()
    {
        if (validKeyCodes != null) return;
        validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
    }
    void OnBlockReset()
    {
        print("_______OnBlockReset");
        int num = container.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(container.transform.GetChild(0).gameObject);
    }
    void Update()
    {
        if (container.transform.childCount >0) Helper.SetActive(false);
        else Helper.SetActive(true);

        if (Input.anyKeyDown)
        {
            if (draggingBlockItem != null && draggingBlockItem.inputField != null)
            {
                if (Input.GetKeyDown(KeyCode.Backspace) && draggingBlockItem.inputField.text.Length>0)
                draggingBlockItem.inputField.text = draggingBlockItem.inputField.text.Remove(draggingBlockItem.inputField.text.Length - 1);
                else draggingBlockItem.inputField.text += Input.inputString;
            }
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                BlockButton bb = hit.collider.gameObject.GetComponent<BlockButton>();
                if (bb != null)
                {
                    AddItem(bb);
                }
                else
                {
                    BlockItem bi = hit.collider.gameObject.GetComponent<BlockItem>();
                    if (bi != null)
                        draggingBlockItem = bi;
                }
            }
            else draggingBlockItem = null;
        }
        if (Input.anyKey)
        {
            if (draggingBlockItem != null)
            {
                draggingBlockItem.transform.position = Input.mousePosition;
            }
        }
        if (draggingBlockItem)
        {
            if (draggingBlockItem.transform.position.x > UnityEngine.Screen.width/2)
            {
                
                Destroy(draggingBlockItem.gameObject);
            }
        }
    }   
    public void AddItem(BlockButton bb)
    {
        BlockItem bi = blockItems[bb.id];
        BlockItem newBi = Instantiate(bi);
        newBi.id = bb.id;
        newBi.transform.SetParent(container.transform);
        draggingBlockItem = newBi;
        draggingBlockItem.transform.localScale = Vector3.one;
    }
    private string title;
    void OnBlockSendRequest(string title)
    {
        this.title = title;
        Invoke("OnBlockSendRequestDelayed", 2);
        Game.Instance.mainMenu.SetDisableButtons(true);
    }
    void OnBlockSendRequestDelayed()
    {
        OnBlockStatus(true);
        Game.Instance.mainMenu.BlockOpen();
        GetComponent<BlockSendRequestPanel>().Init(title);
    }
}
