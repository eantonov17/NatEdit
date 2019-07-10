//
// Authors:
//   Alan McGovern alan.mcgovern@gmail.com
//   Ben Motmans <ben.motmans@gmail.com>
//
// Copyright (C) 2006 Alan McGovern
// Copyright (C) 2007 Ben Motmans
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Mono.Nat
{
    public sealed class Mapping : IEquatable<Mapping>
    {
        /// <summary>
        /// The text description for the port mapping.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The time the port mapping should expire at.
        /// </summary>
        public DateTime Expiration { get; }

        /// <summary>
        /// The lifetime of the port mapping in seconds. If a lifetime of '0' is specified then the
        /// protocol default lifetime is used. uPnP defaults to 'indefinite' whereas NAT-PMP defaults
        /// to 7,200 seconds.
        /// </summary>
        public int Lifetime { get; private set; }

        /// <summary>
        /// The protocol used for the port mapping.
        /// </summary>
        public Protocol Protocol { get; }

        /// <summary>
        /// The internal/LAN address which will receive traffic
        /// </summary>
        public string LocalAddress { get; }

        /// <summary>
        /// The internal/LAN port which will receive traffic
        /// </summary>
        public int LocalPort { get; }

        /// <summary>
        /// The internal/LAN address of the router which will send traffic
        /// </summary>
        public string RouterAddress { get; }

        /// <summary>
        /// The internal/LAN port which will send traffic
        /// </summary>
        public int RouterPort { get; }

        /// <summary>
        /// Output of ToString()
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a port mapping so traffic sent to the <paramref name="routerPort"/> on the WAN device is sent to the <paramref name="localPort"/> on the LAN device.
        /// </summary>
        /// <param name="protocol">The protocol used by the port mapping.</param>
        /// <param name="localPort">The internal/LAN port which will receive traffic sent to the <paramref name="routerPort"/> on the WAN device.</param>
        /// <param name="routerPort">Traffic sent to this external/WAN port is forwarded to the <paramref name="localPort"/> on the LAN device.</param>
        //  public Mapping (Protocol protocol, int privatePort, int publicPort)
        //	: this (protocol, privatePort, publicPort, 0, null)
        //{
        //}

        /// <summary>
        /// Create a port mapping so traffic sent to the <paramref name="publicPort"/> on the WAN device is sent to the <paramref name="privatePort"/> on the LAN device.
        /// </summary>
        /// <param name="protocol">The protocol used by the port mapping.</param>
        /// <param name="privatePort">The internal/LAN port which will receive traffic sent to the <paramref name="publicPort"/> on the WAN device.</param>
        /// <param name="publicPort">Traffic sent to this public/WAN port is forwarded to the <paramref name="privatePort"/> on the LAN device.</param>
        /// <param name="lifetime">The lifetime of the port mapping in seconds. If a lifetime of '0' is specified then the protocol default lifetime is used. uPnP defaults to 'indefinite' whereas NAT-PMP defaults to 7,200 seconds.</param>
        /// <param name="description">The text description for the port mapping.</param>
        public Mapping(Protocol protocol, string routerAddress, int routerPort, string localAddress, int localPort, string description, int lifetime)
        {
            Protocol = protocol;
            RouterAddress = routerAddress;
            RouterPort = routerPort;
            LocalAddress = localAddress;
            LocalPort = localPort;
            Description = description?.Trim();
            Name = $"{Protocol}:{RouterAddress}:{RouterPort} -> {LocalAddress}:{LocalPort}";
            if (!string.IsNullOrWhiteSpace(Description))
                Name += ", " + Description;

            Lifetime = lifetime;

            if (lifetime == int.MaxValue)
                Expiration = DateTime.MaxValue;
            else if (lifetime == 0)
                Expiration = DateTime.Now;
            else
                Expiration = DateTime.Now.AddSeconds(lifetime);
        }

        public bool IsExpired() => Expiration < DateTime.Now;

        /// <summary>
        /// Mappings are considered equal if they have the same PrivatePort, PublicPort and Protocol.
        /// </summary>
        /// <param name="obj">The other object to compare with</param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as Mapping);

        /// <summary>
        /// Mappings are considered equal if they have the same PrivatePort, PublicPort and Protocol.
        /// </summary>
        /// <param name="other">The other mapping to compare with</param>
        /// <returns></returns>
        public bool Equals(Mapping other) => other != null
                && Protocol == other.Protocol
                && LocalAddress == other.LocalAddress
                && LocalPort == other.LocalPort
                && RouterAddress == other.RouterAddress
                && RouterPort == other.RouterPort;

        public override int GetHashCode()
            => Protocol.GetHashCode() ^ LocalPort.GetHashCode() ^ RouterPort.GetHashCode();

        public override string ToString() => Name;
    }
}
