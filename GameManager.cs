using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject towerPrefab;

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }
}
