using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameEventManager : MonoBehaviour
{

    List<GameEvent> _actions;
    int indice;
    
    void Awake()
    {
        indice = 0;
        _actions = new List<GameEvent>()
        {
            AddGameEvent(typeof(IntroductionGE)),
            AddGameEvent(typeof(DebutDuJeu))
        };
    }

    public GameEvent AddGameEvent(Type type)
    {
        return this.gameObject.AddComponent(type) as GameEvent;
    }

    public void NextGameEvent()
    {
        if(indice < _actions.Count)
        {
            _actions[indice].Act(this);
            indice++;
        }
        else
        {
            Debug.Log("Fin du jeu");
        }
        
    }


    public void Go()
    {
        NextGameEvent();
    }

}
