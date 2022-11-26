using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public abstract class Item : ScriptableObject
{

    public string nom;
  

    public abstract void Usar();


}
