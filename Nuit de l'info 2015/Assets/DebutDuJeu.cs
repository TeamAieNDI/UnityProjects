

using System.Collections.Generic;
using UnityEngine;

public class DebutDuJeu : GameEvent
{
    public override void Act(GameEventManager gem)
    {
        base.Act(gem);
        Debug.Log(":)");
        God.Get.DialogueBoxSetActive(new List<string>() { "Là le jeu commence :) !" }, () => { EndOfGameEvent(); return true; });

    }

}