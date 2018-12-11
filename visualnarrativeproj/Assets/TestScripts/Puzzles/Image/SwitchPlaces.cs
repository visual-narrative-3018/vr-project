using UnityEngine;
using System;
using System.Collections;

public class SwitchPlaces : Singleton<SwitchPlaces>
{
    public int speed = 10;
    public int totalSwaps = 13;
    public GameObject[] originalArray = new GameObject[6];
    private Vector3[] startingPositions = new Vector3[6];
    public GameObject[] orderedArray;
    public int total;
    public int chosenIndex = -1;
    public Boolean doneMoving = true;
    public Color color = Color.white;
    // reference to exhibit script
    public GameObject exhibit;

    void Start()
    {
        orderedArray = (GameObject[])originalArray.Clone();
        total = orderedArray.Length;
        UpdateStartingPositions();
        color.a = 0.66f;
        StartCoroutine(RandomizeOrder());
        this.Awake();
    }

    void UpdateStartingPositions()
    {
        for (int i = 0; i < total; i++)
        {
            startingPositions[i] = orderedArray[i].transform.position;
        }
    }

    IEnumerator RandomizeOrder()
    {
        for (int i = 0; i < totalSwaps; i++)
        {
            while (!doneMoving)
            {
                yield return null;
            }
            StartCoroutine(SwapPositions(UnityEngine.Random.Range(0, total), UnityEngine.Random.Range(0, total), true));
        }
    }

    public IEnumerator SwapPositions(int a, int b, Boolean isStarting = false)
    {
        //To prevent the swap before another one is finished
        doneMoving = false;
        while (Vector3.Distance(orderedArray[a].transform.position, startingPositions[b]) > 0.01f ||
               Vector3.Distance(orderedArray[b].transform.position, startingPositions[a]) > 0.01f)
        {
            orderedArray[a].transform.position = Vector3.MoveTowards(orderedArray[a].transform.position, startingPositions[b], speed * Time.deltaTime);
            orderedArray[b].transform.position = Vector3.MoveTowards(orderedArray[b].transform.position, startingPositions[a], speed * Time.deltaTime);
            yield return null;
        }

        orderedArray[a].transform.position = startingPositions[b];
        orderedArray[b].transform.position = startingPositions[a];

        GameObject temp = orderedArray[a];
        orderedArray[a] = orderedArray[b];
        orderedArray[b] = temp;

        UpdateStartingPositions();
        doneMoving = isStarting || CheckComplete();
    }

    Boolean CheckComplete()
    {
        for (int i = 0; i < total; i++)
        {
            if (!originalArray[i].name.Equals(orderedArray[i].name))
            {
                return true;
            }
        }
        orderedArray[chosenIndex].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        chosenIndex = -1;
        return false;
    }

    void Update()
    {
        // If the exhibit is not active do not accept user input
        if (!exhibit.GetComponent<S_Exhibit>().getIsActive())
            return;
    }
}
