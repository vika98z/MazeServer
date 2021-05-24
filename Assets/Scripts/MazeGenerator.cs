﻿using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private string testString = "1,0,0,1,0,0,1,0,0,1,0,1,0,1,0,0,1,1,0,0,1,0,1,0,0,0,1,1,0,0,1,1,1,0,0,0,0,0,0,1,1,1,0,0,1,1,0,0,1,0,1,0,0,1,1,0,0,1,1,1,0,1,0,0,0,1,0,1,1,1,0,1,0,0,0,1,0,1,1,0,0,0,0,1,1,0,1,1,0,1,0,0,1,0,0,0,1,0,1,1,0,1,0,0,1,0,1,0,1,0,0,0,1,0,0,0,1,1,0,1,0,1,0,0,0,1,1,1,0,0,0,1,1,1,0,1,0,1,0,1,1,0,0,1,1,0,0,0,1,0,0,1,1,1,1,0,1,0,0,0,1,0,0,1,1,0,0,0,0,0,1,0,1,1,0,0,0,1,0,0,1,0,1,0,1,0,0,1,0,1,0,0,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,1,0,1,1,0,1,1,0,0,1,0,1,1,1,0,0,1,0,0,0,0,1,0,1,0,1,1,0,0,1,0,0,1,0,1,0,0,0,1,1,1,1,0,1,0,0,0,1,1,1,0,0,1,0,1,1,1,1,1,0,1,0,0,1,1,1,0,1,0,1,1,1,1,0,1,0,0,1,1,1,0,1,0,0,1,1,0,1,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,1,0,1,0,1,1,0,1,0,1,1,1,0,1,0,0,1,0,1,1,1,1,0,0,1,0,1,1,1,0,1,0,1,1,0,0,1,1,0,1,0,1,0,1,1,0,0,1,1,0,1,0,1,0,0,0,1,0,1,1,1,0,0,0,1,1,0,0,1,1,0,1,1,0,0,0,1,0,1,0,1,1,0,1,1,0,0,1,0,1,0,0,1,1,0,0,1,1,0,0,1,0,1,0,0,0,1,1,1,0,0,1,1,1,0,1,0,1,0,0,0,1,1,0,0,1,1,0,1,0,0,0,0,1,1,1,0,1,0,1,0,0,0,1,1,1,0,0,1,0,0,1,1,0,1,1,0,0,0,1,1,0,1,0,1,1,1,0,1,0,0,1,1,1,0,0,0,1,1,1,0,1,0,1,0,1,1,1,0,0,1,1,0,1,0,0,1,1,0,0,1,1,0,0,0,1,1,0,1,0,0,1,1,0,1,0,0,0,1,0,1,1,0,1,1,0,0,0,0,1,1,1,1,0,0,0,1,0,1,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,1,0,0,1,0,0,0,0,1,0,1,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,1,1,1,1,0,0,0,1,1,1,1,0,0,0,0,1,1,1,0,1,0,1,1,1,0,1,1,0,1,0,0,1,1,1,0,1,0,1,1,0,1,1,0,0,1,1,0,0,0,1,0,1,0,0,0,0,1,0,1,1,0,1,1,0,1,1,0,0,1,1,0,0,0,1,1,1,0,0,1,0,0,1,1,0,1,1,1,1,0,0,0,1,1,0,1,0,0,1,1,0,1,0,1,1,0,0,1,0,0,1,0,1,0,0,1,1,0,1,0,1,0,0,0,0,0,1,0,0,1,1,1,0,0,1,0,0,1,0,0,0,1,1,1,0,0,1,1,0,1,1,0,0,1,1,0,1,0,1,1,1,0,0,1,0,1,1,0,1,0,0,1,1,1,1,1,1,1,0,0,1,0,1,1,0,1,0,1,1,0,0,0,1,1,1,1,1,0,0,1,1,0,1,0,1,1,0,0,0,1,1,1,1,0,0,0,0,1,0,1,1,1,1,0,1,0,0,1,1,0,0,1,1,1,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,1,0,1,1,1,0,0,1,0,1,0,1,1,0,1,0,0,1,1,1,0,0,1,1,0,1,0,1,0,1,0,1,0,0,1,1,0,1,1,1,1,1,1,1,0,0,1,0,1,1,0,0,1,0,0,1,0,0,1,0,1,0,1,1,1,0,0,1,1,1,0,0,1,0,1,1,0,0,0,0,1,0,0,1,0,0,1,0,0,1,1,1,0,0,1,0,1,1,0,0,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,0,1,1,0,1,0,1,0,0,1,0,0,1,1,1,1,1,0,0,0,1,1,0,1,0,0,0,1,0,1,0,1,1,0,0,1,1,1,1,1,0,0,1,1,0,1,1,0,0,1,0,0,1,0,1,1,0,1,0,0,1,0,0,0,1,1,1,1,0,1,0,1,1,0,1,1,0,0,1,0,0,1,1,1,0,1,0,0,0,1,1,0,1,1,0,0,1,1,0,0,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,0,1,0,0,0,1,1,0,0,1,0,1,1,1,1,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0,0,1,1,0,0,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,0,0,0,1,1,1,0,1,0,1,0,1,1,1,0,0,0,1,1,1,1,0,1,1,1,0,1,1,1,0,0,0,0,1,0,0,1,1,1,0,0,0,1,0,0,1,0,1,0,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1,1,1,1,1,0,1,1,1";
    
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform wallsRoot;
    [SerializeField] private Transform mazeStart;
    [SerializeField] private float cellStep;

    private void Start()
    {
        testString = testString.Replace(",", "");
        CreateMaze(testString, 25, 25);
    }

    public void CreateMaze(string stringToParse, int xSize, int ySize)
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                if (i == 0)
                    CreateWall(i, j, 0, -0.5f, 0);

                if (j == 0)
                    CreateWall(i, j, -0.5f, 0, 90);
                
                for (int k = 0; k < 2; k++)
                {
                    int cellIndex = i * xSize * 2 + j * 2 + k;
                    if (stringToParse[cellIndex] == '1')
                    {
                        if (k == 0) //right wall
                            CreateWall(i, j, 0.5f, 0, 90);
                        else //bottom wall
                            CreateWall(i, j, 0, 0.5f, 0);
                    }
                }
            }
        }
    }

    private void CreateWall(int i, int j, float xOffset, float zOffset, int rotation)
    {
        var startPosition = mazeStart.position;
        var newPos = new Vector3(startPosition.x + j * cellStep + xOffset * cellStep, startPosition.y,
            startPosition.z + -1 * (i * cellStep + zOffset * cellStep));

        var wall = Instantiate(blockPrefab, newPos, Quaternion.Euler(0, rotation, 0), wallsRoot);
    }
}
