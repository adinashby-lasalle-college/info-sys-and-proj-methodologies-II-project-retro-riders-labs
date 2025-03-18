using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 2;
        GetCoords();
    }
    public override void PlaceObstacles()
    {

    }
}
