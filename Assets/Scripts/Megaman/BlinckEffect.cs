using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinckEffect : MonoBehaviour
{
    public static bool isCharge=false;
    public SpriteRenderer playerSpriteRenderer;
    public Material playerMaterial;
    public Material blinkMaterial;
    public static bool isChargeLevelUp = true;
    public Material blinkLevelUpMaterial;
    private void Update()
    {
        if (isCharge)
        {
            StartCoroutine("Charge");
        }
    }

    private IEnumerator Charge()
    {
        if (!isChargeLevelUp)
        {
            playerSpriteRenderer.material = blinkMaterial;
        }
        else
        {
            playerSpriteRenderer.material = blinkLevelUpMaterial;
        }
        yield return new WaitForSeconds(1f);
        playerSpriteRenderer.material = playerMaterial;
    }
}
