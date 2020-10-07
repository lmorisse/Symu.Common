#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using System.Data.SqlTypes;

#endregion

namespace Symu.Common.Interfaces
{
    /// <summary>
    ///     IAgentId is the interface for the unique identifier of the agent
    /// </summary>
    public interface IAgentId : INullable
    {
        IId Id { get; set; }
        IClassId ClassId { get; set; }
        bool Equals(IAgentId agentId);
        bool Equals(IClassId classId);

        /// <summary>
        ///     Implement inferior operator
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns>true if this is inferior to agentId </returns>
        bool CompareTo(IAgentId agentId);
    }
}