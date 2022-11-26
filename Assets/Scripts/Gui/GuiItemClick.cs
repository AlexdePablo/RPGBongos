using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuiItemClick : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Text;
    [SerializeField]
    private ClickEnemigo m_Event;

    public void Load(EnemyScriptable es)
    {
        m_Text.text = es.nom;
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => RaiseEvent(es));
    }

    private void RaiseEvent(EnemyScriptable es)
    {
        m_Event.Raise(es);

    }
}
