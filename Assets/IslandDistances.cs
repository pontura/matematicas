using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IslandDistances : MonoBehaviour {

    public List<Ruta> rutas;

    [Serializable]
    public class Ruta
    {
        public string name;
        public List<IslaData> islas;
        public int total;
        public GameObject lineAsset;
    }

    [Serializable]
    public class IslaData
    {
        public int islaID;
        public string fraccion;
        public int km;
        public string ruta;
    }

    public List<IslaData> resultsIslaA;
    public List<IslaData> resultsIslaB;

    void OnEnable()
    {
        foreach (Ruta ruta in rutas)
        {
            ruta.lineAsset.SetActive(false);
        }
    }

	public string GetRuta (int islaA, int islaB) {
        print("GetRuta " + islaA + "     islaB   " + islaB);

        resultsIslaA.Clear();
        resultsIslaB.Clear();
	    string result = "";
        
        foreach (Ruta ruta in rutas)
        {
            ruta.lineAsset.SetActive(false);
            foreach (IslaData isla in ruta.islas)
            {
                if (isla.islaID == islaA) 
                {
                    resultsIslaA.Add(isla);
                }
                if (isla.islaID == islaB) 
                {
                    resultsIslaB.Add(isla);
                }
            }
        }
        if (resultsIslaA.Count == 0 || resultsIslaB.Count == 0) return "";

        foreach (IslaData dataA in resultsIslaA)
        {
            foreach (IslaData dataB in resultsIslaB)
            {
                if (dataA.ruta == dataB.ruta)
                {
                    SetActiveRuta(dataA.ruta);
                    string origen = "el continente";
                    if (dataA.ruta == "E")
                        origen = "la Ruta E";

                    if (dataA.islaID == 1)
                        result = "Estás en el continente.";
                    else if (dataA.islaID == 4)
                        result = "Estás al inicio de la Ruta E";
                    else
                        result = "La isla en la que estás se encuentra a " + dataA.km + " km de el continente.";

                    result += "\nTu destino está a " + dataB.fraccion + "  de la distancia entre " + origen + " y el final de esta ruta.";
                }
            }
        }

        
        return result;
	}
    void SetActiveRuta(string rutaName)
    {
        foreach(Ruta ruta in rutas)
        {
            if (ruta.name == rutaName)
            {
                ruta.lineAsset.SetActive(true);
            }
        }
    }
}
