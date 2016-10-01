using UnityEngine;
using System.Collections;

public class ConditionBase : MonoBehaviour {

    public GameObject cond;
    int eventId;
    void Start()
    {
        eventId = cond.GetInstanceID();
    }

    public virtual bool checkCondition()
    {
        
        return EventManager.eventStatus[eventId];
    }
	
}
