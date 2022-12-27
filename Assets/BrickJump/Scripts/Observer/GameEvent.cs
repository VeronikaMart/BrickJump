using System.Collections.Generic;
using UnityEngine;

namespace StackJump.Observer
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/Game Event")]
    public class GameEvent : ScriptableObject
    {
        // The list of listeners that this event will notify if triggered
        private List<GameEventListener> eventListeners = new List<GameEventListener>();

        public void TriggerEvent()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventTriggered();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            eventListeners.Remove(listener);
        }
    }
}