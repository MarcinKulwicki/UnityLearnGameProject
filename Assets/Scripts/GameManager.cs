using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    public GameObject Player { get { return player; } private set { player = value; } }

    [SerializeField]
    private Transform destinationTransform;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] fokes;

    [SerializeField]

    private Transform freeCameraLookAt;

    private int actualFoke = 0;

    private Transform whereToLookAt;

    public Transform GetWhereToLookAt { get { return whereToLookAt; } }

    public float CalculateDistFromPlayer(Transform tr)
    {
        float dist = Vector3.Distance(player.transform.position, tr.position);
        return dist;
    }

    private void Start() 
    {
        whereToLookAt = fokes[actualFoke].transform;
    }

    private void Update()
    {
        CameraControll();
    }

    private void CameraControll()
    {
        for (int i = 0; i < fokes.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                whereToLookAt = fokes[i].transform; //Camera at foke
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            whereToLookAt = destinationTransform; //Camera at destination
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            whereToLookAt = freeCameraLookAt;
        }
    }

    public List<Transform> GetFokesPosition()
    {
        List<Transform> fokesPos = new List<Transform>();

        foreach(var foke in fokes)
        {
            fokesPos.Add(foke.transform);
        }

        return fokesPos;
    }
}
