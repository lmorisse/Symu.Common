#region Licence

// Description: SymuBiz - Symu
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using System;
using Symu.Common.Math.ProbabilityDistributions;

#endregion

namespace Symu.Common.Classes
{
    /// <summary>
    ///     Base Class to a symu model
    /// </summary>
    /// <example>
    ///     Multi tasking
    ///     Prioritization
    ///     ...
    /// </example>
    public class ModelEntity
    {
        private float _rateOfAgentsOn = 1F;

        public ModelEntity()
        {
        }

        private bool _on;
        /// <summary>
        ///     If (On) the model is active globally
        /// </summary>
        public bool On
        {
            get => _on;
            set => SetOn(value);
        }

        protected virtual void SetOn(bool value)
        {
            _on = value;
        }

        /// <summary>
        ///     If model is On, individuals may use or not the model
        ///     RateOfAgentsOn define the rate of agent that will use effectively the model
        ///     [0; 1] default 1
        /// </summary>
        /// <example>if RateOfAgentsOn = 1, every agent will use the model</example>
        /// <example>if RateOfAgentsOn = 0, no agent will use the model, equivalent to Model Off</example>
        /// <example>if RateOfAgentsOn = 0.8F, 80% of agents will use the model</example>
        public float RateOfAgentsOn
        {
            get => _rateOfAgentsOn;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("RateOfAgentsOn should be between 0 and 1");
                }

                _rateOfAgentsOn = value;
            }
        }

        public virtual void CopyTo(ModelEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.On = On;
            entity.RateOfAgentsOn = RateOfAgentsOn;
        }
        public virtual ModelEntity Clone()
        {
            var clone = new ModelEntity();
            CopyTo(clone);
            return clone;
        }

        /// <summary>
        ///     When Model is On, individuals may use or not the model
        ///     IsAgentOn set the agent parameter to On or Off
        /// </summary>
        /// <returns>A random bool if model is On, false otherwise</returns>
        public bool IsAgentOn()
        {
            return On && Bernoulli.Sample(RateOfAgentsOn);
        }

    }
}