using UnityEngine;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    public static LineManager Instance;
    public LineRenderer linePrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        LineManager.Instance.DrawAllLines(MapUIManager.Instance.allNodes);
    }


    public void DrawLine(NodeUI nodeA, NodeUI nodeB)
    {
        LineRenderer line = Instantiate(linePrefab, transform);
        line.positionCount = 2;
        line.SetPosition(0, nodeA.transform.position);
        line.SetPosition(1, nodeB.transform.position);
    }

    public void DrawAllLines(List<NodeUI> nodes)
    {
        foreach (NodeUI node in nodes)
        {
            foreach (NodeUI connectedNode in node.connectedNodes)
            {
                DrawLine(node, connectedNode);
            }
        }
    }
}

