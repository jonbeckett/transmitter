﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualFlightOnlineTransmitter
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnConnect = new System.Windows.Forms.Button();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.lbNotes = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lbGroupName = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.tbPilotName = new System.Windows.Forms.TextBox();
            this.tbCallsign = new System.Windows.Forms.TextBox();
            this.lbPilotName = new System.Windows.Forms.Label();
            this.lbCallsign = new System.Windows.Forms.Label();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.gbAircraftData = new System.Windows.Forms.GroupBox();
            this.lbAircraftType = new System.Windows.Forms.Label();
            this.tbAircraftType = new System.Windows.Forms.TextBox();
            this.lbTouchdownVelocity = new System.Windows.Forms.Label();
            this.tbTouchdownVelocity = new System.Windows.Forms.TextBox();
            this.lbGroundspeed = new System.Windows.Forms.Label();
            this.tbGroundspeed = new System.Windows.Forms.TextBox();
            this.lbHeading = new System.Windows.Forms.Label();
            this.tbHeading = new System.Windows.Forms.TextBox();
            this.lbAirspeed = new System.Windows.Forms.Label();
            this.lbAltitude = new System.Windows.Forms.Label();
            this.tbAirspeed = new System.Windows.Forms.TextBox();
            this.tbAltitude = new System.Windows.Forms.TextBox();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.tbLongitude = new System.Windows.Forms.TextBox();
            this.lbLatitude = new System.Windows.Forms.Label();
            this.lbLongitude = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.transmitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSettingsToDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualFlightOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whoIsOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbUserInfo.SuspendLayout();
            this.gbAircraftData.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(12, 194);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(412, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserInfo.Controls.Add(this.lbNotes);
            this.gbUserInfo.Controls.Add(this.tbNotes);
            this.gbUserInfo.Controls.Add(this.lbGroupName);
            this.gbUserInfo.Controls.Add(this.tbGroupName);
            this.gbUserInfo.Controls.Add(this.tbPilotName);
            this.gbUserInfo.Controls.Add(this.tbCallsign);
            this.gbUserInfo.Controls.Add(this.lbPilotName);
            this.gbUserInfo.Controls.Add(this.lbCallsign);
            this.gbUserInfo.Location = new System.Drawing.Point(12, 27);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(412, 161);
            this.gbUserInfo.TabIndex = 1;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "User Information";
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Location = new System.Drawing.Point(7, 104);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(35, 13);
            this.lbNotes.TabIndex = 10;
            this.lbNotes.Text = "Notes";
            // 
            // tbNotes
            // 
            this.tbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotes.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(89, 100);
            this.tbNotes.MaxLength = 1024;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotes.Size = new System.Drawing.Size(317, 55);
            this.tbNotes.TabIndex = 9;
            this.tbNotes.TextChanged += new System.EventHandler(this.tbNotes_TextChanged);
            this.tbNotes.Leave += new System.EventHandler(this.tbNotes_Leave);
            // 
            // lbGroupName
            // 
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.Location = new System.Drawing.Point(6, 76);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(67, 13);
            this.lbGroupName.TabIndex = 7;
            this.lbGroupName.Text = "Group Name";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGroupName.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGroupName.Location = new System.Drawing.Point(89, 72);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(317, 22);
            this.tbGroupName.TabIndex = 3;
            this.tbGroupName.TextChanged += new System.EventHandler(this.tbGroupName_TextChanged);
            this.tbGroupName.Leave += new System.EventHandler(this.tbGroupName_Leave);
            // 
            // tbPilotName
            // 
            this.tbPilotName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPilotName.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPilotName.Location = new System.Drawing.Point(89, 44);
            this.tbPilotName.Name = "tbPilotName";
            this.tbPilotName.Size = new System.Drawing.Size(317, 22);
            this.tbPilotName.TabIndex = 2;
            this.tbPilotName.TextChanged += new System.EventHandler(this.tbPilotName_TextChanged);
            this.tbPilotName.Leave += new System.EventHandler(this.tbPilotName_Leave);
            // 
            // tbCallsign
            // 
            this.tbCallsign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCallsign.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCallsign.Location = new System.Drawing.Point(89, 16);
            this.tbCallsign.Name = "tbCallsign";
            this.tbCallsign.Size = new System.Drawing.Size(317, 22);
            this.tbCallsign.TabIndex = 0;
            this.tbCallsign.TextChanged += new System.EventHandler(this.tbCallsign_TextChanged);
            this.tbCallsign.Leave += new System.EventHandler(this.tbCallsign_Leave);
            // 
            // lbPilotName
            // 
            this.lbPilotName.AutoSize = true;
            this.lbPilotName.Location = new System.Drawing.Point(7, 48);
            this.lbPilotName.Name = "lbPilotName";
            this.lbPilotName.Size = new System.Drawing.Size(58, 13);
            this.lbPilotName.TabIndex = 1;
            this.lbPilotName.Text = "Pilot Name";
            // 
            // lbCallsign
            // 
            this.lbCallsign.AutoSize = true;
            this.lbCallsign.Location = new System.Drawing.Point(6, 19);
            this.lbCallsign.Name = "lbCallsign";
            this.lbCallsign.Size = new System.Drawing.Size(43, 13);
            this.lbCallsign.TabIndex = 0;
            this.lbCallsign.Text = "Callsign";
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // gbAircraftData
            // 
            this.gbAircraftData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAircraftData.Controls.Add(this.lbAircraftType);
            this.gbAircraftData.Controls.Add(this.tbAircraftType);
            this.gbAircraftData.Controls.Add(this.lbTouchdownVelocity);
            this.gbAircraftData.Controls.Add(this.tbTouchdownVelocity);
            this.gbAircraftData.Controls.Add(this.lbGroundspeed);
            this.gbAircraftData.Controls.Add(this.tbGroundspeed);
            this.gbAircraftData.Controls.Add(this.lbHeading);
            this.gbAircraftData.Controls.Add(this.tbHeading);
            this.gbAircraftData.Controls.Add(this.lbAirspeed);
            this.gbAircraftData.Controls.Add(this.lbAltitude);
            this.gbAircraftData.Controls.Add(this.tbAirspeed);
            this.gbAircraftData.Controls.Add(this.tbAltitude);
            this.gbAircraftData.Controls.Add(this.tbLatitude);
            this.gbAircraftData.Controls.Add(this.tbLongitude);
            this.gbAircraftData.Controls.Add(this.lbLatitude);
            this.gbAircraftData.Controls.Add(this.lbLongitude);
            this.gbAircraftData.Location = new System.Drawing.Point(12, 223);
            this.gbAircraftData.Name = "gbAircraftData";
            this.gbAircraftData.Size = new System.Drawing.Size(412, 246);
            this.gbAircraftData.TabIndex = 3;
            this.gbAircraftData.TabStop = false;
            this.gbAircraftData.Text = "Aircraft Data";
            // 
            // lbAircraftType
            // 
            this.lbAircraftType.AutoSize = true;
            this.lbAircraftType.Location = new System.Drawing.Point(7, 23);
            this.lbAircraftType.Name = "lbAircraftType";
            this.lbAircraftType.Size = new System.Drawing.Size(67, 13);
            this.lbAircraftType.TabIndex = 15;
            this.lbAircraftType.Text = "Aircraft Type";
            // 
            // tbAircraftType
            // 
            this.tbAircraftType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAircraftType.Enabled = false;
            this.tbAircraftType.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAircraftType.Location = new System.Drawing.Point(89, 19);
            this.tbAircraftType.Name = "tbAircraftType";
            this.tbAircraftType.Size = new System.Drawing.Size(317, 22);
            this.tbAircraftType.TabIndex = 14;
            // 
            // lbTouchdownVelocity
            // 
            this.lbTouchdownVelocity.AutoSize = true;
            this.lbTouchdownVelocity.Location = new System.Drawing.Point(7, 220);
            this.lbTouchdownVelocity.Name = "lbTouchdownVelocity";
            this.lbTouchdownVelocity.Size = new System.Drawing.Size(71, 13);
            this.lbTouchdownVelocity.TabIndex = 13;
            this.lbTouchdownVelocity.Text = "Landing Rate";
            // 
            // tbTouchdownVelocity
            // 
            this.tbTouchdownVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTouchdownVelocity.Enabled = false;
            this.tbTouchdownVelocity.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTouchdownVelocity.Location = new System.Drawing.Point(89, 216);
            this.tbTouchdownVelocity.Name = "tbTouchdownVelocity";
            this.tbTouchdownVelocity.Size = new System.Drawing.Size(317, 22);
            this.tbTouchdownVelocity.TabIndex = 12;
            // 
            // lbGroundspeed
            // 
            this.lbGroundspeed.AutoSize = true;
            this.lbGroundspeed.Location = new System.Drawing.Point(7, 192);
            this.lbGroundspeed.Name = "lbGroundspeed";
            this.lbGroundspeed.Size = new System.Drawing.Size(71, 13);
            this.lbGroundspeed.TabIndex = 11;
            this.lbGroundspeed.Text = "Groundspeed";
            // 
            // tbGroundspeed
            // 
            this.tbGroundspeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGroundspeed.Enabled = false;
            this.tbGroundspeed.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGroundspeed.Location = new System.Drawing.Point(89, 188);
            this.tbGroundspeed.Name = "tbGroundspeed";
            this.tbGroundspeed.Size = new System.Drawing.Size(317, 22);
            this.tbGroundspeed.TabIndex = 10;
            // 
            // lbHeading
            // 
            this.lbHeading.AutoSize = true;
            this.lbHeading.Location = new System.Drawing.Point(6, 136);
            this.lbHeading.Name = "lbHeading";
            this.lbHeading.Size = new System.Drawing.Size(47, 13);
            this.lbHeading.TabIndex = 9;
            this.lbHeading.Text = "Heading";
            // 
            // tbHeading
            // 
            this.tbHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeading.Enabled = false;
            this.tbHeading.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeading.Location = new System.Drawing.Point(89, 132);
            this.tbHeading.Name = "tbHeading";
            this.tbHeading.Size = new System.Drawing.Size(317, 22);
            this.tbHeading.TabIndex = 8;
            // 
            // lbAirspeed
            // 
            this.lbAirspeed.AutoSize = true;
            this.lbAirspeed.Location = new System.Drawing.Point(7, 164);
            this.lbAirspeed.Name = "lbAirspeed";
            this.lbAirspeed.Size = new System.Drawing.Size(48, 13);
            this.lbAirspeed.TabIndex = 7;
            this.lbAirspeed.Text = "Airspeed";
            // 
            // lbAltitude
            // 
            this.lbAltitude.AutoSize = true;
            this.lbAltitude.Location = new System.Drawing.Point(7, 107);
            this.lbAltitude.Name = "lbAltitude";
            this.lbAltitude.Size = new System.Drawing.Size(42, 13);
            this.lbAltitude.TabIndex = 6;
            this.lbAltitude.Text = "Altitude";
            // 
            // tbAirspeed
            // 
            this.tbAirspeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAirspeed.Enabled = false;
            this.tbAirspeed.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAirspeed.Location = new System.Drawing.Point(89, 160);
            this.tbAirspeed.Name = "tbAirspeed";
            this.tbAirspeed.Size = new System.Drawing.Size(317, 22);
            this.tbAirspeed.TabIndex = 9;
            // 
            // tbAltitude
            // 
            this.tbAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAltitude.Enabled = false;
            this.tbAltitude.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAltitude.Location = new System.Drawing.Point(89, 103);
            this.tbAltitude.Name = "tbAltitude";
            this.tbAltitude.Size = new System.Drawing.Size(317, 22);
            this.tbAltitude.TabIndex = 7;
            // 
            // tbLatitude
            // 
            this.tbLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLatitude.Enabled = false;
            this.tbLatitude.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLatitude.Location = new System.Drawing.Point(89, 47);
            this.tbLatitude.Name = "tbLatitude";
            this.tbLatitude.Size = new System.Drawing.Size(317, 22);
            this.tbLatitude.TabIndex = 6;
            // 
            // tbLongitude
            // 
            this.tbLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLongitude.Enabled = false;
            this.tbLongitude.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLongitude.Location = new System.Drawing.Point(89, 75);
            this.tbLongitude.Name = "tbLongitude";
            this.tbLongitude.Size = new System.Drawing.Size(317, 22);
            this.tbLongitude.TabIndex = 5;
            // 
            // lbLatitude
            // 
            this.lbLatitude.AutoSize = true;
            this.lbLatitude.Location = new System.Drawing.Point(6, 51);
            this.lbLatitude.Name = "lbLatitude";
            this.lbLatitude.Size = new System.Drawing.Size(45, 13);
            this.lbLatitude.TabIndex = 1;
            this.lbLatitude.Text = "Latitude";
            // 
            // lbLongitude
            // 
            this.lbLongitude.AutoSize = true;
            this.lbLongitude.Location = new System.Drawing.Point(7, 79);
            this.lbLongitude.Name = "lbLongitude";
            this.lbLongitude.Size = new System.Drawing.Size(54, 13);
            this.lbLongitude.TabIndex = 0;
            this.lbLongitude.Text = "Longitude";
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transmitterToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.virtualFlightOnlineToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.mnuMain.Size = new System.Drawing.Size(428, 24);
            this.mnuMain.TabIndex = 4;
            this.mnuMain.Text = "menuStrip1";
            // 
            // transmitterToolStripMenuItem
            // 
            this.transmitterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetSettingsToDefaultsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem1});
            this.transmitterToolStripMenuItem.Name = "transmitterToolStripMenuItem";
            this.transmitterToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.transmitterToolStripMenuItem.Text = "&File";
            // 
            // resetSettingsToDefaultsToolStripMenuItem
            // 
            this.resetSettingsToDefaultsToolStripMenuItem.Name = "resetSettingsToDefaultsToolStripMenuItem";
            this.resetSettingsToDefaultsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.resetSettingsToDefaultsToolStripMenuItem.Text = "&Reset Settings to Defaults";
            this.resetSettingsToDefaultsToolStripMenuItem.Click += new System.EventHandler(this.resetSettingsToDefaultsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aircraftDataToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // aircraftDataToolStripMenuItem
            // 
            this.aircraftDataToolStripMenuItem.CheckOnClick = true;
            this.aircraftDataToolStripMenuItem.Name = "aircraftDataToolStripMenuItem";
            this.aircraftDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aircraftDataToolStripMenuItem.Text = "&Aircraft Data";
            this.aircraftDataToolStripMenuItem.Click += new System.EventHandler(this.aircraftDataToolStripMenuItem_Click);
            // 
            // virtualFlightOnlineToolStripMenuItem
            // 
            this.virtualFlightOnlineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whoIsOnlineToolStripMenuItem,
            this.toolStripMenuItem1,
            this.websiteToolStripMenuItem,
            this.discordServerToolStripMenuItem,
            this.facebookGroupToolStripMenuItem});
            this.virtualFlightOnlineToolStripMenuItem.Name = "virtualFlightOnlineToolStripMenuItem";
            this.virtualFlightOnlineToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.virtualFlightOnlineToolStripMenuItem.Text = "&VirtualFlight.Online";
            // 
            // whoIsOnlineToolStripMenuItem
            // 
            this.whoIsOnlineToolStripMenuItem.Name = "whoIsOnlineToolStripMenuItem";
            this.whoIsOnlineToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.whoIsOnlineToolStripMenuItem.Text = "Who is &Online?";
            this.whoIsOnlineToolStripMenuItem.Click += new System.EventHandler(this.whoIsOnlineToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.websiteToolStripMenuItem.Text = "Visit &Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // facebookGroupToolStripMenuItem
            // 
            this.facebookGroupToolStripMenuItem.Name = "facebookGroupToolStripMenuItem";
            this.facebookGroupToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.facebookGroupToolStripMenuItem.Text = "Visit &Facebook Group";
            this.facebookGroupToolStripMenuItem.Click += new System.EventHandler(this.facebookGroupToolStripMenuItem_Click);
            // 
            // discordServerToolStripMenuItem
            // 
            this.discordServerToolStripMenuItem.Name = "discordServerToolStripMenuItem";
            this.discordServerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.discordServerToolStripMenuItem.Text = "Visit &Discord Server";
            this.discordServerToolStripMenuItem.Click += new System.EventHandler(this.discordServerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewHelpToolStripMenuItem.Text = "&View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "&Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ssMain
            // 
            this.ssMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMain});
            this.ssMain.Location = new System.Drawing.Point(0, 224);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(428, 22);
            this.ssMain.TabIndex = 5;
            this.ssMain.Text = "...";
            // 
            // tsslMain
            // 
            this.tsslMain.Name = "tsslMain";
            this.tsslMain.Size = new System.Drawing.Size(16, 17);
            this.tsslMain.Text = "...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 246);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.gbUserInfo);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.gbAircraftData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MaximumSize = new System.Drawing.Size(444, 540);
            this.MinimumSize = new System.Drawing.Size(444, 285);
            this.Name = "frmMain";
            this.Text = "VirtualFlight.Online Transmitter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.gbAircraftData.ResumeLayout(false);
            this.gbAircraftData.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lbCallsign;
        private System.Windows.Forms.Label lbPilotName;
        private System.Windows.Forms.TextBox tbPilotName;
        private System.Windows.Forms.TextBox tbCallsign;
        private System.Windows.Forms.GroupBox gbAircraftData;
        private System.Windows.Forms.Label lbAirspeed;
        private System.Windows.Forms.Label lbAltitude;
        private System.Windows.Forms.TextBox tbAirspeed;
        private System.Windows.Forms.TextBox tbAltitude;
        private System.Windows.Forms.TextBox tbLatitude;
        private System.Windows.Forms.TextBox tbLongitude;
        private System.Windows.Forms.Label lbLatitude;
        private System.Windows.Forms.Label lbLongitude;
        private System.Windows.Forms.Label lbHeading;
        private System.Windows.Forms.TextBox tbHeading;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label lbGroupName;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslMain;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.Label lbGroundspeed;
        private System.Windows.Forms.TextBox tbGroundspeed;
        private ToolStripMenuItem transmitterToolStripMenuItem;
        private ToolStripMenuItem virtualFlightOnlineToolStripMenuItem;
        private ToolStripMenuItem websiteToolStripMenuItem;
        private ToolStripMenuItem facebookGroupToolStripMenuItem;
        private ToolStripMenuItem discordServerToolStripMenuItem;
        private ToolStripMenuItem resetSettingsToDefaultsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem whoIsOnlineToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private Label lbNotes;
        private TextBox tbNotes;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem aircraftDataToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private Label lbTouchdownVelocity;
        private TextBox tbTouchdownVelocity;
        private Label lbAircraftType;
        private TextBox tbAircraftType;
    }
}

