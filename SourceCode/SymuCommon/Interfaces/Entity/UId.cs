#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

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
        public bool IsNotNull => Id != 0;

        public bool Equals(IId id)
        {
            return id is UId iid && Id == iid.Id;
        }
    }
}