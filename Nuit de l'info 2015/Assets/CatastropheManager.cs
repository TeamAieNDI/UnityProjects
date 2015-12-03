using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CatastropheManager : MonoBehaviour {

    List<Ruche> _ruches;
    bool isActif;
    int nextCata;

    void Awake()
    {
        isActif = false;
        var Objruches = GameObject.FindGameObjectsWithTag("Ruche");
        _ruches = new List<Ruche>();
        foreach( var ruche in Objruches)
        {
            _ruches.Add(ruche.GetComponent<Ruche>());
        }

    }

    // Commence à balancer des catastrophes
    public void Begin()
    {
        isActif = true;
        // Génère un nouveau nextCata
        NewCata();
    }

    public void Update()
    {
        if (!isActif) return;
        
        if(nextCata == 0)
        {
            // Crée une catastrophe


            // Génère un nouveau nextCata
            NewCata();

        }
        else
        {
            nextCata--;
        }
        
    }

    void NewCata()
    {
        nextCata = (int)((Random.value)*100);
    }

    // Touche une zone
    void DeclenchePesticides()
    {

    }

    // Touche que sol
    void DeclencheInondation()
    {

    }

    // Touche que au dessus
    void DeclencheOuragan()
    {

    }

    // Touche une zone
    void DeclencheCanicule()
    {

    }

}
