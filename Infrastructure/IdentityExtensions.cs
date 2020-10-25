using System;
using System.Security.Claims;
using System.Security.Principal;
using Etechnosoft.Common.Enums;
using Etechnosoft.Common.Exceptions;

namespace Etechnosoft.Common.Infrastructure
{
    public class EtechnosoftClaimTypes
    {
        public const string RegistrationStatus = "registration-status";
        public const string DeviceCode = "device-code";
        public const string DeviceChanged = "device-changed";
    }
    public static class IdentityExtensions
    {
        public static long GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            return long.Parse(claim.Value);
        }
        public static RegistrationStatusEnum GetRegistrationStatus(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(EtechnosoftClaimTypes.RegistrationStatus);
            if(claim==null)
                throw new EtechnosoftException("registration-status claim is required.");
            return (RegistrationStatusEnum) int.Parse(claim.Value);
        }
        public static string GetDeviceCode(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(EtechnosoftClaimTypes.DeviceCode);
            return claim?.Value;
        }
        public static bool GetDeviceChanged(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(EtechnosoftClaimTypes.DeviceChanged);
            return bool.Parse(claim.Value);
        }
    }
}