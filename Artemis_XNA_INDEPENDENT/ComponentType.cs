#region File description

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComponentType.cs" company="GAMADU.COM">
//     Copyright © 2013 GAMADU.COM. All rights reserved.
//
//     Redistribution and use in source and binary forms, with or without modification, are
//     permitted provided that the following conditions are met:
//
//        1. Redistributions of source code must retain the above copyright notice, this list of
//           conditions and the following disclaimer.
//
//        2. Redistributions in binary form must reproduce the above copyright notice, this list
//           of conditions and the following disclaimer in the documentation and/or other materials
//           provided with the distribution.
//
//     THIS SOFTWARE IS PROVIDED BY GAMADU.COM 'AS IS' AND ANY EXPRESS OR IMPLIED
//     WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//     FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL GAMADU.COM OR
//     CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
//     CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//     SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
//     ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//     NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
//     ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//     The views and conclusions contained in the software and documentation are those of the
//     authors and should not be interpreted as representing official policies, either expressed
//     or implied, of GAMADU.COM.
// </copyright>
// <summary>
//   Represents a Component Type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
#endregion File description

namespace Artemis
{
    #region Using statements

    using global::System;
    using global::System.Collections.Generic;
    using global::System.Diagnostics;
#if XBOX || WINDOWS_PHONE || PORTABLE || FORCEINT32
    using BigInteger = global::System.Int32;
#else
    using global::System.Numerics;
#endif
    using Artemis.Interface;
    using Artemis.Manager;

    #endregion Using statements

    /// <summary>Represents a Component Type.</summary>
    [DebuggerDisplay("Id:{Id}, Bit:{Bit}")]
    public sealed class ComponentType 
    {
        /// <summary>Initializes a new instance of the <see cref="ComponentType"/> class.</summary>
        internal ComponentType(int id, BigInteger bit)
        {
            this.Id = id;
            this.Bit = bit;
        }

        /// <summary>Gets the bit index that represents this type of component.</summary>
        /// <value>The id.</value>
        public int Id { get; private set; }

        /// <summary>Gets the bit that represents this type of component.</summary>
        /// <value>The bit.</value>
        public BigInteger Bit { get; private set; }

        internal static ComponentType OfType(global::System.Type type)
        {
            return ComponentTypeManager.GetTypeFor(type);
        }

        internal static ComponentType OfType<T>() where T : IComponent
        {
            return ComponentTypeCache<T>.CType;
        }

        internal static IEnumerable<Type> GetTypesFromBits(BigInteger bits)
        {
            return ComponentTypeManager.GetTypesFromBits(bits);
        }

        /// <summary>The component type cache class.</summary>
        /// <typeparam name="T">The Type T.</typeparam>
        private static class ComponentTypeCache<T> where T : IComponent
        {
            /// <summary>Initializes static members of the <see cref="ComponentTypeCache{T}"/> class.</summary>
            static ComponentTypeCache()
            {
                CType = ComponentTypeManager.GetTypeFor<T>();
            }

            /// <summary>Gets the type of the C.</summary>
            /// <value>The type of the C.</value>
            public static ComponentType CType { get; private set; }
        }
    }
}
