using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScrolling : MonoBehaviour
{
    [Header("Все карточки миров")]
    public List<GameObject> allWorlds;
    private List<GameObject> worldsWithoutCurr;

    [Header("Порядковый номер текущего мира (от 0)")]
    [Range(0, 25)] public int indexOfCurrentWorld;

    [Range(0f, 20f)] public float snapSpeed;

    private Vector2[] worldsPos;
    private GameObject[] worlds;
  
    private RectTransform contentRect;
    private Vector2 contentVector;

    private int selectedWorldID;
    private bool isScrolling;

    private void Start()
    {
        allWorlds.Remove(allWorlds[indexOfCurrentWorld]);
        contentRect = GetComponent<RectTransform>();
        worldsWithoutCurr = allWorlds;
        worlds = new GameObject[worldsWithoutCurr.Count];
        worldsPos = new Vector2[worldsWithoutCurr.Count];

        for (int i = 0; i < worldsWithoutCurr.Count; i++)
        {
            worlds[i] = worldsWithoutCurr[i];
            if (i == 0) continue;
            worlds[i].transform.localPosition = new Vector2(worlds[i - 1].transform.localPosition.x +
                worldsWithoutCurr[i].GetComponent<RectTransform>().sizeDelta.x, worlds[i].transform.localPosition.y);
            worldsPos[i] = -worlds[i].transform.localPosition;
            
        }
    }

    private void FixedUpdate()
    {
        float nearestPos = float.MaxValue;  

       for (int i = 0; i < worldsWithoutCurr.Count; i++)
       {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - worldsPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedWorldID = i;
            }
       }
        if (isScrolling) return;
        contentVector.x = Mathf.SmoothDamp(contentRect.anchoredPosition.x, worldsPos[selectedWorldID].x, ref snapSpeed, 1f);
        contentRect.anchoredPosition = contentVector;

    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }
}
