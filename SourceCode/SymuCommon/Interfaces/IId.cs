#region Licence

// Description: SymuBiz - SymuCommon
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
    ///     Interface for the unique identifier of an entity
    /// </summary>
    public interface IId : IComparable
    {
        bool Equals(IId id);
    }
}