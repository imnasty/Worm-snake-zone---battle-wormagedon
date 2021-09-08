using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using WebDAVClient;
[ExecuteInEditMode]
public class qwertyu : MonoBehaviour
{
    public static qwertyu instance;
    public WebDAVClient.Client Webdav;
    public VideoPlayer askervideoads;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        instance = this;
    }
    public void Server(string Webdav_server)
    {
        Webdav.server = Webdav_server;
    }
    public void URL(string url)
    {
        askervideoads.url = url;
    }


}
