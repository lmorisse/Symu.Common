#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

namespace Symu.Common.Core.Interfaces
{
    /// <summary>
    ///     Defines a generalized comparison method that a value type or class implements to create a type-specific comparison
    ///     method for ordering or sorting its instances.
    /// </summary>
    /// <typeparam name="T">The type of object to compare.</typeparam>
    /// <remarks>The difference with System.IComparable is the return type which is a float</remarks>
    public interface IComparable<in T>
    {
        float CompareTo(T other);
    }
}