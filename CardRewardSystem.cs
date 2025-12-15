using UnityEngine;

public class CardRewardSystem : MonoBehaviour
{
    public RewardData[] rewards;
    
    private SpriteRenderer spriteRenderer;
    private RewardData selectedReward;
    private Vector3 originalScale;
    private Sprite originalSprite;
    private Vector2 originalSpriteSize;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        originalSprite = spriteRenderer.sprite;
        originalScale = transform.localScale;
        originalSpriteSize = spriteRenderer.bounds.size;
        
        selectedReward = SelectRandomReward();
        
        if (spriteRenderer != null && selectedReward != null)
        {
            spriteRenderer.sprite = selectedReward.sprite;
            AdjustToOriginalSize();
        }
        
        Debug.Log("Premio seleccionado: $" + selectedReward.value);
    }
    
    void AdjustToOriginalSize()
    {
        Vector2 newSpriteSize = spriteRenderer.bounds.size;
        
        float scaleX = (originalSpriteSize.x / newSpriteSize.x) * originalScale.x;
        float scaleY = (originalSpriteSize.y / newSpriteSize.y) * originalScale.y;
        
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    
    RewardData SelectRandomReward()
    {
        float totalProbability = 0f;
        foreach (RewardData reward in rewards)
        {
            totalProbability += reward.probability;
        }
        
        float randomValue = Random.Range(0f, totalProbability);
        
        float cumulativeProbability = 0f;
        foreach (RewardData reward in rewards)
        {
            cumulativeProbability += reward.probability;
            if (randomValue <= cumulativeProbability)
            {
                return reward;
            }
        }
        
        return rewards[0];
    }
    
    public int GetRewardValue()
    {
        return selectedReward != null ? selectedReward.value : 0;
    }
}
