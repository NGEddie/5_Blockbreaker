using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroyBlockSound;

    Level level;
    

    private void Start()
    {
        level = FindObjectOfType <Level>();
        level.CountBlocksLeft();
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().updateCurrentScore();
        AudioSource.PlayClipAtPoint(destroyBlockSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.RemoveBlock();
    }

}
