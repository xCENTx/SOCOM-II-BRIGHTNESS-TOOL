﻿using Binarysharp.MemoryManagement;
using SOCOM_II_MULTI_TOOL.Helpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SOCOM_II_TOOL
{
    public partial class Form1 : Form
    {
        MemorySharp m = null;
        private const string PCSX2PROCESSNAME = "pcsx2";
        bool pcsx2Running;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ///This was a message box for a previous build with the render fix toggle
            string data = ("SOCOM 2 Brightness Tool for PCSX2 users");
            MessageBox.Show(data);

            if (!pcsx2Running)
            {
                return;
            }
            m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);

            if (pcsx2.Length > 0)
            {
                pcsx2Status.Text = "PCSX2 CONNECTED";
                pnl_PCSX2Detected.BackColor = Color.FromArgb(0, 100, 0);
                pcsx2Running = true;
                return;
            }
            pcsx2Status.Text = "PCSX2 NOT DETECTED";
            pnl_PCSX2Detected.BackColor = Color.FromArgb(100, 0, 0);
            pcsx2Running = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
        }

        /// DEFAULT BRIGHTNESS
        private void BLow_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
            int newValue = 0x00000000;
             m.Write<Int32>(GameHelper.BRIGHTNESS1, newValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS2, newValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3, newValue, false);  
        }

        /// SLIGHT BRIGHTNESS ADJUSTMENT
        private void PerfectBrightness_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
             int lockedValue = 0x00000000;
             int newValue = 0x40800000;
             m.Write<Int32>(GameHelper.BRIGHTNESS1, newValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK1, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK2, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS1_RESET, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS2, newValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK1, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK2, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS2_RESET, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3, newValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK1, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK2, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK3, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3_RESET, lockedValue, false);
             m.Write<Int32>(GameHelper.BRIGHTNESS3_RESETA, lockedValue, false);
        }
    }
}
