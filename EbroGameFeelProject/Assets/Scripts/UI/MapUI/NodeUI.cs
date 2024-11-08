using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Image nodeImage;
    public Color defaultColor = new Color(1, 1, 1, 0.5f);
    public Color highlightColor = Color.yellow;
    public bool isClickable = false;
    public List<NodeUI> connectedNodes; // List of nodes this node is connected to

    void Start()
    {
        nodeImage = GetComponent<Image>();
        SetUnavailable();
    }

    public void SetAvailable()
    {
        isClickable = true;
        nodeImage.color = highlightColor;
    }

    public void SetUnavailable()
    {
        isClickable = false;
        nodeImage.color = defaultColor;
    }

    public void OnClick()
    {
        if (isClickable)
        {
            Debug.Log("Node clicked!");
            MapUIManager.Instance.MoveToNode(this);
        }
    }
}
