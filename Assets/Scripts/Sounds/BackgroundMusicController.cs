using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundController.instance.PlayThisSoundOneShot("Monkey Warhol - Boots & Pants (Sidekick Wave Instrumental Remix)", .05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
