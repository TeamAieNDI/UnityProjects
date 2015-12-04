using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class CatastropheManager : MonoBehaviour {

    List<Ruche> _ruches;
    bool isActif;
    int nextCata;

    Image FondDecranActuel;

    Sprite FondNormal;
    Sprite FondInonde;

    void Awake()
    {
        FondNormal = Resources.Load<Sprite>("IMG/FondNormal");
        FondInonde = Resources.Load<Sprite>("IMG/FondInonde");

        FondDecranActuel = GameObject.Find("Fond du jeu").GetComponent<Image>();

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
        DeclencheInondation();
        isActif = true;
        
        // Génère un nouveau nextCata
        NewCata();
    }

    public void Update()
    {
        /*
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
        */
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

        FondDecranActuel.sprite = FondInonde;

        var t = _ruches.Where( (r) => r.EstAuSol);
        foreach(var ruche in t)
        {
            ruche.SetState(Ruche.Etat.Inondation);
        }

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
