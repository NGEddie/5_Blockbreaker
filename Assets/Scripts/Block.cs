using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroyBlockSound;
    [SerializeField] GameObject blockVFX;

    Level level;
    

    private void Start()
    {
        level = FindObjectOfType <Level>();
        level.CountBlocksLeft();
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestoryBlock();
    }

    private void DestoryBlock()
    {
        PlayBlockDestroySFX();
        TriggerBlockVFX();
        Destroy(gameObject);
        level.RemoveBlock();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().UpdateCurrentScore();
        AudioSource.PlayClipAtPoint(destroyBlockSound, Camera.main.transform.position);
    }

    private void TriggerBlockVFX()
    {
        GameObject sparkles = Instantiate(blockVFX,transform.position, transform.rotation);
        Destroy(sparkles, 1f);

    }
}
