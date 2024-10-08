using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public TowerBtn ClickedBtn { get; private set; }

    public void PickTower(TowerBtn tower)
    {
        this.ClickedBtn = tower;
        Hover.Instance.Active(tower.Sprite.sprite);
    }
}
