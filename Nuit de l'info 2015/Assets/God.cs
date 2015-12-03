using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

        _dialogueBox.InitaliseNewDialogue(new List<string>() { "Hello", "World", ":)" }, () => { Debug.Log("Fin du texte"); return true; });
    }

    public void DialogueBoxSetActive(bool actif)
    {
        _dialogueBox.gameObject.SetActive(actif);
    }

	
}
