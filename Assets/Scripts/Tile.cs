using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class Tile : MonoBehaviour
{
    [Header("Tile Sprites")]
    [SerializeField] private Sprite unclickedTile;
    [SerializeField] private Sprite flaggedTile;
    [SerializeField] private List<Sprite> clickedTiles;
    [SerializeField] private Sprite mineTile;
    [SerializeField] private Sprite mineWrongTile;
    [SerializeField] private Sprite mineHitTile;
    [SerializeField] private Sprite checkpoint;

    [Header("On Click")]
    private SpriteRenderer spriteRenderer;
    public bool flagged = false;
    public bool active = true;
    public bool isMine = false;
    public int mineCount = 0;

    [Header("Checkpoints")]
    public bool isCheckpoint = false;
    public GameObject flag;
    public GameObject player;
    public Lose loseHost;
    //public PlayerMovement playerMovement;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       // playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnMouseOver()
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                flagged = !flagged;

                if (flagged)
                {
                    spriteRenderer.sprite = flaggedTile;
                }
                else
                {
                    spriteRenderer.sprite = unclickedTile;
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (active)
        {
            active = false;
            WalkedTile();
        }
    }

    public void WalkedTile()
    {
        if (isCheckpoint)
        {
            spriteRenderer.sprite = checkpoint;
            Instantiate(flag, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), transform.rotation);
            //playerMovement.Checkpoint();
        }

        if (!flagged && !isCheckpoint)
        {
            if (isMine)
            {
                spriteRenderer.sprite = mineHitTile;
                loseHost.Death();
            }
            else
            {

                spriteRenderer.sprite = clickedTiles[mineCount];
            }
        }
    }
}
