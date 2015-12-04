using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HappyEnd : MonoBehaviour {

	void Awake()
    {
        God.Get.RecupDialogue();
        God.Get.DialogueBoxSetActive(new List<string>()
        {
            "Felicitation", ":)"
        }, () => { Application.LoadLevel("01-MenuPrincipal"); return true; });
    }
}
