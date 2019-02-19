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
        Debug.Log(CombineItem("handle", "stick"));
    }

    private void AddCombination(string itemName, string item)
    {
        combinations.Add(itemName, item);
    }

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

    // public bool CombinationExists(string attempt)
    // {
    //     // Get combination keys
    //     List<string> keys = combinationDictionary.Keys.ToList();
    //     // Sort combination alphabetically
    //     Array.Sort(attempt);
    //     bool exists = false;
    //     // Loop through each combination
    //     foreach (string key in keys)
    //     {
    //         // If combination matches return true
    //         if (key[0] == attempt[0] && key[1] == attempt[1])
    //         {
    //             exists = true;
    //             return exists;
    //         }
    //     }

    //     return exists;
    // }
}
