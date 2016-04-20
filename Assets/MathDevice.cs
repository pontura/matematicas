using UnityEngine;
using System.Collections;

public class MathDevice : MonoBehaviour {

    public GameObject minigameA;
    public GameObject minigameB;
    public GameObject minigameC;

	public void Init(MinigamesManager.types type) {

        minigameA.SetActive(false);
        minigameB.SetActive(false);
        minigameC.SetActive(false);
        

        switch (type)
        {
            case MinigamesManager.types.PESAR: 
                minigameA.SetActive(true); 
                break;
            case MinigamesManager.types.SIMPLE_INPUT: 
                minigameB.SetActive(true);                
                break;
            case MinigamesManager.types.FRACCIONES:
                minigameC.SetActive(true);
                break; 
        }
	}
    public void Appear()
    {
        GetComponent<Animator>().Play("deviceAppear", 0, 0);
    }
    public void Disappear()
    {
        GetComponent<Animator>().Play("deviceDissappear", 0, 0);
    }
}
