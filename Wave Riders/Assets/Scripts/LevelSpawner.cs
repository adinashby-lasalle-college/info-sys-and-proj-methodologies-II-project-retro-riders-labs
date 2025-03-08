using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private List<Level> levels = new List<Level>();

    GameObject tempLVL;
    private Vector3 nextSpawn;
    private Vector3 lvlLength;
    private Quaternion spawnQ;


    private void Awake()
    {
        nextSpawn = startPos.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        levels.Add(levels[0]);

        tempLVL = Instantiate(levels[2].gameObject,startPos);
        lvlLength = tempLVL.GetComponent<Level>().StartCoords.position - tempLVL.GetComponent<Level>().EndCoords.position;

        for (int i = 0; i < levels.Count; i++)
        {
            nextSpawn += lvlLength;
            tempLVL = Instantiate(levels[i].gameObject, nextSpawn, spawnQ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
