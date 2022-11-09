using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPart;
    [SerializeField] private Transform pullParent;
    [SerializeField] private List<Transform> levelPull;

    [SerializeField] private int levelMaxSize;
    private float addZpos => 10;//levelPart.transform.localScale.z;

    void Start()
    {
        GenerateLevel();
    }

    void Update()
    {
        foreach (Transform part in levelPull)
        {
            part.transform.position -= new Vector3(0, 0, 0.1f);
        }

        if (levelPull[0].transform.position.z <= -10) DestroyPart(levelPull[0]);
    }

    private void GenerateLevel()
    {
        levelPull = new List<Transform>();

        for (int i = 0; i < levelMaxSize; i++)
        {
            CreateNewPart();
        }
    }

    private void DestroyPart(Transform part)
    {
        levelPull.Remove(part);
        Destroy(part.gameObject);

        CreateNewPart();
    }

    private void CreateNewPart()
    {
        Vector3 addPartPosition = levelPull.Count == 0
            ? pullParent.transform.position
            : levelPull.Last().transform.position + new Vector3(0, 0, addZpos);

        GameObject createPart = Instantiate(levelPart,
            addPartPosition,
            new Quaternion(),
            pullParent);

        levelPull.Add(createPart.transform);
    }
}