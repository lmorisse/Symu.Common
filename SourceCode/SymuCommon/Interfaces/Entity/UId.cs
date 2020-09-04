#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

using System;

namespace Symu.Common.Interfaces.Entity
{
    /// <summary>
    /// Default implementation of IID
    /// Id is ushort
    /// </summary>
    public class UId : IId
    {
        public UId(ushort id)
        {
            Id = id;
        }
        public ushort Id { get; }
        public bool IsNull => Id == 0;

        public bool Equals(IId id)
        {
            return id is UId iid && Id == iid.Id;
        }
        public override bool Equals(object id)
        {
            return id is UId iid && Id == iid.Id;
        }
        /// <summary>
        /// Don't remove
        /// Constant because equals tests mutable member.
        /// This will give poor hash performance, but will prevent ContainsKey bugs.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        public static ushort Cast(IId id)
        {
            if (id is UId uid)
            {
                return uid.Id;
            }
            return 0;
        }

        public int CompareTo(object obj)
        {
            if (obj is UId id)
            {
                return Id - id.Id;
            }

            return 0;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}