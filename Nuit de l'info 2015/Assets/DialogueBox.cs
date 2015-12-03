using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class DialogueBox : MonoBehaviour {

    Text _text;
    List<string> _currentTextDialogue;
    int _indice;
    Func<bool> _callBack;
    bool _isActif;


	void Awake()
    {
        Debug.Log("Dialogue Awake");
        _text = GetComponentInChildren<Text>();
    }

    public void InitaliseNewDialogue(List<string> dialogues, Func<bool> callback )
    {
        _isActif = true;
        _indice = -1;
        _currentTextDialogue = dialogues;
        _callBack = callback;
        Next();
    }


    void ChangeDialogue(string dialogue)
    {
        _text.text = dialogue;
    }

    public void Next()
    {
        _indice++;
        if(_currentTextDialogue.Count > _indice)
        {
            ChangeDialogue(_currentTextDialogue[_indice]);
        }
        else
        {
            _isActif = false;
            _callBack.Invoke();
        }
    }


}
