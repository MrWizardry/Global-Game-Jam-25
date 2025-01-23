using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpgradeCount : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;

    [SerializeField] private TextMeshProUGUI textLife;
    [SerializeField] private TextMeshProUGUI textArea;
    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = FindAnyObjectByType<UpgradeManager>().GetComponent<UpgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(upgradeManager == null) { upgradeManager = FindAnyObjectByType<UpgradeManager>().GetComponent<UpgradeManager>(); }
        textLife.SetText(upgradeManager.lifeUpCount.ToString());
        textArea.SetText(upgradeManager.areaUpCount.ToString());
    }
}
