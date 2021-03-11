using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public enum Global
    {
        BulletBill,
        Fireball,
        Flower,
        Mario,
        Mushroom,
        Puff,
        Shell,
        Smoke,
        Turtle1,

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

    public GameObject Instancier(Global global, Vector3 pos, Quaternion rot)
    {
        return Instantiate(PrefabsObjects[(int)global], pos, rot);
    }
}
