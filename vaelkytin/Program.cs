﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CSGSI;
using CSGSI.Nodes;
using System.Diagnostics;
using ArtNet.Sockets;
using ArtNet.Packets;
using System.Net;

namespace vaelkytin
{
    static class Program
    {

        public static GameStateListener gsl = new GameStateListener(3000);
        public static HealthBars healthBars = new HealthBars();
        public static List<PlayerNode> nodeList = new List<PlayerNode>();
        public static ArtNetSocket artNet;
        private static Form1 barForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            gsl.NewGameState += new NewGameStateHandler(OnNewGameState);
            InitializeArtNet();
            if (!gsl.Start())
            {
                Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            barForm = new Form1();
            barForm.Show();
            Application.Run(new ConfigurationForm());
            
        }

        static void InitializeArtNet()
        {
            artNet = new ArtNetSocket();
            artNet.EnableBroadcast = true;
            Debug.WriteLine(artNet.BroadcastAddress);
            artNet.Open(IPAddress.Parse("192.168.1.74"), IPAddress.Parse("255.255.255.0"));
        }

        public static void SendPacketOverArtNet()
        {
            for (short i = 0; i < healthBars.Count; i++)
            {
                ArtNetDmxPacket packet = new ArtNetDmxPacket();
                packet.Universe = (short)i;
                byte[] stripBytes = healthBars.GetStrip(i).GetAsBytes();
                packet.DmxData = new byte[stripBytes.Length];
                if (stripBytes.Length > 0)
                {
                    Buffer.BlockCopy(stripBytes, 0, packet.DmxData, 0, stripBytes.Length);
                    artNet.Send(packet);
                }
            }
            
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            artNet.Close();
            gsl.Stop();
        }

        static void OnNewGameState(GameState gs)
        {            
            nodeList = gs.AllPlayers.PlayerList as List<PlayerNode>; 
            for (int i = 0; i < nodeList.Count(); i++)
            {
                int index = healthBars.GetHealthIndexBarById(nodeList[i].SteamID);
                if (index > -1)
                {
                    healthBars.SetHealth(index, Math.Min(nodeList[i].State.Health, 100),nodeList[i].State.Flashed);
                }
            }
        }
    }
}
