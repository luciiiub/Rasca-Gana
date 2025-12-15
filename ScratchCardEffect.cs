using UnityEngine;

public class ScratchCardEffect : MonoBehaviour
{
    public GameObject maskPrefab;
    public GameObject frontCard;
    [Range(0f, 1f)]
    public float threshold = 0.7f;

    public UIScratchCardManager scratchManager;   // ← NUEVO
    public CardRewardSystem cardReward;           // ← NUEVO
    
    private bool isPressed = false;
    private int totalMasks = 0;
    private int maxMasks = 500;
    private bool isRevealed = false;
    
    void Update()
    {
        if (isRevealed) return;

        var mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (isPressed) 
        {
            GameObject maskSprite = Instantiate(maskPrefab, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;
            totalMasks++;

            float scratchedPercentage = (float)totalMasks / maxMasks;

            if (scratchedPercentage >= threshold)
            {
                RevealCard();
            }
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            isPressed = false;
        }
    }
    
    void RevealCard()
    {
        isRevealed = true;
        Debug.Log("¡Carta revelada!");

        if (frontCard != null)
        {
            frontCard.SetActive(false);
        }

        // Obtener premio
        int valor = cardReward.GetRewardValue();
        Debug.Log("Premio recibido: $" + valor);

        // Avisar al manager
        if (scratchManager != null)
            scratchManager.OnCartaRevelada(valor);
        else
            Debug.LogError("❌ ScratchCardEffect NO tiene asignado un UIScratchCardManager.");
    }
}
