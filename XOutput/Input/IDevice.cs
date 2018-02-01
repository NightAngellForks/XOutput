﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOutput.Input
{
    public interface IDevice
    {
        /// <summary>
        /// This event is invoked if the data from the device was updated
        /// </summary>
        event Action InputChanged;
        /// <summary>
        /// Gets the current state of the DPad.
        /// </summary>
        /// <returns></returns>
        DPadDirection DPad { get; }
        /// <summary>
        /// Gets the current state of the inputTpye.
        /// </summary>
        /// <param name="inputType">Type of input</param>
        /// <returns>Value</returns>
        double Get(Enum inputType);
        /// <summary>
        /// Gets all Enum values that represent button
        /// </summary>
        /// <returns></returns>
        IEnumerable<Enum> GetButtons();
        /// <summary>
        /// Gets all Enum values that represent axis
        /// </summary>
        /// <returns></returns>
        IEnumerable<Enum> GetAxes();
    }
}
