

using System.Collections.Generic;
using UnityEngine;

public class DebutDuJeu : GameEvent
{
    public override void Act(GameEventManager gem)
    {
        base.Act(gem);

        var t = GameObject.Find("DayCounter").GetComponent<TimeCounter>();
        t.BeginCounter();

        God.Get.Cata.Begin();


    }

}