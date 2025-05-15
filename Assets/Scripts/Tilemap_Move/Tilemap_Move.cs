using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Yukarý-aþaðý hareket
        transform.DOMoveY(transform.position.y + 4f, 1.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
