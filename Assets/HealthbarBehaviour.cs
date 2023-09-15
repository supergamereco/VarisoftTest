using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
    //public GameObject
    public Color Low;
    public Color High;
    public Vector3 Offset;

    public void Awake()
    {

    }

    public void SetupHealthbar(int health, float maxHealth)
    {
        //Debug.Log("processed");
        //Debug.Log("health " + health + " maxHealth " + maxHealth);
        gameObject.SetActive(health < maxHealth);
        this.GetComponent<Slider>().value = health;
        this.GetComponent<Slider>().maxValue = maxHealth;

        //this.GetComponent<Slider>().fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, this.GetComponent<Slider>().normalizedValue);
    }
}
