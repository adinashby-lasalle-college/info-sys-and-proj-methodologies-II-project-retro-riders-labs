using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    [SerializeField] private GameObject copLeft;
    [SerializeField] private GameObject copRight;

    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 2;
        GetCoords();
    }

    void Start()
    {
        copLeft.SetActive(false);
        copRight.SetActive(false);
        PlaceObstacles();
    }
    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int carInt = rand.Next(0, 2);

        if(carInt == 1)
        {
            copLeft.SetActive(true);
        }
        else
        {
            copRight.SetActive(true);
        }
    }
}
