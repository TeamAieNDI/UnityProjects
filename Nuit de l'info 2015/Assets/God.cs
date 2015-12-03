using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class God : MonoBehaviour {

    DialogueBox _dialogueBox;
    static God Me;
    

    public static God Get
    {
        get { return GameObject.Find("God").GetComponent<God>(); }
    }

    void Awake()
    {
        Me = this;
        DontDestroyOnLoad(this);
        Debug.Log("God Manager");
    }


    public void LancementDuJeu()
    {
        Debug.Log("Lancement du Jeu");
        _dialogueBox = GameObject.Find("EspaceDialogue").GetComponent<DialogueBox>();

        DialogueBoxSetActive(new List<string>() { "Hello", "World", ":)" }, () => { Debug.Log("Fin du texte"); return true; });
    }

    public void DialogueBoxSetActive(List<string> textes, Func<bool> callback)
    {
        _dialogueBox.InitaliseNewDialogue(textes, () => { EndOfDialogue(callback); return true; });
    }

    void EndOfDialogue(Func<bool> callback)
    {
        Debug.Log("End Of Dialogue");
        _dialogueBox.gameObject.SetActive(false);
        callback.Invoke();
    }
	
}
