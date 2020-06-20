using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityInjector.Attributes;

// todo dance時のmaidのtransformを習得できるか確かめてみる
// このプラグインはsceneがダンスのときのみ有効とする
namespace COM3D2.VRDanceTracker.Plugin
{
    [PluginFilter("COM3D2x64")]
    [PluginFilter("COM3D2VRx64")]
    [PluginName("COM3D2.VRDanceTracker.Plugin")]
    [PluginVersion("1.0.0.0")]

    public class VRDanceTracker : UnityInjector.PluginBase
    {
        private bool IsDanceSelected = false;
        private bool IsDanceStarted = false;
        private Maid targetmaid = new Maid();

        public void TargetMaidSelect()
        // 追従対象のメイドを選択する
        {

        }

        public void TargetMaidTracker()
        // メイドに合わせてVRHMDの座標を調整する
        {

        }

        public void GetMaidTransform()
        // 対象のメイドの番号とTransformを取得する
        {

        }

        public void VRDanceTrackerMain(int maid_num)
        // このプラグインのmainとする
        // 引数は対象Maidの番号
        {
            if(IsDanceStarted)
            {
                // targetmaid = GameMain.Instance.CharacterMgr.GetMaid(maid_num);
                // UnityEngine.Debug.Log(targetmaid.GetPos());
                // UnityEngine.Debug.Log(GameMain.Instance.CharacterMgr.GetMaidCount());
                // UnityEngine.Debug.Log(targetmaid.transform.position);
                var maidlist = GameMain.Instance.CharacterMgr.GetStockMaidList();
                foreach(Maid maidobject in maidlist)
                {
                    if(maidobject.ActiveSlotNo != -1)
                    {
                        // GetMaidはActiveなMaidを取得する
                        Vector3 vec = new Vector3(0.0f, 1.0f, 0.0f);
                        // targetmaid = maidobject;
                        // targetmaid = GameMain.Instance.CharacterMgr.GetMaid(0);
                        targetmaid = maidobject;
                        // targetmaid.transform.Translate(transform.up * 10);
                        // UnityEngine.Debug.Log(GameMain.Instance.CharacterMgr.GetCharaAllPos());
                        // UnityEngine.Debug.Log(GameMain.Instance.CharacterMgr.GetCharaAllOfsetPos());
                        // UnityEngine.Debug.Log(GameMain.Instance.MainCamera.transform.position);
                        // GameMain.Instance.CharacterMgr.GetMaid(0).transform.Translate(transform.up * 10 + transform.right * 10f);
                        // GameMain.Instance.CharacterMgr.GetMaid(0).UpdateTransformData();
                        // targetmaid.transform.Translate(transform.up * 0.01f + transform.right * 0.01f);
                        UnityEngine.Debug.Log(targetmaid.m_goOffset.transform.localPosition);
                        UnityEngine.Debug.Log(GameMain.Instance.CharacterMgr.GetMaid(0).m_goOffset.transform.localPosition);

                        
                        
                    }
                }
            }
        }

        public void OnSceneLoaded(Scene scenename, LoadSceneMode scenemode)
        // sceneが"SceneDanceSelect"から"SceneADV"になるということがダンスシーンの開始と考えられる
        {
            
            if(GameMain.Instance.GetNowSceneName() == "SceneADV" && IsDanceSelected)
            // sceneがdanceであることを確認
            {
                IsDanceStarted = true;
                IsDanceSelected = false;
                UnityEngine.Debug.Log("1");
                UnityEngine.Debug.Log(GameMain.Instance.CharacterMgr.GetStockMaidList());
                var maidlist = GameMain.Instance.CharacterMgr.GetStockMaidList();
                // Maid.ActiveSlotNo が -1 であるならばそのメイドはアクティブではない
                foreach(Maid maidobject in maidlist)
                {
                    if (maidobject.ActiveSlotNo != -1)
                    {

                        UnityEngine.Debug.Log(maidobject);
                        UnityEngine.Debug.Log(maidobject.ActiveSlotNo);
                        targetmaid = maidobject;
                        
                    }
                }
            }

            else if(GameMain.Instance.GetNowSceneName() == "SceneDanceSelect")
            // sceneがdanceselectであることを確認
            {
                IsDanceSelected = true;
                UnityEngine.Debug.Log("2");
            }

            else if(GameMain.Instance.GetNowSceneName() == "SceneADV" && IsDanceStarted)
            {
                IsDanceStarted = false;
                UnityEngine.Debug.Log("3");
            }
        }

        public void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Update()
        {
            // VRDanceTrackerMain(0);
            targetmaid = GameMain.Instance.CharacterMgr.GetMaid(0);
            // targetmaid.UpdateTransformData();
            // UnityEngine.Debug.Log(targetmaid.transform.position.ToString("F4"));
            // UnityEngine.Debug.Log(targetmaid.m_goOffset.transform.localPosition.ToString("F5"));
            UnityEngine.Debug.Log(targetmaid.motionOffset);
            UnityEngine.Debug.Log(targetmaid.baseOffset);
        }
    }
}
