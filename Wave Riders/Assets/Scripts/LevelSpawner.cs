using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private Transform StartPos;
    [SerializeField] private List<Level> Levels = new List<Level>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempOBJ;
        tempOBJ = Instantiate(Levels[0].gameObject,StartPos);
        Instantiate(Levels[1].gameObject, tempOBJ.GetComponent<Level>().EndCoords);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
