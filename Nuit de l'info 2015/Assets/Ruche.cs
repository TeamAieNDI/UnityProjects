using UnityEngine;
using System.Collections;

public class Ruche : MonoBehaviour {

    int _population;
    public bool _estAuSol;

    public enum Etat
    {
        None,
        Pesticide,
        Inondation,
        Ouragan,
        Canicule
    }


    void Awake()
    {
        _population = 100;



    }

}
