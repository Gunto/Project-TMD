using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    bool Obtainable { get; }
    string itemName { get; }
}
