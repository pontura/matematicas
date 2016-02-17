using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public Vector2 path;
    public Vector2 duration;
    public float distance;
    public int DistanceInMeters;
    public GameObject ship;
    private bool isOn;

    public void Init(int _duration)
    {
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

}
