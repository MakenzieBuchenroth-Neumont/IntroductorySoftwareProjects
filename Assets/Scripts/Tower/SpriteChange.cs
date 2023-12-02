using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray; // Assign sprites in the Inspector
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSpriteBasedOnAngle(float angle)
    {
        // Normalize the angle to be within the range [0, 360)
        angle = (angle + 360) % 360;

        // Assuming spriteArray is ordered from 0 degrees clockwise to 315 degrees (for 8 sprites)
        // and 0 degrees is facing right, adjust as necessary for your sprite orientations
        int spriteIndex = Mathf.RoundToInt(angle / 45f) % spriteArray.Length;
        Debug.Log(spriteIndex);
        spriteRenderer.sprite = spriteArray[spriteIndex];
    }

}
