using TMPro;
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private int price;
    [SerializeField] private TextMeshProUGUI textPrice;

    public int Price
    {
        get
        {
            return price;
        }

    }
    private void Start()
    {
        textPrice.text = price + "<color=green>$</color>";
    }

    public SpriteRenderer Sprite
    {
        get
        {
            return sprite;
        }
    }

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }
}
