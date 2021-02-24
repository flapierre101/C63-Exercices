using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public enum Global
    {
        barrel,
        bomb,
        bullet,
        explosion,
        explosionBarrel,
        monster,
        monster2,
        pickupBomb,
        pickupHealth,
        spawner,

        Count
    };

    public GameObject[] PrefabsObjects;

    public void Awake()
    {
        // https://docs.unity3d.com/ScriptReference/Resources.html
        PrefabsObjects = Resources.LoadAll<GameObject>("shooter/prefabs/global");
        Debug.Assert((int)Global.Count == PrefabsObjects.Length, "PrefabsObjects : Prefabs enum length (" + 
            (int)Global.Count + ") does not match Resources folder (" + PrefabsObjects.Length + ")");
    }

    public void Instancier(Global global, Vector3 pos, Quaternion rot)
    {
        Instantiate(PrefabsObjects[(int)global], pos, rot);
    }
}
