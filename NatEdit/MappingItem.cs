using Mono.Nat;
using System;
using System.Collections.Generic;

namespace NatEdit
{
    class MappingItem : IEquatable<MappingItem>
    {
        public readonly Mapping Mapping;

        public MappingItem(Mapping mapping) => Mapping = mapping;

        public override bool Equals(object obj) => Equals(obj as MappingItem);

        public bool Equals(MappingItem other) => other != null && Mapping.Equals(other.Mapping);

        public override int GetHashCode() => 1416879085 + EqualityComparer<Mapping>.Default.GetHashCode(Mapping);

        public override string ToString() => $"{Mapping.Protocol}:{Mapping.PublicPort} -> {Mapping.PrivateAddress}:{Mapping.PrivatePort}, {Mapping.Description}";
    }
}
