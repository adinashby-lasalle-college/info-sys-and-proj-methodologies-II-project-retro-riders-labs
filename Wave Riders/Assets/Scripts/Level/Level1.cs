using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private GameObject SpeedBoost;

    Vector3 obstacleDisplacement = new Vector3(25, 0, 0);
    Vector3 boostDisplacement = new Vector3(28, 0, 0);

    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 1;
        GetCoords();
        PlaceObstacles();
    }
    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int obsInt = rand.Next(0, 2);

        if (obsInt == 1)
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.transform.position += obstacleDisplacement;
            }
            SpeedBoost.transform.position -= boostDisplacement;
        }
    }
}
