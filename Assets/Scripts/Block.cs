﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters
    [SerializeField] AudioClip destroyBlockSound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] int maxHits;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //TODO only serialised for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocksLeft();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestoryBlock();
        }
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
