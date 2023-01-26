using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for not destroying
/// objects when switching scenes
/// </summary>
public class DontDestroy : MonoBehaviour
{
    public void DoNotDestroy()
    {
        GameObject[] dontDestroy = GameObject.FindGameObjectsWithTag("DontDestroy");
        DontDestroyOnLoad(this.gameObject);
    }
}
