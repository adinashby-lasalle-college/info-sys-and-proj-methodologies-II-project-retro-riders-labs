using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Level startLevel;
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private int LvlLength;

    GameObject tempLVL;
    private Vector3 nextSpawn;
    private Vector3 blockLength;
    private Quaternion spawnQ;
    private int tempInt;
    

    private void Awake()
    {
        nextSpawn = startPos.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        tempLVL = Instantiate(startLevel.gameObject,startPos);
        blockLength = tempLVL.GetComponent<Level>().StartCoords.position - tempLVL.GetComponent<Level>().EndCoords.position;

        for(int i = 0; i < LvlLength; i++)
        {
            nextSpawn -= blockLength;
            tempLVL = Instantiate(levels[GetRandomLevel()].gameObject, nextSpawn, spawnQ);
        }
    }


    private int GetRandomLevel()
    {
        int lvlInt;
        
        do {
            
            System.Random rand = new System.Random();
            lvlInt = rand.Next(0, levels.Count);

        } while (lvlInt == tempInt);

        tempInt = lvlInt;
        return lvlInt;

    }
}
