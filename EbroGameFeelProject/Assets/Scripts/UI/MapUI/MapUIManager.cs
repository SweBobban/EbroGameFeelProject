using UnityEngine;
using System.Collections.Generic;

public class MapUIManager : MonoBehaviour
{
    public static MapUIManager Instance;
    public List<NodeUI> allNodes; // List of all nodes on the map
    public NodeUI startingNode;
    private NodeUI currentNode;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentNode = startingNode;
        currentNode.SetAvailable();
        HighlightAvailableNodes();
    }

    public void MoveToNode(NodeUI targetNode)
    {
        currentNode = targetNode;
        HighlightAvailableNodes();
    }

    void HighlightAvailableNodes()
    {
        foreach (NodeUI node in allNodes)
        {
            node.SetUnavailable();
        }

        currentNode.SetAvailable();
        foreach (NodeUI connectedNode in currentNode.connectedNodes)
        {
            connectedNode.SetAvailable();
        }
    }
}
