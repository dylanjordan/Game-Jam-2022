using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBuilder : MonoBehaviour
{
    List<GameObject> weapons = new List<GameObject>();
    public GameObject popupElement;
    public Button purchaseButton;
    GameObject currentWeapon;
    Transform spawnPosition;

    private void Awake()
    {
        purchaseButton.onClick.AddListener(Purchase);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        popupElement.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        popupElement.SetActive(false);
    }

    void Purchase()
    {
        Instantiate(currentWeapon, spawnPosition);
    }
}
