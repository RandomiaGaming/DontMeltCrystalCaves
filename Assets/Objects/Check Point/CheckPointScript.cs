using UnityEngine;
public enum FacingDirection { Right, Left };
public class CheckPointScript : MonoBehaviour
{
    public Sprite Locked = null;
    public Sprite Unlocked = null;
    public FacingDirection RespawnDirection = FacingDirection.Right;

    private SpriteRenderer _spriteRenderer = null;
    private PlayerScript _playerScript = null;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    private void Update()
    {
        if (true)
        {
            _spriteRenderer.sprite = Unlocked;
        }
        else
        {
            _spriteRenderer.sprite = Locked;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            /*_playerScript.CheckPoint = data;*/
            SaveDataHelper.Save();
        }
    }

}
