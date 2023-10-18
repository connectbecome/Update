using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public static BattleUI Instance;

    public Transform LTPanelTr;
    public GameObject LTPanel;

    private ArmyView armyView;
    private TerrainView terrainView;

    public void Awake()
    {
        Instance = this;
        transform.Find("LeftTop").position = new Vector3(Screen.safeArea.xMin, Screen.safeArea.yMax);
        armyView = LTPanelTr.Find("ArmyView").GetComponent<ArmyView>();
        terrainView = LTPanelTr.Find("TerrainView").GetComponent<TerrainView>();
    }

    private void Start()
    {
        BattleManager.Instance.RegisterUIEventHandler(OnUIEvent);
        LTPanel.SetActive(false);
    }

    private void SetArmyViewActive(bool on)
    {
        armyView.gameObject.SetActive(on);
    }

    private ValueTuple<int, int> lastClick = (-666, -100866);

    private void OnUIEvent(UIEvent uiEvent)
    {
        switch (uiEvent.Type)
        {
            case UIEventType.Click:
                var (i, j) = (ValueTuple<int, int>)uiEvent.Param;
                if (lastClick == (i, j))
                {
                    LTPanel.SetActive(false);
                    lastClick = (-9879, -524389);
                    break;
                }
                LTPanel.SetActive(true);
                lastClick = (i, j);
                GameObject terrainGO = BattleManager.Instance.TerrainGOs[i, j];
                GameObject objectGO = BattleManager.Instance.ObjectGOs[i, j];
                GameObject unitGO = BattleManager.Instance.UnitGOs[i, j];

                Sprite terrainSprite = null;
                if (terrainGO != null)
                {
                    terrainSprite = terrainGO.GetComponent<SpriteRenderer>().sprite;
                }

                terrainView.SetTerrainImage(terrainSprite);


                Sprite objectSprite = null;
                if (objectGO != null)
                {
                    objectSprite = objectGO.GetComponent<SpriteRenderer>().sprite;
                }

                terrainView.SetObjectImage(objectSprite);

                if (unitGO != null)
                {
                    SetArmyViewActive(true);
                    UnitTile unitTile = unitGO.GetComponent<UnitTile>();
                    UnitProperty prop = unitTile.CurrentProperty;
                    var unitSprite = unitGO.GetComponent<SpriteRenderer>().sprite;
                    armyView.Refresh(unitSprite, prop.name, prop.team.ToString(), prop.hp.ToString(),
                        prop.atk.ToString(), "--", prop.mp.ToString());
                }
                else
                {
                    SetArmyViewActive(false);
                }

                break;

            default:
                break;
        }
    }
}