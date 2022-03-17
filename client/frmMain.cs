using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CTrue.FsConnect;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Media;

namespace VirtualFlightOnlineTransmitter
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// Event handler to capture data received from SimConnect
        /// </summary>
        /// <param name="latitude">Aircraft Latitude</param>
        /// <param name="longitude">Aircraft Longitude</param>
        /// <param name="alititude">Aircraft Altitude</param>
        /// <param name="heading">Aircraft Heading</param>
        /// <param name="airspeed">Aircraft Airspeed</param>
        /// <param name="groundspeed">Aircraft Groundspeed</param>
        public delegate void DataReceivedEventHandler(string aircraft_type, double latitude, double longitude, double alititude, double heading, double airspeed, double groundspeed, double touchdown_velocity);
        public event DataReceivedEventHandler DataReceivedEvent;


        /// <summary>
        /// FSConnect library to communicate with the flight simulator
        /// </summary>
        public FsConnect FlightSimulatorConnection = new FsConnect();


        /// <summary>
        ///  Control variables used to manage connections with FSConnect
        /// </summary>
        public int planeInfoDefinitionId { get; set; }
        public enum Requests
        {
            PlaneInfoRequest = 0
        }


        /// <summary>
        /// Function to convert decoman to lat lon
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        string LongitudeToString(double val)
        {
            int d = (int)val;
            int m = (int)((val - d) * 60);
            double s = ((((val - d) * 60) - m) * 60);
            
            return Math.Abs(d) + "° " + Math.Abs(m) + "' " + string.Format("{0:0.00}", Math.Abs(s)) + "\" " + (val > 0 ? "E" : "W");
        }

        string LatitudeToString(double val)
        {
            int d = (int)val;
            int m = (int)((val - d) * 60);
            double s = ((((val - d) * 60) - m) * 60);

            return Math.Abs(d) + "° " + Math.Abs(m) + "' " + string.Format("{0:0.00}", Math.Abs(s)) + "\" " + (val > 0 ? "N" : "S");
        }

        /// <summary>
        /// Time the connection to the simulator started (used to calculate how long the user has been connected)
        /// </summary>
        public DateTime ConnectionStartTime { get; set; }


        /// <summary>
        /// Data structure used to receive information from SimConnect
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct PlaneInfoResponse
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String Title;
            [SimVar(NameId = FsSimVar.PlaneLatitude, UnitId = FsUnit.Degree)]
            public double PlaneLatitude;
            [SimVar(NameId = FsSimVar.PlaneLongitude, UnitId = FsUnit.Degree)]
            public double PlaneLongitude;
            [SimVar(NameId = FsSimVar.IndicatedAltitude, UnitId = FsUnit.Feet)]
            public double IndicatedAltitude;
            [SimVar(NameId = FsSimVar.GpsPositionAlt, UnitId = FsUnit.Meter)]
            public double GpsPositionAlt;
            [SimVar(NameId = FsSimVar.PlaneAltitude, UnitId = FsUnit.Feet)]
            public double PlaneAltitude;
            [SimVar(NameId = FsSimVar.PlaneHeadingDegreesTrue, UnitId = FsUnit.Degree)]
            public double PlaneHeadingDegreesTrue;
            [SimVar(NameId = FsSimVar.PlaneHeadingDegreesMagnetic, UnitId = FsUnit.Degree)]
            public double PlaneHeadingDegreesMagnetic;
            [SimVar(NameId = FsSimVar.AirspeedIndicated, UnitId = FsUnit.Knot)]
            public double AirspeedIndicated;
            [SimVar(NameId = FsSimVar.GpsGroundSpeed, UnitId = FsUnit.MetersPerSecond)]
            public double GpsGroundSpeed;
            [SimVar(NameId = FsSimVar.PlaneTouchdownNormalVelocity, UnitId = FsUnit.FeetPerSecond)]
            public double PlaceTouchdownNormalVelocity;
        }


        /// <summary>
        /// Handler to receive information from SimConnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            if (e.RequestId == (uint)Requests.PlaneInfoRequest)
            {
                PlaneInfoResponse r = (PlaneInfoResponse)e.Data.FirstOrDefault();

                string aircraft_type = r.Title;
                double latitude = r.PlaneLatitude;
                double longitude = r.PlaneLongitude;
                double altitude = r.IndicatedAltitude;
                double heading = r.PlaneHeadingDegreesTrue;
                double airspeed = r.AirspeedIndicated;
                double groundspeed = r.GpsGroundSpeed;
                double touchdown_velocity = r.PlaceTouchdownNormalVelocity;

                this.DataReceivedEvent(aircraft_type,latitude, longitude, altitude, heading, airspeed, groundspeed, touchdown_velocity);

            }
        }


        /// <summary>
        /// Sends aircraft data to the web server
        /// </summary>
        /// <param name="latitude">Aircraft Latitude</param>
        /// <param name="longitude">Aircraft Longitude</param>
        /// <param name="heading">Aircraft Heading</param>
        /// <param name="altitude">Aircraft Altitude</param>
        /// <param name="airspeed">Aircraft Airspeed</param>
        /// <returns>Response from GET request to Server</returns>
        public string SendDataToServer(string aircraft_type, double latitude, double longitude, double heading, double altitude, double airspeed, double groundspeed, double touchdown_velocity, string notes, string version)
        {
            string result = "";

            
            try
            {
                // force the numbers into USA format
                CultureInfo usa_format = new CultureInfo("en-US");

                string url = Properties.Settings.Default["ServerURL"].ToString()
                    + "?Callsign=" + Properties.Settings.Default["Callsign"].ToString()
                    + "&PilotName=" + Properties.Settings.Default["PilotName"].ToString()
                    + "&GroupName=" + Properties.Settings.Default["GroupName"].ToString()
                    + "&AircraftType=" + aircraft_type.ToString()
                    + "&Latitude=" + latitude.ToString(usa_format)
                    + "&Longitude=" + longitude.ToString(usa_format)
                    + "&Altitude=" + altitude.ToString(usa_format)
                    + "&Airspeed=" + airspeed.ToString(usa_format)
                    + "&Groundspeed=" + groundspeed.ToString(usa_format)
                    + "&Heading=" + heading.ToString(usa_format)
                    + "&TouchdownVelocity=" + touchdown_velocity.ToString(usa_format)
                    + "&Version=" + version
                    + "&Notes=" + System.Net.WebUtility.UrlEncode(notes);
                            
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 1000; // 1 second
                
                using (var webResponse = request.GetResponse())
                {
                    using (var webStream = webResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(webStream))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            
            } catch
            {
                // do nothing 
            }
                        
            return result;

        }


        /// <summary>
        /// Constructor for the Form
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            // Disable illegal cross thread calls warnings
            Control.CheckForIllegalCrossThreadCalls = false;

            // Attach an event reveiver to the data received event
            this.DataReceivedEvent += HandleDataReceived;
        }


        /// <summary>
        /// Handle clicks on the Connect button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.FlightSimulatorConnection.Connected)
            {
                // we are connected - label the button Disconnect
                Disconnect(string.Empty);

            } else { 
                // we are NOT connected - label the button Connecting
                // (receiving data will mark it as Connected if it isnt already)
                Connect();
            }
        }


        /// <summary>
        /// Handle the Timer control ticking (orchestrating communication with FSConnect, and laterly the web server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (this.FlightSimulatorConnection.Connected)
            {

                // Call the Simulator to fetch data
                try
                {
                    this.FlightSimulatorConnection.RequestData((int)Requests.PlaneInfoRequest, this.planeInfoDefinitionId);
                } catch
                {
                    // problems
                    Disconnect("Problem connecting to simulator (is it running?)");
                }

            } else
            {
                // not connected!
                Disconnect("Connection lost with simulator");
            }
        }


        /// <summary>
        /// Event Handler to handle data returning from the simulator
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="altitude"></param>
        /// <param name="heading"></param>
        /// <param name="airspeed"></param>
        public void HandleDataReceived(string aircraft_type, double latitude, double longitude, double altitude, double heading, double airspeed, double groundspeed, double touchdown_velocity)
        {

            // convert ground speed from metres per second to knots
            groundspeed = groundspeed * 1.94384449;

            // Update the Screen   
            this.tbAircraftType.Text = aircraft_type;
            this.tbLatitude.Text = LatitudeToString(latitude); // string.Format("{0:0.000000000000}", latitude);
            this.tbLongitude.Text = LongitudeToString(longitude); // string.Format("{0:0.000000000000}", longitude);
            this.tbAltitude.Text = string.Format("{0:0. ft}", altitude);
            this.tbHeading.Text = string.Format("{0:0. deg}", heading);
            this.tbAirspeed.Text = string.Format("{0:0. knots}", airspeed);
            this.tbGroundspeed.Text = string.Format("{0:0. knots}", groundspeed);
            this.tbTouchdownVelocity.Text = string.Format("{0:0. ft/min}", touchdown_velocity * 60);

            string version = System.Windows.Forms.Application.ProductVersion;

            // Transmit data to web
            try
            {
                // get notes from the textbox
                string notes = tbNotes.Text;

                // send the data to the server and get the response back
                string response_data = this.SendDataToServer(aircraft_type, latitude,longitude,heading,altitude,airspeed,groundspeed,touchdown_velocity, notes,version);

                // if the button is not Disconnect, make it Disconnect
                if (btnConnect.Text != "Disconnect")
                {
                    btnConnect.Text = "Disconnect";
                    btnConnect.ForeColor = Color.Green;
                }
                tsslMain.Text = "Connected for " + DateTime.Now.Subtract(this.ConnectionStartTime).ToString(@"hh\:mm\:ss");

            }
            catch
            {
                // problems
                Disconnect("Problem sending data to the server");
            }
        }


        /// <summary>
        /// Handle closing of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the simulator is connected, ask the user if they really want to close Transmitter
            if (this.FlightSimulatorConnection.Connected)
            {
                DialogResult result = MessageBox.Show("Transmitter is still connected to the simulator - are you sure you want to close it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // disconnect from the simulator
                    this.Disconnect(string.Empty);
                } else {
                    // cancel the form closure
                    e.Cancel = true;
                }
            }
        }


        /// <summary>
        /// Handle loading the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // pre-fill the settings boxes with data from properties
            tbCallsign.Text = Properties.Settings.Default["Callsign"].ToString();
            tbPilotName.Text = Properties.Settings.Default["PilotName"].ToString();
            tbGroupName.Text = Properties.Settings.Default["GroupName"].ToString();
            tbNotes.Text = Properties.Settings.Default["Notes"].ToString();
            tsslMain.Text = "Version " + System.Windows.Forms.Application.ProductVersion;

            this.CheckForNewVersion();
        }


        // Handle Form Textbox content changes

        private void tbCallsign_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Callsign"] = tbCallsign.Text;
            Properties.Settings.Default.Save();
        }

        private void tbPilotName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["PilotName"] = tbPilotName.Text;
            Properties.Settings.Default.Save();
        }

        private void tbGroupName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["GroupName"] = tbGroupName.Text;
            Properties.Settings.Default.Save();
        }

        private void tbNotes_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Notes"] = tbNotes.Text;
            Properties.Settings.Default.Save();
        }

        // Handle focus leaving textboxes - trim contents to avoid people entering garbage data

        private void tbCallsign_Leave(object sender, EventArgs e)
        {
            tbCallsign.Text = tbCallsign.Text.Trim();
        }

        private void tbPilotName_Leave(object sender, EventArgs e)
        {
            tbPilotName.Text = tbPilotName.Text.Trim();
        }

        private void tbGroupName_Leave(object sender, EventArgs e)
        {
            tbGroupName.Text = tbGroupName.Text.Trim();
        }

        private void tbNotes_Leave(object sender, EventArgs e)
        {
            tbNotes.Text = tbNotes.Text.Trim();
        }


        /// <summary>
        /// Handle users clicking on the About menu option (show a message)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string version = System.Windows.Forms.Application.ProductVersion;
            MessageBox.Show("Transmitter\nby Jonathan Beckett\nVirtual Flight Online\nhttps://virtualflight.online\nVersion " + version, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Handle users clicking on the Help menu option (open the website)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://www.virtualflight.online/transmitter";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }


        /// <summary>
        /// Helper method to connect to SimConnect and update the interface appropriately
        /// </summary>
        private void Connect()
        {

            // first check if the default parameters have been changed
            if (this.tbCallsign.Text == "Your Callsign" || this.tbPilotName.Text == "Your Name")
            {
                btnConnect.Text = "Connect";
                btnConnect.ForeColor = Color.Black;
                MessageBox.Show("It looks like you haven't changed your callsign, name or aircraft type yet. Please change them before connecting.", "Let's do this first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
            else
            {

                btnConnect.Text = "Connecting";
                btnConnect.ForeColor = Color.Orange;

                // check if the parameters are empty
                if (tbCallsign.Text != string.Empty && tbPilotName.Text != string.Empty && tbGroupName.Text != string.Empty)
                {

                    // is the user is not connected
                    if (!this.FlightSimulatorConnection.Connected)
                    {
                        
                        // try to connect
                        try
                        {

                            // Start the timer if it is not already started
                            // - the timer will try to reconnect automatically
                            if (!tmrMain.Enabled)
                            {
                                tmrMain.Start();
                            }

                            // connect to simulator
                            this.FlightSimulatorConnection.Connect("VirtualFlightOnlineClient");

                            this.planeInfoDefinitionId = this.FlightSimulatorConnection.RegisterDataDefinition<PlaneInfoResponse>();

                            // Attach event handler
                            this.FlightSimulatorConnection.FsDataReceived += this.HandleReceivedFsData;

                            // Disable the textboxes
                            tbCallsign.Enabled = false;
                            tbPilotName.Enabled = false;
                            tbGroupName.Enabled = false;

                            // Initialise the connection start time
                            this.ConnectionStartTime = DateTime.Now;

                        }
                        catch
                        {
                            // problem connecting
                            Disconnect("Problem connecting to Simulator (is it running?)");
                        }

                    }

                }
                else
                {
                    // user has not filled in all required parameters
                    Disconnect("Please fill required paramters");
                    MessageBox.Show("You must fill out the Callsign, Pilot Name, Aircraft Type, Group Name, and Server URL", "Please Fill Data Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }
        }


        /// <summary>
        /// Helper method to disconnect from SimConnect and update the interface appropriately
        /// </summary>
        private void Disconnect(string msg)
        {

            // stop the timer
            tmrMain.Stop();

            // if there is a message, play a sound
            if (msg.Length > 0)
            {
                SystemSounds.Exclamation.Play();
                tsslMain.Text = msg;
            } else
            {
                tsslMain.Text = "Not Connected";
            }

            // if we are still connected, disconnect from the simulator
            if (this.FlightSimulatorConnection.Connected) this.FlightSimulatorConnection.Disconnect();

            // setup the connect button to connect again
            btnConnect.Text = "Connect";
            btnConnect.ForeColor = Color.Black;

            // switch the UI components back on
            tbCallsign.Enabled = true;
            tbPilotName.Enabled = true;
            tbGroupName.Enabled = true;
            
        }


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // disconnect if connected
            if (this.FlightSimulatorConnection.Connected) this.FlightSimulatorConnection.Disconnect();

            // close the application
            this.Close();
        }


        private void resetSettingsToDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.FlightSimulatorConnection.Connected)
            {
                tbCallsign.Text = "Your Callsign";
                tbPilotName.Text = "Your Name";
            } else
            {
                MessageBox.Show("Please disconnect from the simulator first", "Disconnect First", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://www.virtualflight.online";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void facebookGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://www.facebook.com/groups/virtualflight.online";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void discordServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://discord.gg/kM6ktr3PuA";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void whoIsOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://virtualflight.online/who.php";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void aircraftDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aircraftDataToolStripMenuItem.Checked)
            {
                this.Height = 540;
            } else
            {
                this.Height = 285;
            }
            
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CheckForNewVersion(true);
        }


        /// <summary>
        /// Compare two version strings - version_a is the version we have, version_b is the available version
        /// therefore if version_b is newers, 
        /// </summary>
        /// <param name="existing_version"></param>
        /// <param name="available_version"></param>
        /// <returns></returns>
        public bool IsAvailableVersionNewer(string existing_version, string available_version)
        {
            int[] existing_parts = Array.ConvertAll(existing_version.Split(".".ToCharArray()), s => int.Parse(s));
            int[] available_parts = Array.ConvertAll(available_version.Split(".".ToCharArray()), s => int.Parse(s));

            bool result = false;

            // can the versions be compared? (they must have the same number of pieces)
            if (existing_parts.Length == available_parts.Length)
            {
                // loop through the parts and compare them
                for (int i = 0; i < existing_parts.Length; i++)
                {
                    if (available_parts[i] > existing_parts[i])
                    {
                        result = true;
                        break;
                    }
                }

            }

            return result;
        }

        public void CheckForNewVersion(bool show_dialog = false)
        {
            try
            {
                var request = WebRequest.Create("https://virtualflight.online/transmitter_version.txt");
                request.Method = "GET";

                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();

                string available_version = data.ToString();
                string this_version = System.Windows.Forms.Application.ProductVersion;

                if (IsAvailableVersionNewer(this_version,available_version))
                {
                    DialogResult dr = MessageBox.Show("A new version of Transmitter is available. Would you like to download it ?", "New Version Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        string target = "https://www.virtualflight.online/transmitter";
                        try
                        {
                            System.Diagnostics.Process.Start(target);
                        }
                        catch (System.ComponentModel.Win32Exception noBrowser)
                        {
                            if (noBrowser.ErrorCode == -2147467259)
                                MessageBox.Show(noBrowser.Message);
                        }
                        catch (System.Exception other)
                        {
                            MessageBox.Show(other.Message);
                        }
                    }
                }
                else
                {
                    if (show_dialog) MessageBox.Show("You are running the latest version.", "Everything Looks Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            } catch (Exception ex)
            {
                MessageBox.Show("There was a problem checking for a new version - " + ex.Message, "A Problem Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
