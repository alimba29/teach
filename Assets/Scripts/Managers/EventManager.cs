using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EventManager : MonoBehaviour
{
    public static Dictionary<int, bool> eventStatus;
    // Use this for initialization
    public EventManager()
    {
        eventStatus = new Dictionary<int, bool>();
    }
}
