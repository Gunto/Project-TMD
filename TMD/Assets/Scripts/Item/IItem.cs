﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string ItemName { get; }

    bool ActiveItem { get; set; }
}
