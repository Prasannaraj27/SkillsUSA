using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    Image imageComponent;
    [SerializeField] Sprite[] healthSprites;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        imageComponent.sprite = healthSprites[FindObjectOfType<Player>().getHealth()];
    }
}
