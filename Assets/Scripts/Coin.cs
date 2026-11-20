using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public UnityEvent onPickup;

    public static EventHandler onTestCoin;
    
    private CircleCollider2D circleColl;

    private void Start()
    {
        circleColl = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onPickup?.Invoke();

            onTestCoin?.Invoke(this, EventArgs.Empty);
            
            circleColl.enabled = false;
            Destroy(gameObject, 1f);

        }
    }
}
