using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public TowerBtn ClickedBtn { get; private set; }

    private void Update()
    {
        HandleEscape();
    }

    public void PickTower(TowerBtn tower)
    {
        this.ClickedBtn = tower;
        Hover.Instance.Active(tower.Sprite.sprite);
    }

    public void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.ClickedBtn = null;
            Hover.Instance.Deactive();
        }
    }
}
