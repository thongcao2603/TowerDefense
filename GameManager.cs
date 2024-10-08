using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public TowerBtn ClickedBtn { get; set; }

    private int currency;

    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            this.currency = value;
            this.currencyText.text = value.ToString() + "<color=green>$</color>";
        }
    }

    [SerializeField] private TextMeshProUGUI currencyText;

    private void Start()
    {
        Currency = 5;
    }

    private void Update()
    {
        HandleEscape();
        Debug.Log(Currency);
    }

    public void PickTower(TowerBtn tower)
    {
        if (Currency >= tower.Price)
        {
            this.ClickedBtn = tower;
            Hover.Instance.Active(tower.Sprite.sprite);
        }
    }

    public void BuyTower()
    {
        if (Currency >= this.ClickedBtn.Price)
        {
            Currency -= ClickedBtn.Price;
            Hover.Instance.Deactive();

        }
    }

    public void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactive();
        }
    }
}
