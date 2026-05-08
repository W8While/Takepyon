using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDairy", menuName = "Dairy/New Dairy")]
public class DairyBase : ScriptableObject
{
    [SerializeField] private List<string> _pages;
    public List<string> Pages => _pages;
}
