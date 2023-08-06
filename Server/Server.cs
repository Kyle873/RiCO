using System.Net;
using System.Threading.Tasks;
using System;
using System.IO;

namespace RiCO.Server;

public static class Server
{
    public static int SeqCount = 0;
    
    readonly static HttpListener listener = new HttpListener();

    public static void Start()
    {
        listener.Prefixes.Add("http://localhost:443/");
        listener.Start();

        RiCO.Log.LogWarning("Local server started");

        Task.Run(() => HandleIncomingRequests());
    }

    public static void Stop()
    {
        listener.Stop();
        listener.Close();
    }

    async static Task HandleIncomingRequests()
    {
        while (listener.IsListening)
        {
            try
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HandleRequest(context);
            }
            catch (Exception ex)
            {
                RiCO.Log.LogError(ex);
            }
        }
    }

    static void HandleRequest(HttpListenerContext context)
    {
        string type = context.Request.RawUrl.Trim('/');
        string data = string.Empty;

        if (context.Request.HasEntityBody)
            using (Stream body = context.Request.InputStream)
            using (StreamReader reader = new StreamReader(body, context.Request.ContentEncoding))
                data = reader.ReadToEnd();

        data = AesCrypto.Decode(data);

        RiCO.Log.LogWarning($"Received {type} from Client:\n{Utils.FormatJson(data)}");

        // TODO: rewrite logic calls using attribute handlers
    }
}
