using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{

    [SerializeField] private UnityEvent onTriggerEnter, onTriggerExit;
    [SerializeField] private string TagToActivate;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagToActivate))
        {
            onTriggerEnter.Invoke();
            Debug.Log($"{other.name} triggered enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagToActivate))
        {
            onTriggerExit.Invoke();
            Debug.Log($"{other.name} triggered exit");
        }
    }
}