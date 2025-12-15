using UnityEngine;

public class UIScratchCardManager : MonoBehaviour
{
    public GameObject panelScratchCard;
    public GameObject botonNuevaCarta;
    public ScratchCardEffect scratchCard;
    public CardRewardSystem cardReward;

    private bool cartaRevelada = false;

    private void Start()
    {
        panelScratchCard.SetActive(true);
        botonNuevaCarta.SetActive(false);
    }

    public void OnCartaRevelada(int valorGanado)
    {
        if (cartaRevelada) return;
        cartaRevelada = true;

        if (valorGanado > 0)
        {
            // GANASTE DINERO
            GameManager.Instance.GanarDinero(valorGanado);
            Debug.Log($"✔ ¡Has ganado ${valorGanado}!");
        }
        else
        {
            // ❌ NO GANASTE NADA → PIERDES CORDURA
            GameManager.Instance.cordura -= 10;  // ← Ajusta la cantidad que quieras
            if (GameManager.Instance.cordura < 0)
                GameManager.Instance.cordura = 0;

            Debug.Log("✘ No había premio. Has perdido 10 de cordura.");
        }

        // Refrescar UI del HUD
        GameManager.Instance.OnEstadisticasActualizadas?.Invoke();

        // Habilitar botón de nueva carta
        botonNuevaCarta.SetActive(true);
    }

    public void GenerarNuevaCarta()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
