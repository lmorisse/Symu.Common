#region Licence

// Description: SymuBiz - Symu
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

namespace Symu.Common.Interfaces.Agent
{
    /// <summary>
    /// ClassId is the default implementation of IClassId, the interface for the unique identifier of the class of the agent
    /// </summary>
    public struct ClassId : IClassId
    {
        /// <summary>
        ///     Class Key of the agent
        /// </summary>
        public byte Id { get; set; }

        public ClassId(byte id)
        {
            Id = id;
        }

        public bool Equals(IClassId classId)
        {
            return Id == ((ClassId)classId).Id;
        }
    }
}