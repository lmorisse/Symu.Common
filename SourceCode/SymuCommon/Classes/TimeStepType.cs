﻿#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

namespace Symu.Common.Classes
{
    public enum TimeStepType
    {
        /// <summary>
        ///     WorkOnTask is splitted so that an agent has the opportunity to select another task with customized
        ///     PrioritizeNextTask
        /// </summary>
        Intraday = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 4,
        Quarterly = 5,
        SemiYearly = 6,
        Yearly = 7
    }
}