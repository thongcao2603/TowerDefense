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
            //gán text khi set value cho currency
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
        //Debug.Log(Currency);
    }

    public void PickTower(TowerBtn tower)
    {
        if (Currency >= tower.Price)
        {
            this.ClickedBtn = tower;
            //kích hoạt hover với render sprite là sprite của tower đã click
            Hover.Instance.Active(tower.Sprite.sprite);
        }
    }

    public void BuyTower()
    {
        if (Currency >= this.ClickedBtn.Price)
        {
            Currency -= ClickedBtn.Price;
            //deactive hover, tắt render sprite 
            Hover.Instance.Deactive();

        }
    }

    // nhấn esc deactive hover.
    public void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactive();
        }
    }
}
