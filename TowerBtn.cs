using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private SpriteRenderer sprite;

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
