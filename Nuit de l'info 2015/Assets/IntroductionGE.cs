using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class IntroductionGE : GameEvent
{
    public override void Act(GameEventManager gem)
    {
        base.Act(gem);

        God.Get.DialogueBoxSetActive(new List<string>() { "Joue !" }, () => { EndOfGameEvent(); return true; });
        
    }


}
