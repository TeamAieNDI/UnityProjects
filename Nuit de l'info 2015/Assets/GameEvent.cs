using UnityEngine;
using System.Collections;

public abstract class GameEvent : MonoBehaviour {

    GameEventManager _gem;
    public virtual void Act(GameEventManager gem)
    {
        _gem = gem;
    }
	
    public void EndOfGameEvent()
    {
        _gem.NextGameEvent();
    }


}
