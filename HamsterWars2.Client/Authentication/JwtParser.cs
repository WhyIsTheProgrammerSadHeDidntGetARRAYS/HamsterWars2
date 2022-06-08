using System.Security.Claims;
using System.Text.Json;


namespace HamsterWars2.Client.Authentication
{
    //Jwt parser ifrån Tim corey's video, som följer ett exempel utav
    //Steve Sanderson (https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo/tree/master/demos/MissionControl/MissionControl.Client/Util)
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            
            var payload = jwt.Split(".")[1]; //first "element" in jwt is header, second is payload, therefore index 1
            
            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            ExtractRolesFromJwt(claims, keyValuePairs);

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        //använder ej role-based authorization, men kan vara bra att ha ifall jag vill leka vidare med detta senare
        private static void ExtractRolesFromJwt(List<Claim> claims, Dictionary<string, object> keyValuePair)
        {
            keyValuePair.TryGetValue(ClaimTypes.Role, out object roles);

            if(roles != null)
            {
                var parsedRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');

                //If there are multiple roles, go ahead and add those to the claims list
                if(parsedRoles.Length > 1)
                {
                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole.Trim('"')));
                    }
                }
                //if there is only one role, get the first element
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRoles[0]));
                }
                //the reason we remove the roles from the dictionary is so that it doesnt get double processed
                keyValuePair.Remove(ClaimTypes.Role);
            }
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
