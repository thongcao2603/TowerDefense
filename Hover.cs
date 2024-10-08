using UnityEngine;

public class Hover : Singleton<Hover>
{

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Active(Sprite _sprite)
    {
        this.spriteRenderer.sprite = _sprite;
        this.spriteRenderer.enabled = true;
    }

    public void Deactive()
    {
        this.spriteRenderer.enabled = false;
        GameManager.Instance.ClickedBtn = null;
    }


}
