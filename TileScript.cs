using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }
    private SpriteRenderer spriteRenderer;
    public bool IsEmpty { get; private set; }
    public bool IsTower { get; private set; }

    private Color32 fullColor = new Color32(255, 118, 118, 255);
    private Color32 emptyColor = new Color32(96, 255, 90, 255);

    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x / 2, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2);
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        IsEmpty = true;
        IsTower = false;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
    }

    // kiểm tra chuột over, nếu ô trống render màu empty, nếu không trống render màu full,
    //nếu trống, click left mouse thì đặt tower
    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null)
        {
            if (IsEmpty)
            {
                ColorTile(emptyColor);

            }
            if (!IsEmpty)
            {
                ColorTile(fullColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }
    }
    private void OnMouseExit()
    {
        ColorTile(emptyColor);
    }

    private void PlaceTower()
    {
        //tạo tower
        GameObject tower = Instantiate(GameManager.Instance.ClickedBtn.TowerPrefab, WorldPosition, Quaternion.identity);
        //fix tower phía sau đè lên tower phía trước
        tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;
        //gán parent là tile
        tower.transform.SetParent(transform);
        IsEmpty = false;
        IsTower = true;
        ColorTile(emptyColor);
        //trigger buy tower ở game manager
        GameManager.Instance.BuyTower();
    }

    private void ColorTile(Color32 newColor)
    {
        spriteRenderer.color = newColor;
    }
}
