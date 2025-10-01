using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;

public class AbilitySystem : MonoBehaviour
{
    [Header("Weights")]
    public float common;
    public float uncommon;
    public float rare;

    [SerializeField] GameObject player;
    private PlayerManager playerController;
    private PlayerController playerControllerManager;

    [SerializeField] private GameManager gameManager;
    GunHandler gunHandler;
    public List<AbilityesData> allAbilities;

    public Transform canvasList;

    private void Start()
    {
        playerController = player.GetComponent<PlayerManager>();
        playerControllerManager = player.GetComponent<PlayerController>();
        gunHandler = player.GetComponentInChildren<GunHandler>();
    }
    public void FillBoard()
    {

        List<string> abiNames = new List<string>();
        foreach (Transform child in canvasList)
        {
            var text = child.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            var img = child.GetComponent<UnityEngine.UI.Image>();
            var button = child.GetComponentInChildren<UnityEngine.UI.Button>();

            AbilityesData curr;


            while (true)
            {
                curr = PickOne();
                if (!abiNames.Contains(curr.abilityName))
                {
                    abiNames.Add(curr.abilityName);
                    break;
                }
            }
            text.text = curr.abilityName;
            if (curr.icon != null)
            {
                img.sprite = curr.icon;

            }

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                gameManager.OnChoise();
                ApplyAbility(curr);
            });
        }

    }

    private void ApplyAbility(AbilityesData curr)
    {
        switch (curr.powerKind)
        {
            case PowerKind.Life:
                if (curr.abilityName == "Double Life")
                {
                    playerController.maxHp *=(int)curr.stat;
                    playerController.currHp *=(int)curr.stat;
                }
                else
                {
                    playerController.maxHp+=(int)curr.stat;
                    playerController.currHp +=(int)curr.stat;

                }

                break;

            case PowerKind.Speed:
                if (curr.abilityName == "Double Speed")
                {
                    playerControllerManager.speed *=(int)curr.stat;
                }
                else
                {
                    playerControllerManager.speed +=(int)curr.stat;

                }
                break;

            case PowerKind.FireRate:
                if (curr.abilityName == "Double Fire Rate")
                {
                    gunHandler.rateOfFire*=curr.stat;
                }
                else
                {
                    gunHandler.rateOfFire+=curr.stat;
                }
                break;
            case PowerKind.Damage:
                if (curr.abilityName == "Double Damage")
                {
                    gunHandler.currentDamage*=(int)curr.stat;
                }
                else
                {
                    gunHandler.currentDamage+=(int)curr.stat;
                }
                break;

        }
    }

    public AbilityesData PickOne()
    {
        List<AbilityesData> currRolls = new List<AbilityesData>();
        Rarity rarity = RollRarity();
        foreach (AbilityesData abilitie in allAbilities)
        {
            if (abilitie.rarity == rarity)
            {
                currRolls.Add(abilitie);
            }
        }

        int roll = Random.Range(0, currRolls.Count);

        return currRolls[roll];
    }

    public Rarity RollRarity()
    {
        float c = Mathf.Max(0f, common);
        float u = Mathf.Max(0f, uncommon);
        float r = Mathf.Max(0f, rare);
        float total = c + u + r;

        if (total <= 0f) return Rarity.Common;

        float roll = Random.value *total;
        Debug.Log(roll);

        if (roll < c) return Rarity.Common;
        if (roll < c + u) return Rarity.Uncommon;
        return Rarity.Rare;
    }
}






