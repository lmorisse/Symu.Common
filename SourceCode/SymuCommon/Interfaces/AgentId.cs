#region Licence

// Description: SymuBiz - Symu
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using System;

#endregion

namespace Symu.Common.Interfaces
{
    /// <summary>
    /// AgentId is the default implementation of the interface of the unique identifier of the agent
    /// </summary>
    public struct AgentId : IAgentId
    {
        /// <summary>
        ///     Unique Id of the agent
        /// </summary>
        public IId Id { get; set; }

        /// <summary>
        ///     ClassId of the agent
        /// </summary>
        public IClassId ClassId { get; set; }

        public byte Class => ((ClassId?)ClassId)?.Id ?? 0;

        public bool Equals(IId id)
        {
            return Id.Equals(id);
        }

        public AgentId(ushort id, byte classId)
        {
            Id = new UId(id);
            ClassId = new ClassId(classId);
        }
        public AgentId(ushort id, IClassId classId)
        {
            Id = new UId(id);
            ClassId = classId;
        }
        public AgentId(UId id, byte classId)
        {
            Id = id;
            ClassId = new ClassId(classId);
        }
        public AgentId(IId id, byte classId)
        {
            Id = (UId)id;
            ClassId = new ClassId(classId);
        }
        public AgentId(UId id, IClassId classId)
        {
            Id = id;
            ClassId = (ClassId)classId;
        }
        public AgentId(IId id, IClassId classId)
        {
            Id = (UId)id;
            ClassId = (ClassId)classId;
        }
        public AgentId(IAgentId agentId)
        {
            if (agentId == null)
            {
                throw new ArgumentNullException(nameof(agentId));
            }

            Id = (UId)agentId.Id;
            ClassId = (ClassId)agentId.ClassId;
        }

        /// <summary>
        ///     Don't remove this substitution
        ///     Use Equals and not ContainsKey(agentId) or implement GetHashCode substitution
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is AgentId id &&
                   (id.Id != null && Id != null && Id.Equals(id.Id) && ClassId.Equals(id.ClassId) ||
                    Id == null && id.Id == null);
        }

        public bool Equals(IAgentId agentId)
        {
            return agentId is AgentId id &&
                   (id.Id != null && Id != null && Id.Equals(id.Id) && ClassId.Equals(id.ClassId) ||
                    Id == null && id.Id == null);
        }

        public bool Equals(IClassId classId)
        {
            return ClassId.Equals(classId);
        }

        //public bool Equals(byte classId)
        //{
        //    return Class == classId;
        //}

        /// <summary>
        /// Implement inferior operator
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns>true if this is inferior to agentId </returns>
        public bool CompareTo(IAgentId agentId)
        {
            return agentId is AgentId agent && ((UId)Id).Id < ((UId)agent.Id).Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public static bool operator ==(AgentId left, AgentId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AgentId left, AgentId right)
        {
            return !(left == right);
        }

        /// <summary>Indicates whether a structure is null. This property is read-only.</summary>
        /// <returns><see cref="T:System.Data.SqlTypes.SqlBoolean"></see>true if the value of this object is null. Otherwise, false.</returns>
        public bool IsNull => Id == null;
    }
}