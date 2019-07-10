using Mono.Nat;
using System.Collections.Generic;
using System.Net;

namespace NatEdit
{
    class Device
    {
        public readonly INatDevice NatDevice;
        public readonly IPAddress ExternalIP;
        public readonly IPAddress LocalIP;
        public readonly string Name;

        public Device(INatDevice device)
        {
            NatDevice = device;
            ExternalIP = device.GetExternalIP();
            LocalIP = device.DeviceEndpoint.Address;
            Name = $"{ExternalIP}/{LocalIP}";
            if (device.DeviceName != null)
                Name += ", " + device.DeviceName;
        }

        public override bool Equals(object obj)
        {
            var device = obj as Device;
            return device != null &&
                   EqualityComparer<INatDevice>.Default.Equals(NatDevice, device.NatDevice);
        }

        public override int GetHashCode()
        {
            return -684672021 + EqualityComparer<INatDevice>.Default.GetHashCode(NatDevice);
        }

        public override string ToString() => Name;
    }


}
