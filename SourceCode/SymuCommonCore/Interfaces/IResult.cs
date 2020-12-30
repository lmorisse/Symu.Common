#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using Symu.Common.Core.Classes;

#endregion

namespace Symu.Common.Core.Interfaces
{
    public interface IResult
    {
        /// <summary>
        ///     If set to true, Tasks will be filled with value and stored during the simulation
        /// </summary>
        bool On { get; set; }

        /// <summary>
        ///     Frequency of the results
        /// </summary>
        TimeStepType Frequency { get; set; }

        /// <summary>
        ///     Put the logic to compute the result and store it in the list
        /// </summary>
        void SetResults();

        /// <summary>
        ///     Clear the list or all information
        /// </summary>
        void Clear();

        /// <summary>
        ///     Copy each parameter of the instance in the object
        /// </summary>
        /// <returns></returns>
        void CopyTo(object clone);

        /// <summary>
        ///     Clone the instance.
        ///     IterationResult is the actual iterationResult.
        ///     With a multiple iterations simulation, SimulationResults store a clone of each IterationResult
        ///     It is a factory that create a SymuResults then CopyTo the existing instance and return the clone
        /// </summary>
        /// <returns></returns>
        IResult Clone();
    }
}