using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public enum Global
    {
        Shell,
        Smoke,
        Turtle1,
        Bullet,

        Count
    };
    public enum Vfx
    {
       

        Count
    };

    public GameObject[] PrefabsObjects;

    public void Awake()
    {
        
        PrefabsObjects = Resources.LoadAll<GameObject>("prefabs/global");
        Debug.Assert((int)Global.Count == PrefabsObjects.Length, "PrefabsObjects : Prefabs enum length (" + 
            (int)Global.Count + ") does not match Resources folder (" + PrefabsObjects.Length + ")");
    }

    public void Instancier(Global global, Vector3 pos, Quaternion rot)
    {
        Instantiate(PrefabsObjects[(int)global], pos, rot);
    }
}
