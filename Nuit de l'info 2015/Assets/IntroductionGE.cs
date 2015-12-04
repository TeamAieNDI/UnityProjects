using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class IntroductionGE : GameEvent
{
    public override void Act(GameEventManager gem)
    {
        base.Act(gem);

        var dialogues = new List<string>()
        {
            "Hibou : Bonjour super Abeille ! Le monde est en danger ! Nous arrivons dans une période où il y a beaucoup de catastrophes !",
            "Super Abeille : Très bien quelle est ma mission ?",
            "Hibou : 4 catastrophes risquent de se produire ! La canicule, les inondations, les nuages de pesticides et les ouragans menacent votre belle société !",
            "Super Abeille : Mais que faire dans ces cas là ?",
            "Hibou : Tu as a la possibilité de résoudres ces problèmes.",
            "Hibou : En cas de canicule, il faut s'hydrater, grâce à tes pouvoirs tu peux faire tomber la pluie sur la ruche.",
            "Hibou : En cas d'inondation, le mieux est se mettre en hauteur. Préviens les abeilles qui habitent au sol lors d'une inondation.",
            "Hibou : Les nuages de pesticides sont nocifs pour la santé comme en cas de nuage radioactif. La meilleure solution est de ne pas sortir. Dis aux abeilles de rester dans la ruche.",
            "Hibou : Les ouragans touchent les ruches dans les arbres,  la meilleure solution est de baricader les ouvertures.",
            "Super Abeille : Comment faire pour utiliser mes pouvoirs ?",
            "Hibou : Tu n'as qu'à toucher la ruche en danger et appliquer ta magie. Mais soit rapide car lors d'une catastrophe la population d'une ruche diminue, tu dois absolument éviter que les populations arrivent à zéro.",
            "Super Abeille : Mais toi tu pourras m'aider ?",
            "Hibou : Nan mais t'as rêvé ? Je suis juste un hibou ... Allez  bonne chance !"
        };




        God.Get.DialogueBoxSetActive(dialogues, () => { EndOfGameEvent(); return true; });
        
    }


}
