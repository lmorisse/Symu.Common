#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

namespace Symu.Common.Interfaces
{
    /// <summary>
    ///     Default implementation of IID
    ///     Id is ushort
    /// </summary>
    public class UId : IId
    {
        public UId(ushort id)
        {
            Id = id;
        }

        public ushort Id { get; }

        #region IId Members

        public bool Equals(IId id)
        {
            return id is UId iid && Id == iid.Id;
        }

        public int CompareTo(object obj)
        {
            if (obj is UId id)
            {
                return Id - id.Id;
            }

            return 0;
        }

        #endregion

        public override bool Equals(object id)
        {
            return id is UId iid && Id == iid.Id;
        }

        /// <summary>
        ///     Don't remove
        ///     Constant because equals tests mutable member.
        ///     This will give poor hash performance, but will prevent ContainsKey bugs.
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

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}