using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.UI
{
    public abstract class InteractionUI : MonoBehaviour
    {
        protected void GetInterfaceFromClass<T>(out List<T> resultInterface) where T : IInteraction
        {
            resultInterface = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<T>().ToList();
            gameObject.SetActive(false);
        }
    }
}