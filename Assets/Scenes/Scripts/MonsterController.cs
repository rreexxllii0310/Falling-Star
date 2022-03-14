using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 4f;
    int currentSprite = 0, delay = 0;
    public GameObject monster;
    public Sprite[] monsterSprite;
    public SpriteRenderer monsterSpriteRenderer;
    Vector3 originPosition,nowPosition;
    void Start()
    {
        monsterSprite = Resources.LoadAll<Sprite>("");
        monsterSpriteRenderer = monster.GetComponent<SpriteRenderer>();
        monsterSpriteRenderer.sprite = monsterSprite[currentSprite];
        originPosition = monster.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        delay++;
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        nowPosition = monster.GetComponent<Transform>().position;
        if (nowPosition.x < -10)
        {
            monster.transform.position = originPosition;
        }
        if (delay > 30)
        {
            if (currentSprite < 3)
            {
                currentSprite++;
                monsterSpriteRenderer.sprite = monsterSprite[currentSprite];
            }
            else
            {
                currentSprite = 0;
                monsterSpriteRenderer.sprite = monsterSprite[currentSprite];
            }
            delay = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            monster.transform.position = originPosition;
            currentSprite = 0;
            monsterSpriteRenderer.sprite = monsterSprite[currentSprite];
        }

    }
}
