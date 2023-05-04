using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class ClothesData : MonoBehaviour
{
    [SerializeField] public int OutfitNum;
    [SerializeField] public bool orgBodyShow = false;
    [SerializeField] public bool orgTopShow = false;
    [SerializeField] public bool orgBottomShow = false;
    [SerializeField] public bool orgShoeShow = false;
    public bool grabReleased=false;
    
    [SerializeField] public GameObject _avatar;
    [SerializeField] private Transform _rootBone;
    [SerializeField] private Transform _orgRootBone;
    [SerializeField] private GameObject _orgBody;
    [SerializeField] private GameObject _orgTop;
    [SerializeField] private GameObject _orgBottom;
    [SerializeField] private GameObject _orgShoe;
    [SerializeField] private GameObject[] _objToShowWhenWorn;
    [SerializeField] private Transform _bodyCore;
    [SerializeField] private Vector3 _wornPos;
    [SerializeField] private Quaternion _wornRot;
    [SerializeField] private Transform _clothRack;
    [SerializeField] private GameObject _prefab;
    

    public bool outfitWorn=false;
    private bool _wornDone = false;
    private float _distToCore;
    private SkinnedMeshRenderer[] _skinnedMeshRenderers;
    private Transform _orgTransform;

    public void GrabReleased()
    {
        grabReleased = true;
        
    }
    void Start()
    {
        
        _orgTransform = transform;
        _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (var skin in _skinnedMeshRenderers)
        {
            skin.rootBone = _orgRootBone;
        }
        
        foreach (var obj in _objToShowWhenWorn)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        _distToCore = Vector3.Distance(_bodyCore.position, (transform.position+new Vector3(0,1.351f,0)));
        
        if(!outfitWorn&&_distToCore < 0.5f&& grabReleased)WearOutfit();
        else if(outfitWorn && _distToCore >= 0.5f&& grabReleased)TakeOffOutfit();
    }

    private void WearOutfit()
    {
        transform.position = _avatar.transform.position;
        transform.SetParent(_avatar.transform);
        transform.rotation = _wornRot;

        foreach (var skin in _skinnedMeshRenderers)
        {
            skin.rootBone = _rootBone;
        }
        _orgBody.SetActive(orgBodyShow);
        _orgTop.SetActive(orgTopShow);
        _orgBottom.SetActive(orgBottomShow);
        _orgShoe.SetActive(orgShoeShow);
        foreach (var obj in _objToShowWhenWorn)
        {
            obj.SetActive(true);
        }
        outfitWorn = true;
    }
    private void TakeOffOutfit()
    {
        // transform.SetParent(_clothRack);
        // Debug.Log(transform.parent.gameObject.name);
        outfitWorn = false;
        _orgBody.SetActive(true);
        _orgTop.SetActive(true);
        _orgBottom.SetActive(true);
        _orgShoe.SetActive(true);
        Instantiate(_prefab, _orgTransform.position,_orgTransform.rotation);
        Destroy(gameObject,0.5f);

        // foreach (var skin in _skinnedMeshRenderers)
        // {
        //     skin.rootBone = _orgRootBone;
        // }
        

    }
}
