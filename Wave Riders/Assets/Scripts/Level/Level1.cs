using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 1;
        GetCoords();
    }
    public override void PlaceObstacles()
    {

    }
}
