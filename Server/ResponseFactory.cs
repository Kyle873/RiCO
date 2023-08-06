using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RiCO.Server;

[AttributeUsage(AttributeTargets.Method)]
internal class RequestHandler : Attribute
{
    public Type Type { get; }

    public RequestHandler(Type type)
        => Type = type;
}

public static class ResponseFactory
{
    public static readonly Dictionary<Type, Action> Handlers = new Dictionary<Type, Action>();

    static ResponseFactory()
    {
        RiCO.Log.LogMessage("Loading Response Handlers...");

        IEnumerable<Type> classes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                    select t;

        // TODO: stop being lazy smh, this isn't that hard
        // foreach ()
        {

        }

        RiCO.Log.LogMessage("Loading Response Handlers finished");
    }
    
    public static Action GetResponseHandler(Type type)
    {
        Handlers.TryGetValue(type, out Action action);
        
        return action;
    }
}
