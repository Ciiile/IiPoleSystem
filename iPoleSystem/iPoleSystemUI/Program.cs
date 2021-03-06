﻿using iPoleSystemLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPoleSystemUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IIPoleSystem PoleSystem = new IPoleSystem();
            PoleSystem.CreateUserList();
            PoleSystem.CreateTeamList();
            PoleSystem.DeleteUnnecessaryStringsFromOpenGym();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.AddMessageFilter(new MessageFilter());
            InactivityTimer inactivity = new InactivityTimer(PoleSystem);
            Application.Run(new LoginForm(PoleSystem));
        }
    }
}
