using Binarysharp.MemoryManagement;
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
            string data = ("YOU MUST ENABLE CHEATS AND THEN DISABLE CHEATS IN PCSX2 for RENDER FIX...");
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

        private void ROn_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         m.Write<Int32>(GameHelper.RENDER, 0x100000DB, false);
        }

        private void ROff_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         m.Write<Int32>(GameHelper.RENDER, 0x106000DB, false);
        }

        private void BLow_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         m.Write<Int32>(GameHelper.BRIGHTNESS1, 0x00000000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2, 0x00000000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3, 0x00000000, false);  
        }

        private void PerfectBrightness_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         int newdata1 = 0x00000000;
         m.Write<Int32>(GameHelper.BRIGHTNESS1, 0x40800000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2, 0x40800000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3, 0x40800000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK3, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_RESETA, newdata1, false);
        }

        private void ProModBrightness_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         int newdata1 = 0x00000000;
         m.Write<Int32>(GameHelper.BRIGHTNESS1, 0x41000000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2, 0x41000000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3, 0x41000000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK3, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_RESETA, newdata1, false);
        }

        private void BMax_Click(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
         int newdata1 = 0x00000000;
         m.Write<Int32>(GameHelper.BRIGHTNESS1, 0x41880000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS1_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2, 0x41880000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS2_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3, 0x41880000, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK1, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK2, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_LOCK3, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_RESET, newdata1, false);
         m.Write<Int32>(GameHelper.BRIGHTNESS3_RESETA, newdata1, false);
        }
    }
}
