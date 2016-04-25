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

    void Start()
    {
        Events.OnShipArrived += OnShipArrived;

    }
    void OnDestroy()
    {
        Events.OnShipArrived -= OnShipArrived;
    }

    override public void OnScreenEnable()
    {
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
        if (Game.Instance.inventary.nafta == 0)
        {
            Invoke("DeadPorNafta", 2);
        }
        else if (Game.Instance.inventary.comida == 0)
        {
            Invoke("DeadPorComida", 2);
        }
        else
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
        Data.Instance.LoadLevel("DeadPorPeso");
    }
}
