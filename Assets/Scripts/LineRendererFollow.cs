using UnityEngine;

public class LineRendererFollow : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    [SerializeField] private Transform target;
    [SerializeField] private Transform startPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
}
