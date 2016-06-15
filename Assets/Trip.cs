using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Trip : Screen {

    public Text saleField;
    public Text destinoField;
    public ProgressBar progressBar;
    public int naftaConsumida;
    public int comidaConsumida;
    public int peso;

    public Text arena;
    public Text piedras;
    public Text madera;

    bool arrived;

    void Start()
    {
        Events.OnShipArrived += OnShipArrived;
    }
    void Update()
    {
        if (Data.Instance.DEBUG)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Events.OnShipArrived();
                Data.Instance.GetComponent<Inventary>().nafta = 9;
                Data.Instance.GetComponent<Inventary>().comida = 9;
                arrived = true;
            }
        }
    }
    void OnDestroy()
    {
        Events.OnShipArrived -= OnShipArrived;
    }

    override public void OnScreenEnable()
    {
        arrived = false;
        Events.OnBlockStatus(false);

        arena.text = "x" + Game.Instance.inventary.arena.ToString();
        piedras.text = "x" + Game.Instance.inventary.piedras.ToString();
        madera.text = "x" + Game.Instance.inventary.madera.ToString();

        comidaConsumida = 0;
        naftaConsumida = 0;

        Events.OnTripStarted();

        destinoField.text = Game.Instance.islandsManager.gotoIsland.name;
        saleField.text = Game.Instance.islandsManager.activeIsland.name;

       

        int secs = (int)Mathf.Ceil(Game.Instance.islandsManager.gotoIsland.distance / 25);

        print("TOTAL secs: " + secs + "  Game.Instance.islandsManager.gotoIsland.distance: " + Game.Instance.islandsManager.gotoIsland.distance);

        progressBar.Init(secs);

        peso = Game.Instance.inventary.GetPesoTotalEnElBarco();


        if (peso > Data.Instance.settings.barcoPesoMaximo)
        {
            Invoke("DiePorPeso", 2);
        }
	}

   
    void OnShipArrived()
    {
        Game.Instance.inventary.ConsumeElement("nafta", 1);
        Game.Instance.inventary.ConsumeElement("comida", 1);
        Game.Instance.gameManager.Arrived();
       // Game.Instance.mainMenu.Isla();
    }
    
    void DiePorPeso()
    {
        if (arrived) return;
        Events.OnShipDie();
        Data.Instance.LoadLevel("DeadPorPeso");
    }
}
