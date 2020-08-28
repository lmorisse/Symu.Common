#region Licence

// Description: SymuBiz - Symu
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

using System;

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
            return Id == Cast(classId);
        }

        public bool Equals(byte classId)
        {
            return Id == classId;
        }

        public static byte Cast(IClassId classId)
        {
            return ((ClassId) classId).Id;
        }

        public static byte Cast(IAgentId agentId)
        {
            if (agentId == null)
            {
                throw new ArgumentNullException(nameof(agentId));
            }

            return ((ClassId)agentId.ClassId).Id;
        }
    }
}