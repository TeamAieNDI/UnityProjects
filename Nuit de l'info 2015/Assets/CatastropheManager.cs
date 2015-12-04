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

    System.Random MyRandom;

    void Awake()
    {
        MyRandom = new System.Random();
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
        DeclencheNouvelCatatrophe();
        isActif = true;
        
        // Génère un nouveau nextCata
        NewCata();
    }

    public void DeclencheNouvelCatatrophe()
    {
        var aSupprimer = new List<Ruche>();
        foreach(var ruche in _ruches)
        {
            if (ruche._population == 0)
                aSupprimer.Add(ruche);
        }

        foreach(var ruche in aSupprimer)
        {
            _ruches.Remove(ruche);
        }
        if (_ruches.Count == 0)
        {
            Application.LoadLevel("BadEnd");
            return;
        }
                

        switch(MyRandom.Next(1, 5))
        {
            case 1:
                DeclencheInondation();
                break;
            case 2:
                DeclencheOuragan();
                break;
            case 3:
                DeclencheCanicule();
                break;
            case 4:
                DeclenchePesticides();
                break;
        }

    }


    void NewCata()
    {
        nextCata = (int)((Random.value)*100);
    }

    Ruche ActualInPesticide;

    // Touche une zone
    void DeclenchePesticides()
    {
        var indice = MyRandom.Next(0, _ruches.Count);
        _ruches[indice].SetState(Ruche.Etat.Pesticide);

        ActualInPesticide = _ruches[indice];

        Invoke("StopPesticide", 5f);
    }

    void StopPesticide()
    {
        ActualInPesticide.SetState(Ruche.Etat.None);
        ActualInPesticide.ReturnToNormalColor();
        ActualInPesticide = null;
        DeclencheNouvelCatatrophe();

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

        Invoke("StopInondation", 3f);
    }

    void StopInondation()
    {
        FondDecranActuel.sprite = FondNormal;
        var t = _ruches.Where((r) => r.EstAuSol);
        foreach (var ruche in t)
        {
            ruche.SetState(Ruche.Etat.None);
        }
        DeclencheNouvelCatatrophe();

    }

    // Touche que au dessus
    void DeclencheOuragan()
    {

        var t = _ruches.Where((r) => !r.EstAuSol);
        foreach (var ruche in t)
        {
            ruche.SetState(Ruche.Etat.Ouragan);
        }

        Invoke("StopOuragan", 3f);
    }

    void StopOuragan()
    {
        FondDecranActuel.sprite = FondNormal;
        var t = _ruches.Where((r) => !r.EstAuSol);
        foreach (var ruche in t)
        {
            ruche.RemetPosition();
            ruche.SetState(Ruche.Etat.None);
        }
        DeclencheNouvelCatatrophe();

    }

    Ruche ActualInCanicule;

    // Touche une zone
    void DeclencheCanicule()
    {
        var indice = MyRandom.Next(0, _ruches.Count);
        _ruches[indice].SetState(Ruche.Etat.Canicule);

        ActualInCanicule = _ruches[indice];

        Invoke("StopCanicule", 5f);
    }
    void StopCanicule()
    {
        ActualInCanicule.SetState(Ruche.Etat.None);
        ActualInCanicule.ReturnToNormalColor();
        ActualInCanicule = null;
        DeclencheNouvelCatatrophe();

    }

}
