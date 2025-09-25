using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI healthText;
    private GameObject player;
    private PlayerManager playerManager;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerManager = player.GetComponent<PlayerManager>();
            healthText.text = playerManager.currHp.ToString() + " " + playerManager.maxHp.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            healthText.text = playerManager.currHp.ToString() + " / " + playerManager.maxHp.ToString();
            slider.value = playerManager.currHp;
            slider.maxValue = playerManager.maxHp;
        }
    }
}
