using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public Vector2 path;
    public Vector2 duration;
    public float distance;
    public int DistanceInMeters;
    public GameObject ship;
    private bool isOn;
    public Text distanceField;

    private int distancia_nafta;
    private int distancia_comida;

    public void Init(int _duration)
    {
        distancia_nafta = 0;
        distancia_comida = 0;

        DistanceInMeters = Game.Instance.islandsManager.gotoIsland.distance;

        print("DistanceInMeters: " + DistanceInMeters);

        this.duration = new Vector2(0, _duration);
        distance = 0;
        ship.transform.localPosition = new Vector2(path.x, ship.transform.localPosition.y);
        isOn = true;
	}
    void Update()
    {
        if (!isOn) return;
        distance += Time.deltaTime;
        

        float newPos =  GetResult(duration, path, distance);
        ship.transform.localPosition = new Vector2(newPos, ship.transform.localPosition.y);
        if (distance >= duration.y)
        {
            Ready();
        }
        int kms = (int)((distance * DistanceInMeters) / duration.y);

        if(kms>(Data.Instance.settings.distancia_Caja_Energia*(distancia_nafta+1)))            
            ConsumeNafta();
        if (kms > (Data.Instance.settings.horas_Caja_Comida * Data.Instance.settings.barcoVelocidad) * (distancia_comida + 1))            
            ConsumeComida();

        distanceField.text = "Distancia: " + kms + " km";
    }
    void Ready()
    {
        isOn = false;
        Events.OnShipArrived();
        Events.NewDistanceTraveled(DistanceInMeters);
    }
    float GetResult(Vector2 vect1, Vector2 vect2, float  p1)
    {
        return ((p1/(vect1.y - vect1.x)) * (vect2.y - vect2.x)) + vect2.x;
    }
    public void SetOff()
    {
        isOn = false;
    }
    void ConsumeNafta()
    {
        distancia_nafta++;
        Game.Instance.inventary.ConsumeElement("nafta", 1);
        if (Game.Instance.inventary.nafta <= 0)
            DeadPorNafta();
    }
    void ConsumeComida()
    {
        distancia_comida++;
        Game.Instance.inventary.ConsumeElement("comida", 1);
        if (Game.Instance.inventary.comida <= 0)
            DeadPorComida();
    }
    void DeadPorNafta()
    {
        Events.OnShipDie();
        Data.Instance.LoadLevel("DeadSinNafta");
    }
    void DeadPorComida()
    {
        Events.OnShipDie();
        Data.Instance.LoadLevel("DeadSinComida");
    }

}
