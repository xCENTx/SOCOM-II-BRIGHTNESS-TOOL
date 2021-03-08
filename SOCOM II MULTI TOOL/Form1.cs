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
            string data = ("YOU MUST ENABLE CHEATS AND THEN DISABLE CHEATS IN PCSX2 FOR ALL FUNCTIONS TO WORK...");
            MessageBox.Show(data);

            if (pcsx2Running)
            {
                m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
            }
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
            if (pcsx2Running)
            {
                m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
            }
        }

        private void ROn_Click(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                int newdata = 0x100000DB;
                m.Write<Int32>(GameHelper.RENDER, newdata, false);
            }
        }

        private void ROff_Click(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                int newdata = 0x106000DB;
                m.Write<Int32>(GameHelper.RENDER, newdata, false);
            }
        }

        private void BLow_Click(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());

                int newdata1 = 0x00000000;
                int newdata2 = 0x00000000;
                int newdata3 = 0x00000000;
                m.Write<Int32>(GameHelper.BRIGHTNESS1, newdata1, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS2, newdata2, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS3, newdata3, false);
            }
        }

        private void PerfectBrightness_Click(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                int newdata1 = 0x40800000;
                int newdata2 = 0x40800000;
                int newdata3 = 0x40800000;
                m.Write<Int32>(GameHelper.BRIGHTNESS1, newdata1, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS2, newdata2, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS3, newdata3, false);
            }
        }

        private void ProModBrightness_Click(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                int newdata1 = 0x41000000;
                int newdata2 = 0x41000000;
                int newdata3 = 0x41000000;
                m.Write<Int32>(GameHelper.BRIGHTNESS1, newdata1, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS2, newdata2, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS3, newdata3, false);
            }
        }

        private void BMax_Click(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                int newdata1 = 0x41880000;
                int newdata2 = 0x41880000;
                int newdata3 = 0x41880000;
                m.Write<Int32>(GameHelper.BRIGHTNESS1, newdata1, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS2, newdata2, false);
                m.Write<Int32>(GameHelper.BRIGHTNESS3, newdata3, false);
            }
        }
    }
}
