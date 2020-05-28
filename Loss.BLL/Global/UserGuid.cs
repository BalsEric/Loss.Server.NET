using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

public static class UserGuid
{

    static Dictionary<Guid, string> UsersGuid = new Dictionary<Guid, string>();


    public static void Add(string username)
    {
        UsersGuid.Add(Guid.NewGuid(), username);
    }
    public static string GetUsernameByGuid(Guid guid)
    {
        try
        {
            return UsersGuid[guid];
        }
        catch
        {
            return string.Empty;
        }
    }

    public static string GetGuidByUsername(string username)
    {
        foreach (KeyValuePair<Guid, string> kvp in UsersGuid)
        {
            if (kvp.Value == username)
            {
                return kvp.Key.ToString();
            }
        }
        return string.Empty;
    }

    public static bool IsGuidValid(string guid)
    {
        Guid newGuid;
        try
        {
            if (Guid.TryParse(guid, out newGuid))
            {
                if (!GetUsernameByGuid(newGuid).Equals(string.Empty))
                {
                    return true;
                }
            }
            return false;

        }
        catch
        {
            return false;
        }
    }

}