using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour {

    public GameObject[] prefabs;
    public Transform playerPostion;
    public List<GameObject> activeHills;
    public List<GameObject> activeSkies;
    float spawnX = 93;
    float safeZone = 50;
    float hillLength = 38;
    float skyLength = 66.4f;
    float spawnXSKY = 132.2f;
    // Use this for initialization
    void Start () {
        
        activeHills = new List<GameObject>();
        activeSkies = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Round(playerPostion.position.x)%30 == 0 && activeHills.Count<3)//spwan new hill
        {
            SpawnHill();
        }
        //if (Mathf.Round(playerPostion.position.x) % 76 == 0 )//delete hill made with this script where in the start
        //{
        //    deleteHill();
        //}
        if (Mathf.Round(playerPostion.position.x)% 40 == 0 && activeSkies.Count<3)//spwan new sky instead of moving it xD
        {
            SpawnHill(2);
        }
        //if (Mathf.Round(playerPostion.position.x) % 132 == 0)//delete sky made with this script where in the start
        //{
        //    deleteHill(3);
        //}
    }
    void SpawnHill(int prefabIndex = 1) // small Hil=1
    {
        GameObject go = Instantiate(prefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(this.transform);
        
        if (prefabIndex==1)
        {
            go.transform.position = new Vector3(spawnX, -0.8f, -1);
            spawnX += hillLength;
            activeHills.Add(go);
        }
        else if(prefabIndex==2)
        {
            go.transform.position = new Vector3(spawnXSKY, -0.8f, -1);
            spawnXSKY += skyLength;
            activeSkies.Add(go);
        }
        
    }
    void deleteHill(int prefabIndex = 1)
    {
        if (prefabIndex==1)
        {
            Destroy(activeHills[0]);
            activeHills.RemoveAt(0);
        }
        else if (prefabIndex==2)
        {
            Destroy(activeSkies[0]);
            activeSkies.RemoveAt(0);
        }
        
    }
}
