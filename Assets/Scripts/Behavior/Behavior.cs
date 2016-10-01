using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour {
    
    public ConditionBase[] conds;
    public ActionBase[] actions;
	// Use this for initialization
    bool done = false;
	// Update is called once per frame
    int eventId;
    

    void Start()
    {
        eventId = this.gameObject.GetInstanceID();
        EventManager.eventStatus[eventId] = false;
    }

    void Awake()
    {
        conds = GetComponents<ConditionBase>();
        actions = GetComponents<ActionBase>();
    }
	void Update () {
        int c = 0;
        foreach(ConditionBase cond in conds){
            
            if (cond.checkCondition())
            {
                
                c++;
            }
                
        }
        if (c == conds.Length && !done)
        {
            action();
        }
	}
    public void action()
    {
        updateEventInfo();
        done = true;
        foreach (ActionBase act in actions)
        {
            act.action();
        }
    }

    void updateEventInfo()
    {
        
        Debug.Log("Event: " + this.gameObject.name);
        EventManager.eventStatus[eventId] = true;
    }
}
