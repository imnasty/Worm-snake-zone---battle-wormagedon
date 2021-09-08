using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class WebDavSTA : MonoBehaviour
{
    // public GameObject lean;
    public static WebDavSTA instance;
    public WebDAVClient.Client webDAVClient;
    public string Название_игры;
    bool folderscreen = false;
    bool folderscreename = false;
    public int loaddd = 0;
    public int starts = 0;
    FileStream file;
    public float delay=15f;
    public GameObject PanelLoading;
    private void Awake() {
        instance=this;
    }
    private void Start() {
        instance=this;
    }
    public IEnumerator UploadScreen()
    {
        PanelLoading.SetActive(true);
        delay=PlayerPrefs.GetFloat("Delay",15f);
        Debug.LogError("началась заливка");
        yield return new WaitForSecondsRealtime(0);
        if(starts==1){
        if (UnityEngine.Application.platform == RuntimePlatform.WindowsPlayer)
        {
                if (loaddd == 1)
                {
                    string[] allfiles = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/en/1080x1920/");
                    foreach (string filename in allfiles)
                    {
                        Debug.LogError("Загрузка 1 скрина");
                        string pathhh = (Application.dataPath.ToString() + "/screenshots/en/1080x1920/");
                        string fileee = filename.Replace(pathhh, " ");
                        Debug.Log(fileee);
                        Debug.Log(filename);
                        var file = File.Open(filename, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/1080x1920/", file, fileee);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    Debug.LogError("форич");
                    loaddd++;
                }
                Debug.LogError(loaddd);
                Debug.LogError(PlayerPrefs.GetInt("loadingscreen").ToString());
                if (loaddd == 2 && PlayerPrefs.GetInt("loadingscreen") == 1)
                {
                    Debug.LogError("Загрузка 2 скрина");
                    string[] allfiles2 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/en/1600x2560/");
                    foreach (string filename2 in allfiles2)
                    {

                        string pathhh2 = (Application.dataPath.ToString() + "/screenshots/en/1600x2560/");
                        string fileee2 = filename2.Replace(pathhh2, " ");
                        Debug.LogError(fileee2);
                        Debug.LogError(filename2);
                        var file2 = File.Open(filename2, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/1600x2560/", file2, fileee2);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 3 && PlayerPrefs.GetInt("loadingscreen") == 2)
                {
                    Debug.LogError("Загрузка 3 скрина");
                    string[] allfiles3 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/en/1242x2208/");
                    foreach (string filename3 in allfiles3)
                    {

                        string pathhh3 = (Application.dataPath.ToString() + "/screenshots/en/1242x2208/");
                        string fileee3 = filename3.Replace(pathhh3, " ");
                        Debug.LogError(fileee3);
                        Debug.LogError(filename3);
                        var file3 = File.Open(filename3, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/1242x2208/", file3, fileee3);

                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 4 && PlayerPrefs.GetInt("loadingscreen") == 3)
                {
                    Debug.LogError("Загрузка 4 скрина");
                    string[] allfiles4 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/en/2048x2732/");
                    foreach (string filename4 in allfiles4)
                    {

                        string pathhh4 = (Application.dataPath.ToString() + "/screenshots/en/2048x2732/");
                        string fileee4 = filename4.Replace(pathhh4, " ");
                        Debug.LogError(fileee4);
                        Debug.LogError(filename4);
                        var file4 = File.Open(filename4, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/2048x2732/", file4, fileee4);

                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 5 && PlayerPrefs.GetInt("loadingscreen") == 4)
                {
                    Debug.LogError("Загрузка 5 скрина");
                    string[] allfiles5 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ru/1080x1920/");
                    foreach (string filename5 in allfiles5)
                    {

                        string pathhh5 = (Application.dataPath.ToString() + "/screenshots/ru/1080x1920/");
                        string fileee5 = filename5.Replace(pathhh5, " ");
                        Debug.Log(fileee5);
                        Debug.Log(filename5);
                        var file5 = File.Open(filename5, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1080x1920/", file5, fileee5);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 6 && PlayerPrefs.GetInt("loadingscreen") == 5)
                {
                    Debug.LogError("Загрузка 6 скрина");
                    string[] allfiles6 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ru/1600x2560/");
                    foreach (string filename6 in allfiles6)
                    {

                        string pathhh6 = (Application.dataPath.ToString() + "/screenshots/ru/1600x2560/");
                        string fileee6 = filename6.Replace(pathhh6, " ");
                        Debug.LogError(fileee6);
                        Debug.LogError(filename6);
                        var file6 = File.Open(filename6, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1600x2560/", file6, fileee6);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 7 && PlayerPrefs.GetInt("loadingscreen") == 6)
                {
                    Debug.LogError("Загрузка 7 скрина");
                    string[] allfiles7 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ru/1242x2208/");
                    foreach (string filename7 in allfiles7)
                    {

                        string pathhh7 = (Application.dataPath.ToString() + "/screenshots/ru/1242x2208/");
                        string fileee7 = filename7.Replace(pathhh7, " ");
                        Debug.LogError(fileee7);
                        Debug.LogError(filename7);
                        var file7 = File.Open(filename7, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1242x2208/", file7, fileee7);

                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 8 && PlayerPrefs.GetInt("loadingscreen") == 7)
                {
                    Debug.LogError("Загрузка 8 скрина");
                    string[] allfiles8 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ru/2048x2732/");
                    foreach (string filename8 in allfiles8)
                    {

                        string pathhh8 = (Application.dataPath.ToString() + "/screenshots/ru/2048x2732/");
                        string fileee8 = filename8.Replace(pathhh8, " ");
                        Debug.LogError(fileee8);
                        Debug.LogError(filename8);
                        var file8 = File.Open(filename8, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/2048x2732/", file8, fileee8);
                        
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 9 && PlayerPrefs.GetInt("loadingscreen") == 8)
                {
                    string[] allfiles9 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/cn/1080x1920/");
                    foreach (string filename9 in allfiles9)
                    {
                        Debug.LogError("Загрузка 9 скрина");
                        string pathhh9 = (Application.dataPath.ToString() + "/screenshots/cn/1080x1920/");
                        string fileee9 = filename9.Replace(pathhh9, " ");
                        Debug.Log(fileee9);
                        Debug.Log(filename9);
                        var file9 = File.Open(filename9, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/1080x1920/", file9, fileee9);
                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 10 && PlayerPrefs.GetInt("loadingscreen") == 9)
                {
                    Debug.LogError("Загрузка 10 скрина");
                    string[] allfiles10 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/cn/1600x2560/");
                    foreach (string filename10 in allfiles10)
                    {

                        string pathhh10 = (Application.dataPath.ToString() + "/screenshots/cn/1600x2560/");
                        string fileee10 = filename10.Replace(pathhh10, " ");
                        Debug.LogError(fileee10);
                        Debug.LogError(filename10);
                        var file10 = File.Open(filename10, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/1600x2560/", file10, fileee10);
                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 11 && PlayerPrefs.GetInt("loadingscreen") == 10)
                {
                    Debug.LogError("Загрузка 11 скрина");
                    string[] allfiles11 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/cn/1242x2208/");
                    foreach (string filename11 in allfiles11)
                    {

                        string pathhh11 = (Application.dataPath.ToString() + "/screenshots/cn/1242x2208/");
                        string fileee11 = filename11.Replace(pathhh11, " ");
                        Debug.LogError(fileee11);
                        Debug.LogError(filename11);
                        var file11 = File.Open(filename11, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/1242x2208/", file11, fileee11);

                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 12 && PlayerPrefs.GetInt("loadingscreen") == 11)
                {
                    Debug.LogError("Загрузка 12 скрина");
                    string[] allfiles12 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/cn/2048x2732/");
                    foreach (string filename12 in allfiles12)
                    {

                        string pathhh12 = (Application.dataPath.ToString() + "/screenshots/cn/2048x2732/");
                        string fileee12 = filename12.Replace(pathhh12, " ");
                        Debug.LogError(fileee12);
                        Debug.LogError(filename12);
                        var file12 = File.Open(filename12, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/2048x2732/", file12, fileee12);

                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 13 && PlayerPrefs.GetInt("loadingscreen") == 12)
                {
                    Debug.LogError("Загрузка 13 скрина");
                    string[] allfiles13 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/sp/1080x1920/");
                    foreach (string filename13 in allfiles13)
                    {

                        string pathhh13 = (Application.dataPath.ToString() + "/screenshots/sp/1080x1920/");
                        string fileee13 = filename13.Replace(pathhh13, " ");
                        Debug.Log(fileee13);
                        Debug.Log(filename13);
                        var file13 = File.Open(filename13, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/1080x1920/", file13, fileee13);
                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 14 && PlayerPrefs.GetInt("loadingscreen") == 13)
                {
                    Debug.LogError("Загрузка 14 скрина");
                    string[] allfiles14 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/sp/1600x2560/");
                    foreach (string filename14 in allfiles14)
                    {

                        string pathhh14 = (Application.dataPath.ToString() + "/screenshots/sp/1600x2560/");
                        string fileee14 = filename14.Replace(pathhh14, " ");
                        Debug.LogError(fileee14);
                        Debug.LogError(filename14);
                        var file14 = File.Open(filename14, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/1600x2560/", file14, fileee14);
                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 15 && PlayerPrefs.GetInt("loadingscreen") == 14)
                {
                    Debug.LogError("Загрузка 15 скрина");
                    string[] allfiles15 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/sp/1242x2208/");
                    foreach (string filename15 in allfiles15)
                    {

                        string pathhh15 = (Application.dataPath.ToString() + "/screenshots/sp/1242x2208/");
                        string fileee15 = filename15.Replace(pathhh15, " ");
                        Debug.LogError(fileee15);
                        Debug.LogError(filename15);
                        var file15 = File.Open(filename15, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/1242x2208/", file15, fileee15);

                    }
                     yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 16 && PlayerPrefs.GetInt("loadingscreen") == 15)
                {
                    Debug.LogError("Загрузка 16 скрина");
                    string[] allfiles16 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/sp/2048x2732/");
                    foreach (string filename16 in allfiles16)
                    {

                        string pathhh16 = (Application.dataPath.ToString() + "/screenshots/sp/2048x2732/");
                        string fileee16 = filename16.Replace(pathhh16, " ");
                        Debug.LogError(fileee16);
                        Debug.LogError(filename16);
                        var file16 = File.Open(filename16, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/2048x2732/", file16, fileee16);
                        
                    }
                     yield return new WaitForSecondsRealtime(delay);
                     loaddd++;
                }
                if (loaddd == 17 && PlayerPrefs.GetInt("loadingscreen") == 16)
                {
                    string[] allfiles17 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/jp/1080x1920/");
                    foreach (string filename17 in allfiles17)
                    {
                        Debug.LogError("Загрузка 17 скрина");
                        string pathhh17 = (Application.dataPath.ToString() + "/screenshots/jp/1080x1920/");
                        string fileee17 = filename17.Replace(pathhh17, " ");
                        Debug.Log(fileee17);
                        Debug.Log(filename17);
                        var file17 = File.Open(filename17, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/1080x1920/", file17, fileee17);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 18 && PlayerPrefs.GetInt("loadingscreen") == 17)
                {
                    Debug.LogError("Загрузка 18 скрина");
                    string[] allfiles18 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/jp/1600x2560/");
                    foreach (string filename18 in allfiles18)
                    {

                        string pathhh18 = (Application.dataPath.ToString() + "/screenshots/jp/1600x2560/");
                        string fileee18 = filename18.Replace(pathhh18, " ");
                        Debug.LogError(fileee18);
                        Debug.LogError(filename18);
                        var file18 = File.Open(filename18, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/1600x2560/", file18, fileee18);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 19 && PlayerPrefs.GetInt("loadingscreen") == 18)
                {
                    Debug.LogError("Загрузка 19 скрина");
                    string[] allfiles19 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/jp/1242x2208/");
                    foreach (string filename19 in allfiles19)
                    {

                        string pathhh19 = (Application.dataPath.ToString() + "/screenshots/jp/1242x2208/");
                        string fileee19 = filename19.Replace(pathhh19, " ");
                        Debug.LogError(fileee19);
                        Debug.LogError(filename19);
                        var file19 = File.Open(filename19, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/1242x2208/", file19, fileee19);

                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 20 && PlayerPrefs.GetInt("loadingscreen") == 19)
                {
                    Debug.LogError("Загрузка 20 скрина");
                    string[] allfiles20 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/jp/2048x2732/");
                    foreach (string filename20 in allfiles20)
                    {

                        string pathhh20 = (Application.dataPath.ToString() + "/screenshots/jp/2048x2732/");
                        string fileee20 = filename20.Replace(pathhh20, " ");
                        Debug.LogError(fileee20);
                        Debug.LogError(filename20);
                        var file20 = File.Open(filename20, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/2048x2732/", file20, fileee20);

                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 21 && PlayerPrefs.GetInt("loadingscreen") == 20)
                {
                    Debug.LogError("Загрузка 21 скрина");
                    string[] allfiles21 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/pt/1080x1920/");
                    foreach (string filename21 in allfiles21)
                    {

                        string pathhh21 = (Application.dataPath.ToString() + "/screenshots/pt/1080x1920/");
                        string fileee21 = filename21.Replace(pathhh21, " ");
                        Debug.Log(fileee21);
                        Debug.Log(filename21);
                        var file21 = File.Open(filename21, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/1080x1920/", file21, fileee21);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 22 && PlayerPrefs.GetInt("loadingscreen") == 21)
                {
                    Debug.LogError("Загрузка 22 скрина");
                    string[] allfiles22 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/pt/1600x2560/");
                    foreach (string filename22 in allfiles22)
                    {

                        string pathhh22 = (Application.dataPath.ToString() + "/screenshots/pt/1600x2560/");
                        string fileee22 = filename22.Replace(pathhh22, " ");
                        Debug.LogError(fileee22);
                        Debug.LogError(filename22);
                        var file22 = File.Open(filename22, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/1600x2560/", file22, fileee22);
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 23 && PlayerPrefs.GetInt("loadingscreen") == 22)
                {
                    Debug.LogError("Загрузка 23 скрина");
                    string[] allfiles23 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/pt/1242x2208/");
                    foreach (string filename23 in allfiles23)
                    {

                        string pathhh23 = (Application.dataPath.ToString() + "/screenshots/pt/1242x2208/");
                        string fileee23 = filename23.Replace(pathhh23, " ");
                        Debug.LogError(fileee23);
                        Debug.LogError(filename23);
                        var file23 = File.Open(filename23, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/1242x2208/", file23, fileee23);

                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 24 && PlayerPrefs.GetInt("loadingscreen") == 23)
                {
                    Debug.LogError("Загрузка 24 скрина");
                    string[] allfiles24 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/pt/2048x2732/");
                    foreach (string filename24 in allfiles24)
                    {

                        string pathhh24 = (Application.dataPath.ToString() + "/screenshots/pt/2048x2732/");
                        string fileee24 = filename24.Replace(pathhh24, " ");
                        Debug.LogError(fileee24);
                        Debug.LogError(filename24);
                        var file24 = File.Open(filename24, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/2048x2732/", file24, fileee24);
                        
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 25 && PlayerPrefs.GetInt("loadingscreen") == 24)
                {
                    Debug.LogError("Загрузка 25 скрина");
                    string[] allfiles25 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ar/1080x1920/");
                    foreach (string filename25 in allfiles25)
                    {

                        string pathhh25 = (Application.dataPath.ToString() + "/screenshots/ar/1080x1920/");
                        string fileee25 = filename25.Replace(pathhh25, " ");
                        Debug.LogError(fileee25);
                        Debug.LogError(filename25);
                        var file25 = File.Open(filename25, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/1080x1920/", file25, fileee25);
                        
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 26 && PlayerPrefs.GetInt("loadingscreen") == 25)
                {
                    Debug.LogError("Загрузка 26 скрина");
                    string[] allfiles26 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ar/1600x2560/");
                    foreach (string filename26 in allfiles26)
                    {

                        string pathhh26 = (Application.dataPath.ToString() + "/screenshots/ar/1600x2560/");
                        string fileee26 = filename26.Replace(pathhh26, " ");
                        Debug.LogError(fileee26);
                        Debug.LogError(filename26);
                        var file26 = File.Open(filename26, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/1600x2560/", file26, fileee26);
                        
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 27 && PlayerPrefs.GetInt("loadingscreen") == 26)
                {
                    Debug.LogError("Загрузка 27 скрина");
                    string[] allfiles27 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ar/2048x2732/");
                    foreach (string filename27 in allfiles27)
                    {

                        string pathhh27 = (Application.dataPath.ToString() + "/screenshots/ar/2048x2732/");
                        string fileee27 = filename27.Replace(pathhh27, " ");
                        Debug.LogError(fileee27);
                        Debug.LogError(filename27);
                        var file27 = File.Open(filename27, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/2048x2732/", file27, fileee27);
                        
                    }
                    yield return new WaitForSecondsRealtime(delay);
                    loaddd++;
                }
                if (loaddd == 28 && PlayerPrefs.GetInt("loadingscreen") == 27)
                {
                    Debug.LogError("Загрузка 28 скрина");
                    string[] allfiles28 = Directory.GetFiles(UnityEngine.Application.dataPath + "/screenshots/ar/1242x2208/");
                    foreach (string filename28 in allfiles28)
                    {

                        string pathhh28 = (Application.dataPath.ToString() + "/screenshots/ar/1242x2208/");
                        string fileee28 = filename28.Replace(pathhh28, " ");
                        Debug.LogError(fileee28);
                        Debug.LogError(filename28);
                        var file28 = File.Open(filename28, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/1242x2208/", file28, fileee28);
                        loaddd++;
                        loaddd = 0;
                        starts = 0;
                    }

                }

            }
        else
        {
                if (loaddd == 1)
                {
                    string[] allfiles = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1080x1920/");
                    foreach (string filename in allfiles)
                    {
                        Debug.LogError("Загрузка 1 скрина");
                        string pathhh = (Application.persistentDataPath.ToString() + "/../screenshots/en/1080x1920/");
                        string fileee = filename.Replace(pathhh, " ");
                        Debug.Log(fileee);
                        Debug.Log(filename);
                        var file = File.Open(filename, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/1080x1920/", file, fileee);
                    }
                    loaddd++;
                }
                if (loaddd == 2 && PlayerPrefs.GetInt("loadingscreen") == 1)
                {
                    Debug.LogError("Загрузка 2 скрина");
                    string[] allfiles2 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1600x2560/");
                    foreach (string filename2 in allfiles2)
                    {

                        string pathhh2 = (Application.persistentDataPath.ToString() + "/../screenshots/en/1600x2560/");
                        string fileee2 = filename2.Replace(pathhh2, " ");
                        Debug.LogError(fileee2);
                        Debug.LogError(filename2);
                        var file2 = File.Open(filename2, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/1600x2560/", file2, fileee2);
                    }
                    loaddd++;
                }
                if (loaddd == 3 && PlayerPrefs.GetInt("loadingscreen") == 2)
                {
                    Debug.LogError("Загрузка 3 скрина");
                    string[] allfiles3 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1242x2208/");
                    foreach (string filename3 in allfiles3)
                    {

                        string pathhh3 = (Application.persistentDataPath.ToString() + "/../screenshots/en/1242x2208/");
                        string fileee3 = filename3.Replace(pathhh3, " ");
                        Debug.LogError(fileee3);
                        Debug.LogError(filename3);
                        var file3 = File.Open(filename3, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/1242x2208/", file3, fileee3);

                    }
                    loaddd++;
                }
                if (loaddd == 4 && PlayerPrefs.GetInt("loadingscreen") == 3)
                {
                    Debug.LogError("Загрузка 4 скрина");
                    string[] allfiles4 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/2048x2732/");
                    foreach (string filename4 in allfiles4)
                    {

                        string pathhh4 = (Application.persistentDataPath.ToString() + "/../screenshots/en/2048x2732/");
                        string fileee4 = filename4.Replace(pathhh4, " ");
                        Debug.LogError(fileee4);
                        Debug.LogError(filename4);
                        var file4 = File.Open(filename4, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/en/2048x2732/", file4, fileee4);

                    }
                    loaddd++;
                }
                if (loaddd == 5 && PlayerPrefs.GetInt("loadingscreen") == 4)
                {
                    Debug.LogError("Загрузка 5 скрина");
                    string[] allfiles5 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1080x1920/");
                    foreach (string filename5 in allfiles5)
                    {

                        string pathhh5 = (Application.persistentDataPath.ToString() + "/../screenshots/ru/1080x1920/");
                        string fileee5 = filename5.Replace(pathhh5, " ");
                        Debug.Log(fileee5);
                        Debug.Log(filename5);
                        var file5 = File.Open(filename5, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1080x1920/", file5, fileee5);
                    }
                    loaddd++;
                }
                if (loaddd == 6 && PlayerPrefs.GetInt("loadingscreen") == 5)
                {
                    Debug.LogError("Загрузка 6 скрина");
                    string[] allfiles6 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1600x2560/");
                    foreach (string filename6 in allfiles6)
                    {

                        string pathhh6 = (Application.persistentDataPath.ToString() + "/../screenshots/ru/1600x2560/");
                        string fileee6 = filename6.Replace(pathhh6, " ");
                        Debug.LogError(fileee6);
                        Debug.LogError(filename6);
                        var file6 = File.Open(filename6, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1600x2560/", file6, fileee6);
                    }
                    loaddd++;
                }
                if (loaddd == 7 && PlayerPrefs.GetInt("loadingscreen") == 6)
                {
                    Debug.LogError("Загрузка 7 скрина");
                    string[] allfiles7 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1242x2208/");
                    foreach (string filename7 in allfiles7)
                    {

                        string pathhh7 = (Application.persistentDataPath.ToString() + "/../screenshots/ru/1242x2208/");
                        string fileee7 = filename7.Replace(pathhh7, " ");
                        Debug.LogError(fileee7);
                        Debug.LogError(filename7);
                        var file7 = File.Open(filename7, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1242x2208/", file7, fileee7);

                    }
                    loaddd++;
                }
                if (loaddd == 8 && PlayerPrefs.GetInt("loadingscreen") == 7)
                {
                    Debug.LogError("Загрузка 8 скрина");
                    string[] allfiles8 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/2048x2732/");
                    foreach (string filename8 in allfiles8)
                    {

                        string pathhh8 = (Application.persistentDataPath.ToString() + "/../screenshots/ru/2048x2732/");
                        string fileee8 = filename8.Replace(pathhh8, " ");
                        Debug.LogError(fileee8);
                        Debug.LogError(filename8);
                        var file8 = File.Open(filename8, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/2048x2732/", file8, fileee8);
                        loaddd++;
                    }
                }
                if (loaddd == 9 && PlayerPrefs.GetInt("loadingscreen") == 8)
                {
                    string[] allfiles9 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1080x1920/");
                    foreach (string filename9 in allfiles9)
                    {
                        Debug.LogError("Загрузка 9 скрина");
                        string pathhh9 = (Application.persistentDataPath.ToString() + "/../screenshots/cn/1080x1920/");
                        string fileee9 = filename9.Replace(pathhh9, " ");
                        Debug.Log(fileee9);
                        Debug.Log(filename9);
                        var file9 = File.Open(filename9, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/1080x1920/", file9, fileee9);
                    }
                    loaddd++;
                }
                if (loaddd == 10 && PlayerPrefs.GetInt("loadingscreen") == 9)
                {
                    Debug.LogError("Загрузка 10 скрина");
                    string[] allfiles10 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1600x2560/");
                    foreach (string filename10 in allfiles10)
                    {

                        string pathhh10 = (Application.persistentDataPath.ToString() + "/../screenshots/cn/1600x2560/");
                        string fileee10 = filename10.Replace(pathhh10, " ");
                        Debug.LogError(fileee10);
                        Debug.LogError(filename10);
                        var file10 = File.Open(filename10, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/1600x2560/", file10, fileee10);
                    }
                    loaddd++;
                }
                if (loaddd == 11 && PlayerPrefs.GetInt("loadingscreen") == 10)
                {
                    Debug.LogError("Загрузка 11 скрина");
                    string[] allfiles11 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1242x2208/");
                    foreach (string filename11 in allfiles11)
                    {

                        string pathhh11 = (Application.persistentDataPath.ToString() + "/../screenshots/cn/1242x2208/");
                        string fileee11 = filename11.Replace(pathhh11, " ");
                        Debug.LogError(fileee11);
                        Debug.LogError(filename11);
                        var file11 = File.Open(filename11, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/1242x2208/", file11, fileee11);

                    }
                    loaddd++;
                }
                if (loaddd == 12 && PlayerPrefs.GetInt("loadingscreen") == 11)
                {
                    Debug.LogError("Загрузка 12 скрина");
                    string[] allfiles12 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/2048x2732/");
                    foreach (string filename12 in allfiles12)
                    {

                        string pathhh12 = (Application.persistentDataPath.ToString() + "/../screenshots/cn/2048x2732/");
                        string fileee12 = filename12.Replace(pathhh12, " ");
                        Debug.LogError(fileee12);
                        Debug.LogError(filename12);
                        var file12 = File.Open(filename12, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/cn/2048x2732/", file12, fileee12);

                    }
                    loaddd++;
                }
                if (loaddd == 13 && PlayerPrefs.GetInt("loadingscreen") == 12)
                {
                    Debug.LogError("Загрузка 13 скрина");
                    string[] allfiles13 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1080x1920/");
                    foreach (string filename13 in allfiles13)
                    {

                        string pathhh13 = (Application.persistentDataPath.ToString() + "/../screenshots/sp/1080x1920/");
                        string fileee13 = filename13.Replace(pathhh13, " ");
                        Debug.Log(fileee13);
                        Debug.Log(filename13);
                        var file13 = File.Open(filename13, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/1080x1920/", file13, fileee13);
                    }
                    loaddd++;
                }
                if (loaddd == 14 && PlayerPrefs.GetInt("loadingscreen") == 13)
                {
                    Debug.LogError("Загрузка 14 скрина");
                    string[] allfiles14 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1600x2560/");
                    foreach (string filename14 in allfiles14)
                    {

                        string pathhh14 = (Application.persistentDataPath.ToString() + "/../screenshots/sp/1600x2560/");
                        string fileee14 = filename14.Replace(pathhh14, " ");
                        Debug.LogError(fileee14);
                        Debug.LogError(filename14);
                        var file14 = File.Open(filename14, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/1600x2560/", file14, fileee14);
                    }
                    loaddd++;
                }
                if (loaddd == 15 && PlayerPrefs.GetInt("loadingscreen") == 14)
                {
                    Debug.LogError("Загрузка 15 скрина");
                    string[] allfiles15 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1242x2208/");
                    foreach (string filename15 in allfiles15)
                    {

                        string pathhh15 = (Application.persistentDataPath.ToString() + "/../screenshots/sp/1242x2208/");
                        string fileee15 = filename15.Replace(pathhh15, " ");
                        Debug.LogError(fileee15);
                        Debug.LogError(filename15);
                        var file15 = File.Open(filename15, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/1242x2208/", file15, fileee15);

                    }
                    loaddd++;
                }
                if (loaddd == 16 && PlayerPrefs.GetInt("loadingscreen") == 15)
                {
                    Debug.LogError("Загрузка 16 скрина");
                    string[] allfiles16 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/2048x2732/");
                    foreach (string filename16 in allfiles16)
                    {

                        string pathhh16 = (Application.persistentDataPath.ToString() + "/../screenshots/sp/2048x2732/");
                        string fileee16 = filename16.Replace(pathhh16, " ");
                        Debug.LogError(fileee16);
                        Debug.LogError(filename16);
                        var file16 = File.Open(filename16, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/sp/2048x2732/", file16, fileee16);
                        loaddd++;
                    }
                }
                if (loaddd == 17 && PlayerPrefs.GetInt("loadingscreen") == 16)
                {
                    string[] allfiles17 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1080x1920/");
                    foreach (string filename17 in allfiles17)
                    {
                        Debug.LogError("Загрузка 17 скрина");
                        string pathhh17 = (Application.persistentDataPath.ToString() + "/../screenshots/jp/1080x1920/");
                        string fileee17 = filename17.Replace(pathhh17, " ");
                        Debug.Log(fileee17);
                        Debug.Log(filename17);
                        var file17 = File.Open(filename17, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/1080x1920/", file17, fileee17);
                    }
                    loaddd++;
                }
                if (loaddd == 18 && PlayerPrefs.GetInt("loadingscreen") == 17)
                {
                    Debug.LogError("Загрузка 18 скрина");
                    string[] allfiles18 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1600x2560/");
                    foreach (string filename18 in allfiles18)
                    {

                        string pathhh18 = (Application.persistentDataPath.ToString() + "/../screenshots/jp/1600x2560/");
                        string fileee18 = filename18.Replace(pathhh18, " ");
                        Debug.LogError(fileee18);
                        Debug.LogError(filename18);
                        var file18 = File.Open(filename18, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/1600x2560/", file18, fileee18);
                    }
                    loaddd++;
                }
                if (loaddd == 19 && PlayerPrefs.GetInt("loadingscreen") == 18)
                {
                    Debug.LogError("Загрузка 19 скрина");
                    string[] allfiles19 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1242x2208/");
                    foreach (string filename19 in allfiles19)
                    {

                        string pathhh19 = (Application.persistentDataPath.ToString() + "/../screenshots/jp/1242x2208/");
                        string fileee19 = filename19.Replace(pathhh19, " ");
                        Debug.LogError(fileee19);
                        Debug.LogError(filename19);
                        var file19 = File.Open(filename19, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/1242x2208/", file19, fileee19);

                    }
                    loaddd++;
                }
                if (loaddd == 20 && PlayerPrefs.GetInt("loadingscreen") == 19)
                {
                    Debug.LogError("Загрузка 20 скрина");
                    string[] allfiles20 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/2048x2732/");
                    foreach (string filename20 in allfiles20)
                    {

                        string pathhh20 = (Application.persistentDataPath.ToString() + "/../screenshots/jp/2048x2732/");
                        string fileee20 = filename20.Replace(pathhh20, " ");
                        Debug.LogError(fileee20);
                        Debug.LogError(filename20);
                        var file20 = File.Open(filename20, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/jp/2048x2732/", file20, fileee20);

                    }
                    loaddd++;
                }
                if (loaddd == 21 && PlayerPrefs.GetInt("loadingscreen") == 20)
                {
                    Debug.LogError("Загрузка 21 скрина");
                    string[] allfiles21 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1080x1920/");
                    foreach (string filename21 in allfiles21)
                    {

                        string pathhh21 = (Application.persistentDataPath.ToString() + "/../screenshots/pt/1080x1920/");
                        string fileee21 = filename21.Replace(pathhh21, " ");
                        Debug.Log(fileee21);
                        Debug.Log(filename21);
                        var file21 = File.Open(filename21, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/1080x1920/", file21, fileee21);
                    }
                    loaddd++;
                }
                if (loaddd == 22 && PlayerPrefs.GetInt("loadingscreen") == 21)
                {
                    Debug.LogError("Загрузка 22 скрина");
                    string[] allfiles22 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1600x2560/");
                    foreach (string filename22 in allfiles22)
                    {

                        string pathhh22 = (Application.persistentDataPath.ToString() + "/../screenshots/pt/1600x2560/");
                        string fileee22 = filename22.Replace(pathhh22, " ");
                        Debug.LogError(fileee22);
                        Debug.LogError(filename22);
                        var file22 = File.Open(filename22, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/1600x2560/", file22, fileee22);
                    }
                    loaddd++;
                }
                if (loaddd == 23 && PlayerPrefs.GetInt("loadingscreen") == 22)
                {
                    Debug.LogError("Загрузка 23 скрина");
                    string[] allfiles23 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1242x2208/");
                    foreach (string filename23 in allfiles23)
                    {

                        string pathhh23 = (Application.persistentDataPath.ToString() + "/../screenshots/pt/1242x2208/");
                        string fileee23 = filename23.Replace(pathhh23, " ");
                        Debug.LogError(fileee23);
                        Debug.LogError(filename23);
                        var file23 = File.Open(filename23, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/1242x2208/", file23, fileee23);

                    }
                    loaddd++;
                }
                if (loaddd == 24 && PlayerPrefs.GetInt("loadingscreen") == 23)
                {
                    Debug.LogError("Загрузка 24 скрина");
                    string[] allfiles24 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/2048x2732/");
                    foreach (string filename24 in allfiles24)
                    {

                        string pathhh24 = (Application.persistentDataPath.ToString() + "/../screenshots/pt/2048x2732/");
                        string fileee24 = filename24.Replace(pathhh24, " ");
                        Debug.LogError(fileee24);
                        Debug.LogError(filename24);
                        var file24 = File.Open(filename24, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/pt/2048x2732/", file24, fileee24);
                        loaddd++;
                    }
                }
                if (loaddd == 25 && PlayerPrefs.GetInt("loadingscreen") == 24)
                {
                    Debug.LogError("Загрузка 25 скрина");
                    string[] allfiles25 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1080x1920/");
                    foreach (string filename25 in allfiles25)
                    {

                        string pathhh25 = (Application.persistentDataPath.ToString() + "/../screenshots/ar/1080x1920/");
                        string fileee25 = filename25.Replace(pathhh25, " ");
                        Debug.LogError(fileee25);
                        Debug.LogError(filename25);
                        var file25 = File.Open(filename25, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/1080x1920/", file25, fileee25);
                        loaddd++;
                    }
                }
                if (loaddd == 26 && PlayerPrefs.GetInt("loadingscreen") == 25)
                {
                    Debug.LogError("Загрузка 26 скрина");
                    string[] allfiles26 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1600x2560/");
                    foreach (string filename26 in allfiles26)
                    {

                        string pathhh26 = (Application.persistentDataPath.ToString() + "/../screenshots/ar/1600x2560/");
                        string fileee26 = filename26.Replace(pathhh26, " ");
                        Debug.LogError(fileee26);
                        Debug.LogError(filename26);
                        var file26 = File.Open(filename26, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/1600x2560/", file26, fileee26);
                        loaddd++;
                    }
                }
                if (loaddd == 27 && PlayerPrefs.GetInt("loadingscreen") == 26)
                {
                    Debug.LogError("Загрузка 27 скрина");
                    string[] allfiles27 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/2048x2732/");
                    foreach (string filename27 in allfiles27)
                    {

                        string pathhh27 = (Application.persistentDataPath.ToString() + "/../screenshots/ar/2048x2732/");
                        string fileee27 = filename27.Replace(pathhh27, " ");
                        Debug.LogError(fileee27);
                        Debug.LogError(filename27);
                        var file27 = File.Open(filename27, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/2048x2732/", file27, fileee27);
                        loaddd++;
                    }
                }
                if (loaddd == 28 && PlayerPrefs.GetInt("loadingscreen") == 27)
                {
                    Debug.LogError("Загрузка 28 скрина");
                    string[] allfiles28 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1242x2208/");
                    foreach (string filename28 in allfiles28)
                    {

                        string pathhh28 = (Application.persistentDataPath.ToString() + "/../screenshots/ar/1242x2208/");
                        string fileee28 = filename28.Replace(pathhh28, " ");
                        Debug.LogError(fileee28);
                        Debug.LogError(filename28);
                        var file28 = File.Open(filename28, FileMode.Open);

                        webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ar/1242x2208/", file28, fileee28);
                        loaddd++;
                        loaddd = 0;
                        starts = 0;
                    }

                }

            }
        }
    }

    public void GetNameFolder()
    {
        Название_игры = PlayerPrefs.GetString("Namefolder");
    }
    public void Qwera()
    {//string link = @"https://disk.yandex.by/i/6TpVpL0ESzC8bQ"; //ссылка
     //     WebClient webClient = new WebClient();
     //   webClient.DownloadFileAsync(new System.Uri(link), Application.dataPath+"test.wmv");

        var file = File.Open(Application.dataPath + "/test.wmv", FileMode.Open);
        //webDAVClient.CreateDir("/","testingwebdav");
        //  File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        webDAVClient.Upload("/Screenshots/", file, "test_file.wmv");
    }
    public void LoadEnglish()
    {
        Debug.LogError("LoadEnglish");
        if (loaddd==0 && starts==0){
        starts = 1;
        loaddd = 1;
        }
        
    }

    public void AllLanguage()
    {

    }
    public void delete()
    {
        DirectoryInfo dirInfo = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1080x1920/");
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo2 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1600x2560/");
        foreach (FileInfo file in dirInfo2.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo3 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1242x2208/");
        foreach (FileInfo file in dirInfo3.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo4 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/en/2048x2732/");
        foreach (FileInfo file in dirInfo4.GetFiles())
        {
            file.Delete();
        }




        DirectoryInfo dirInfo5 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1080x1920/");
        foreach (FileInfo file in dirInfo5.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo6 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1600x2560/");
        foreach (FileInfo file in dirInfo6.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo7 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1242x2208/");
        foreach (FileInfo file in dirInfo7.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo8 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/2048x2732/");
        foreach (FileInfo file in dirInfo8.GetFiles())
        {
            file.Delete();
        }





        DirectoryInfo dirInfo9 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1080x1920/");
        foreach (FileInfo file in dirInfo9.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo10 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1600x2560/");
        foreach (FileInfo file in dirInfo10.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo11 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1242x2208/");
        foreach (FileInfo file in dirInfo11.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo12 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/2048x2732/");
        foreach (FileInfo file in dirInfo12.GetFiles())
        {
            file.Delete();
        }





        DirectoryInfo dirInfo13 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1080x1920/");
        foreach (FileInfo file in dirInfo13.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo14 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1600x2560/");
        foreach (FileInfo file in dirInfo14.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo15 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1242x2208/");
        foreach (FileInfo file in dirInfo15.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo16 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/2048x2732/");
        foreach (FileInfo file in dirInfo16.GetFiles())
        {
            file.Delete();
        }






        DirectoryInfo dirInfo17 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1080x1920/");
        foreach (FileInfo file in dirInfo17.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo18 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1600x2560/");
        foreach (FileInfo file in dirInfo18.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo19 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1242x2208/");
        foreach (FileInfo file in dirInfo19.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo20 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/2048x2732/");
        foreach (FileInfo file in dirInfo20.GetFiles())
        {
            file.Delete();
        }








        DirectoryInfo dirInfo21 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1080x1920/");
        foreach (FileInfo file in dirInfo21.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo22 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1600x2560/");
        foreach (FileInfo file in dirInfo22.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo23 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1242x2208/");
        foreach (FileInfo file in dirInfo23.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo24 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/2048x2732/");
        foreach (FileInfo file in dirInfo24.GetFiles())
        {
            file.Delete();
        }








        DirectoryInfo dirInfo25 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1080x1920/");
        foreach (FileInfo file in dirInfo25.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo26 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1600x2560/");
        foreach (FileInfo file in dirInfo26.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo27 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1242x2208/");
        foreach (FileInfo file in dirInfo27.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo28 = new DirectoryInfo(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/2048x2732/");
        foreach (FileInfo file in dirInfo28.GetFiles())
        {
            file.Delete();
        }









        /* DirectoryInfo dirInfo5 = new DirectoryInfo(UnityEngine.Application.dataPath + "/../screenshots/1080x1920/");

         foreach (FileInfo file in dirInfo5.GetFiles())
         {
             file.Delete();
         }
         DirectoryInfo dirInfo6 = new DirectoryInfo(UnityEngine.Application.dataPath + "/../screenshots/1600x2560");

         foreach (FileInfo file in dirInfo6.GetFiles())
         {
             file.Delete();
         }
         */
    }
    public void delete2()
    {
        DirectoryInfo dirInfo = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/en/1080x1920/");
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo2 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/en/1600x2560/");
        foreach (FileInfo file in dirInfo2.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo3 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/en/1242x2208/");
        foreach (FileInfo file in dirInfo3.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo4 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/en/2048x2732/");
        foreach (FileInfo file in dirInfo4.GetFiles())
        {
            file.Delete();
        }




        DirectoryInfo dirInfo5 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ru/1080x1920/");
        foreach (FileInfo file in dirInfo5.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo6 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ru/1600x2560/");
        foreach (FileInfo file in dirInfo6.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo7 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ru/1242x2208/");
        foreach (FileInfo file in dirInfo7.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo8 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ru/2048x2732/");
        foreach (FileInfo file in dirInfo8.GetFiles())
        {
            file.Delete();
        }





        DirectoryInfo dirInfo9 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/sp/1080x1920/");
        foreach (FileInfo file in dirInfo9.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo10 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/sp/1600x2560/");
        foreach (FileInfo file in dirInfo10.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo11 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/sp/1242x2208/");
        foreach (FileInfo file in dirInfo11.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo12 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/sp/2048x2732/");
        foreach (FileInfo file in dirInfo12.GetFiles())
        {
            file.Delete();
        }





        DirectoryInfo dirInfo13 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/jp/1080x1920/");
        foreach (FileInfo file in dirInfo13.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo14 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/jp/1600x2560/");
        foreach (FileInfo file in dirInfo14.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo15 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/jp/1242x2208/");
        foreach (FileInfo file in dirInfo15.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo16 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/jp/2048x2732/");
        foreach (FileInfo file in dirInfo16.GetFiles())
        {
            file.Delete();
        }






        DirectoryInfo dirInfo17 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ar/1080x1920/");
        foreach (FileInfo file in dirInfo17.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo18 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ar/1600x2560/");
        foreach (FileInfo file in dirInfo18.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo19 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ar/1242x2208/");
        foreach (FileInfo file in dirInfo19.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo20 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/ar/2048x2732/");
        foreach (FileInfo file in dirInfo20.GetFiles())
        {
            file.Delete();
        }








        DirectoryInfo dirInfo21 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/pt/1080x1920/");
        foreach (FileInfo file in dirInfo21.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo22 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/pt/1600x2560/");
        foreach (FileInfo file in dirInfo22.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo23 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/pt/1242x2208/");
        foreach (FileInfo file in dirInfo23.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo24 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/pt/2048x2732/");
        foreach (FileInfo file in dirInfo24.GetFiles())
        {
            file.Delete();
        }








        DirectoryInfo dirInfo25 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/cn/1080x1920/");
        foreach (FileInfo file in dirInfo25.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo26 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/cn/1600x2560/");
        foreach (FileInfo file in dirInfo26.GetFiles())
        {
            file.Delete();
        }
        DirectoryInfo dirInfo27 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/cn/1242x2208/");
        foreach (FileInfo file in dirInfo27.GetFiles())
        {
            file.Delete();
        }

        DirectoryInfo dirInfo28 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/cn/2048x2732/");
        foreach (FileInfo file in dirInfo28.GetFiles())
        {
            file.Delete();
        }









        /* DirectoryInfo dirInfo5 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/1080x1920/");

         foreach (FileInfo file in dirInfo5.GetFiles())
         {
             file.Delete();
         }
         DirectoryInfo dirInfo6 = new DirectoryInfo(UnityEngine.Application.dataPath + "/screenshots/1600x2560");

         foreach (FileInfo file in dirInfo6.GetFiles())
         {
             file.Delete();
         }
         */
    }

    public void StAsync()
    {
        if (Lean.Localization.LeanLocalization.currentLanguage == "English")
        {
            string[] allfiles = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1080x1920/");
            foreach (string filename in allfiles)
            {

                string pathhh = (Application.persistentDataPath.ToString() + "/../screenshots/en/1080x1920/");
                string fileee = filename.Replace(pathhh, " ");
                Debug.Log(fileee);
                Debug.Log(filename);
                var file = File.Open(filename, FileMode.Open);

                webDAVClient.Upload("/Screenshots/" + Название_игры + "/en/1080x1920/", file, fileee);
            }
            string[] allfiles2 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1600x2560/");
            foreach (string filename2 in allfiles2)
            {

                string pathhh2 = (Application.persistentDataPath.ToString() + "/../screenshots/en/1600x2560/");
                string fileee2 = filename2.Replace(pathhh2, " ");
                Debug.LogError(fileee2);
                Debug.LogError(filename2);
                var file2 = File.Open(filename2, FileMode.Open);

                webDAVClient.Upload("/Screenshots/" + Название_игры + "/en/1600x2560/", file2, fileee2);
            }
            string[] allfiles3 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1242x2208/");
            foreach (string filename3 in allfiles3)
            {

                string pathhh3 = (Application.persistentDataPath.ToString() + "/../screenshots/en/1242x2208/");
                string fileee3 = filename3.Replace(pathhh3, " ");
                Debug.LogError(fileee3);
                Debug.LogError(filename3);
                var file3 = File.Open(filename3, FileMode.Open);

                webDAVClient.Upload("/Screenshots/" + Название_игры + "/en/1242x2208/", file3, fileee3);
            }
            string[] allfiles4 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/2048x2732/");
            foreach (string filename4 in allfiles4)
            {

                string pathhh4 = (Application.persistentDataPath.ToString() + "/../screenshots/en/2048x2732/");
                string fileee4 = filename4.Replace(pathhh4, " ");
                Debug.LogError(fileee4);
                Debug.LogError(filename4);
                var file4 = File.Open(filename4, FileMode.Open);

                webDAVClient.Upload("/Screenshots/" + Название_игры + "/en/2048x2732/", file4, fileee4);
            }
        }


        if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
        {
            string[] allfiles = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1080x1920/");
            foreach (string filename in allfiles)
            {

                string pathhh = (Application.persistentDataPath.ToString() + "/../screenshots/ru/1080x1920/");
                string fileee = filename.Replace(pathhh, " ");
                Debug.Log(fileee);
                Debug.Log(filename);
                var file = File.Open(filename, FileMode.Open);

                webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1080x1920/", file, fileee);
            }
            string[] allfiles2 = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1600x2560/");
            foreach (string filename2 in allfiles2)
            {

                string pathhh2 = (Application.persistentDataPath.ToString() + "/../screenshots/ru/1600x2560/");
                string fileee2 = filename2.Replace(pathhh2, " ");
                Debug.Log(fileee2);
                Debug.Log(filename2);
                var file2 = File.Open(filename2, FileMode.Open);

                webDAVClient.UploadAsync("/Screenshots/" + Название_игры + "/ru/1600x2560/", file2, fileee2);
            }

        }


    }



    /*   
       var files = File.Open(Application.dataPath+"/test.wmv",FileMode.Open);
           //webDAVClient.CreateDir("/","testingwebdav");
         //  File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
       webDAVClient.UploadAsync("/Screenshots/",files,"test_file.wmv");
   /*
       string pathhh = (Application.dataPath.ToString() + "/../screenshots/");
       string fileee = filename.Replace(pathhh," ");
       Debug.Log(fileee);
       Debug.Log(filename);
       var file = File.Open(filename,FileMode.Open);

       webDAVClient.UploadAsync("/Screenshots",file,fileee);
       Debug.Log("dfgh");
   */


    public void ProverkaFolderScrenshot()
    {
        var res = webDAVClient.List("/");
        foreach (WebDAVClient.Model.Item item in res)
        {
            if (item.DisplayName == "Screenshots")
            {
                folderscreen = true;
                Debug.Log("Cуществует");
                break;
            }
        }
        if (folderscreen == true)
        {
            var res2 = webDAVClient.List("/Screenshots/");
            foreach (WebDAVClient.Model.Item item in res2)
            {
                if (item.DisplayName == Название_игры)
                {
                    folderscreename = true;
                    Debug.Log("Cуществует");
                    break;
                }
            }
        }
        Createfolderscreen();



    }
    public void Createfolderscreen()
    {
        if (folderscreen == false)
        {
            webDAVClient.CreateDir("/", "Screenshots");

            webDAVClient.CreateDir("/Screenshots/", Название_игры);

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "en");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "ru");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "cn");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "jp");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "pt");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "ar");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "sp");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "2048x2732");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "2048x2732");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "2048x2732");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "2048x2732");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "2048x2732");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "2048x2732");

            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "1080x1920");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "1600x2560");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "1242x2208");
            webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "2048x2732");
        }
        else
        {
            if (folderscreename == false)
            {
                webDAVClient.CreateDir("/Screenshots/", Название_игры);

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "en");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "ru");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "cn");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "jp");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "pt");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "ar");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/", "sp");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/en/", "2048x2732");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ru/", "2048x2732");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/ar/", "2048x2732");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/jp/", "2048x2732");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/sp/", "2048x2732");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/cn/", "2048x2732");

                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "1080x1920");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "1600x2560");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "1242x2208");
                webDAVClient.CreateDir("/Screenshots/" + Название_игры + "/pt/", "2048x2732");
            }
        }
    }
    public void ProverkaLocalFolder()
    {
        if (UnityEngine.Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (!Directory.Exists(UnityEngine.Application.dataPath + "/screenshots/"))
            {
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/sp");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ar");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/jp");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/pt");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/cn");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/sp/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/sp/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/sp/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/sp/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ar/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ar/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ar/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ar/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/jp/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/jp/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/jp/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/jp/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/pt/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/pt/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/pt/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/pt/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/cn/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/cn/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/cn/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/cn/2048x2732");


                Debug.LogWarning("Создана папка");
            }
        }
        else
        {
            if (!Directory.Exists(UnityEngine.Application.persistentDataPath + "/../screenshots/"))
            {
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/sp");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ar");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/jp");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/pt");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/cn");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/sp/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ar/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/jp/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/pt/2048x2732");

                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1080x1920");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1600x2560");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/1242x2208");
                Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/cn/2048x2732");


                Debug.LogWarning("Создана папка");
            }
        }
    }
}
