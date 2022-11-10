using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GenerateBlock levelPart;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform pullParent;
    [SerializeField] private TimeManager timeManager;

    [SerializeField] private int levelMaxSize;

    public static float LevelSpeed;

    private List<Transform> levelPull;
    private Transform player;
    private float addZpos => 10;
    private bool isCanMoveLevel;

    void Start()
    {
        levelPull = new List<Transform>();
        LevelSpeed = PlayerPrefs.GetInt("DifficultyLevel", 1) * 0.1f;
    }

    private void Update()
    {
        if (!isCanMoveLevel || levelPull.Count == 0) return;

        foreach (Transform part in levelPull)
        {
            part.transform.position -= new Vector3(0, 0, LevelSpeed);
        }

        if (levelPull[0].transform.position.z <= -17) DestroyPart(levelPull[0]);
    }

    public void GenerateLevel()
    {
        for (int i = 0; i < levelMaxSize; i++)
        {
            CreateNewPart();
        }

        player = Instantiate(playerPrefab).transform;
        CameraMoveController.target = player;
        PlayerCollisionController.Collision += StopLevel;
        isCanMoveLevel = true;
        timeManager.StartTimer();
    }

    public void DestroyLevel()
    {
        for (int i = levelPull.Count - 1; i > -1; i--)
        {
            Destroy(levelPull[i].gameObject);
            levelPull.RemoveAt(i);
        }
        Destroy(player.gameObject);
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

        GameObject createPart = Instantiate(levelPart.gameObject,
            addPartPosition,
            new Quaternion(),
            pullParent);

        if(levelPull.Count > 2) createPart.GetComponent<GenerateBlock>().GenerateBarrier();
        levelPull.Add(createPart.transform);
    }

    private void StopLevel()
    {
            isCanMoveLevel = false;
            DestroyLevel();
    }
}