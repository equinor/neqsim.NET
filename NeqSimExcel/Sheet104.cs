﻿using System;
using Microsoft.Office.Interop.Excel;
using neqsim.thermodynamicOperations;
using Office = Microsoft.Office.Core;

namespace NeqSimExcel
{
    public partial class Sheet10
    {
        private void Sheet10_Startup(object sender, EventArgs e)
        {
        }

        private void Sheet10_Shutdown(object sender, EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Startup += new System.EventHandler(this.Sheet10_Startup);
            this.Shutdown += new System.EventHandler(this.Sheet10_Shutdown);

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var thermoSystem = NeqSimThermoSystem.getThermoSystem(); //.clone();
            thermoSystem.setTemperature(283.75);


            var range = Range["A2", "A100"];
            var number = 1;
            foreach (Range r in range.Cells)
            {
                var text = (string) r.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    number++;
                    thermoSystem.setPressure(r.Value2);
                    var ops = new ThermodynamicOperations(thermoSystem);
                    ops.calcWAT();
                    var textVar = "B" + number;
                    Range[textVar].Value2 = thermoSystem.getTemperature() - 273.15;
                }
            }
        }
    }
}