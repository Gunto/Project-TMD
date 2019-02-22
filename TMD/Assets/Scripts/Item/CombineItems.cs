// TODO: See Start() method

using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class CombineItems : MonoBehaviour
{
    private Dictionary<string, string> combinations;

    private void Start()
    {
        combinations = new Dictionary<string, string>();
        // Determine way to populate Dictionary with combinations
        AddCombination("handle-stick", "cane");
    }

    private void AddCombination(string itemName, string item)
    {
        combinations.Add(itemName, item);
    }

    // Returns the name of hte combined object
    public string CombineItem(string item1, string item2)
    {
        // Sort item names
        string[] itemArray = new string[2] { item1, item2 };
        Array.Sort(itemArray);
        string combo = string.Concat(item1, "-", item2).ToLower();

        // Check if combination exists
        if (combinations.ContainsKey(combo))
        {
            return combinations[combo];
        }
        else
        {
            return null;
        }
    }
}
