#region Licence

// Description: SymuBiz - Symu
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

using System;

namespace Symu.Common.Interfaces.Entity
{
    /// <summary>
    /// Interface for the unique identifier of an entity
    /// </summary>
    public interface IId : IComparable
    {
        bool IsNull { get; }
        bool IsNotNull { get; }
        bool Equals(IId id);
    }
}