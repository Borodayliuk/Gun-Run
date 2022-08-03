using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{

    [SerializeField] private Transform _startPortals;
    [SerializeField] private Transform _endPortals;
    [SerializeField] private GameObject _portalsPrefab;
    

    public List<Stage> allStages = new List<Stage>();

    private float _distance;
    private List<GameObject> _spawnedPortals = new List<GameObject>();
    private List<GameObject> _spawnedBlocks = new List<GameObject>();

    private void Awake()
    {
        _distance = Mathf.Abs(_startPortals.localPosition.z - _endPortals.localPosition.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];
        if (stage == null)
        {
            Debug.LogError("No stage " + stageNumber);
            return;
        }
        foreach (GameObject game in _spawnedBlocks)
        {
            Destroy(game);
        }
        foreach (GameObject game1 in _spawnedPortals)
        {
            Destroy (game1);
        }
        float distance = _distance / (stage.portals.Count - 1);
        float spawnPosZ = _startPortals.position.z;
        for (int i = 0; i < stage.portals.Count; i++)
        {
            GameObject portals = Instantiate(_portalsPrefab);
            portals.transform.position = new Vector3(0, 1, spawnPosZ);
            _spawnedPortals.Add(portals);
            GameObject portalL = portals.transform.GetChild(0).gameObject;
            GameObject portalR = portals.transform.GetChild(1).gameObject;

            if (stage.portals[i].isPoverL)
            {
                Destroy(portalL.GetComponent<Portal>());
                portalL.GetComponent<PortalPower>().power = stage.portals[i].countL;
            }
            else
            {
                Destroy(portalL.GetComponent<PortalPower>());
                portalL.GetComponent<Portal>().countBomb = stage.portals[i].countL;
                portalL.GetComponent<Portal>().angleShoot = stage.portals[i].angleL;
            }
            if (stage.portals[i].isPoverR)
            {
                Destroy(portalR.GetComponent<Portal>());
                portalR.GetComponent<PortalPower>().power = stage.portals[i].countR;
            }
            else
            {
                Destroy(portalR.GetComponent<PortalPower>());
                portalR.GetComponent<Portal>().countBomb = stage.portals[i].countR;
                portalR.GetComponent<Portal>().angleShoot = stage.portals[i].angleR;
            }


            spawnPosZ += distance;
        }
        float spawnPosZ2 = _startPortals.position.z + 2.5f;
        for (int i = 0; i < stage.blocks.Count; i++)
        {
            GameObject blocs = Instantiate(stage.blocks[i].groupBlocksPrefab);
            blocs.transform.position = new Vector3(0, 0.7f, spawnPosZ2);
            _spawnedBlocks.Add(blocs);

            
            for (int j = 0; j < blocs.transform.childCount; j++)
            {
                blocs.transform.GetChild(j).GetComponent<Block>().level = stage.blocks[i].levelBlock;
            }
            spawnPosZ2 += distance;
        }

    }
}
