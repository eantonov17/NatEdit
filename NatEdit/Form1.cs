using Mono.Nat;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace NatEdit
{
    public partial class Form1 : Form
    {
        Device Device = null;
        bool doUpdateMappings = true;

        public Form1()
        {
            InitializeComponent();

            new Thread(UpdateMappings) { IsBackground = true }.Start();

            DeviceDiscoveryLabel.Text = $"{DateTime.Now}: device discovery started";

            NatUtility.DeviceFound += DeviceFound;
            NatUtility.DeviceLost += DeviceLost;
            NatUtility.StartDiscovery();
        }

        private void DeviceFound(object sender, DeviceEventArgs e) => InvokeUpdateDeviceList(e.Device, true);

        private void DeviceLost(object sender, DeviceEventArgs e) => InvokeUpdateDeviceList(e.Device, false);

        private void InvokeUpdateDeviceList(INatDevice device, bool found)
        {
            // UI controls must be updated on UI thread
            Invoke((MethodInvoker)delegate
            {
                UpdateDeviceList(new Device(device), found); // runs on UI thread
            });
        }

        private void UpdateDeviceList(Device device, bool found)
        {
            if (found)
            {
                DevicesComboBox.Items.Add(device);
                DeviceDiscoveryLabel.Text = $"{DateTime.Now}: Found device {device}";
            }
            else
            {
                DevicesComboBox.Items.Remove(device);
                DeviceDiscoveryLabel.Text = $"{DateTime.Now}: Lost device {device}";
            }

            var deviceCount = DevicesComboBox.Items.Count;
            if (DevicesComboBox.SelectedIndex == -1)
                DevicesComboBox.SelectedIndex = 0;

            MappingsListBox.Items.Clear();
            switch (deviceCount)
            {
                case 0: DevicesLabel.Text = "No device found"; EnableMappingButtons(false); return;
                case 1: DevicesLabel.Text = "1 device found"; break;
                default: DevicesLabel.Text = $"{deviceCount} devices found"; break;
            }
            EnableMappingButtons(true);
        }

        private void EnableMappingButtons(bool enable)
        {
            MappingsListBox.Enabled = enable;
            CreateMappingButton.Enabled = enable;

            if (MappingsListBox.Items.Count == 0)
                enable = false;
            MappingInfoButton.Enabled = enable;
            RemoveMappingButton.Enabled = enable;
        }

        private void UpdateMappings()
        {
            int maxExceptionReports = 100;
            while (doUpdateMappings)
                try
                {
                    Thread.Sleep(5000);
                    var device = Device?.NatDevice;
                    string status = "No device found";
                    var mappingInfo = new List<string>();
                    if (device != null)
                        switch (device.NatProtocol)
                        {
                            case NatProtocol.Pmp:
                                status = "Pmp devices don't support GetAllMappings.";
                                break;

                            case NatProtocol.Upnp:
                                var mappings = device.GetAllMappings();
                                if (mappings.Length == 0)
                                {
                                    status = "No existing UPnP mappings found.";
                                    break;
                                }
                                status = "UPnP mappings:";
                                foreach (Mapping mp in mappings)
                                    mappingInfo.Add($"{mp.Protocol}://:{mp.PublicPort} -> :{mp.PrivatePort}, {mp.Description}");
                                break;

                            default:
                                throw new InvalidOperationException("Unknown NatProtocol {device.NatProtocol}");
                        }

                    // UI controls must be updated on UI thread
                    Invoke((MethodInvoker)delegate
                    {
                        UpdateMappingList(status, mappingInfo.ToArray()); // runs on UI thread
                    });
                }
                catch (ThreadAbortException)
                { break; }
                //catch (InvalidOperationException)
                //{ throw; }
                catch (Exception x)
                {
                    if (maxExceptionReports > 0) // avoid self-flooding in case of a disaster/permanent error
                    {
                        --maxExceptionReports;
                        System.Diagnostics.Debug.WriteLine(x.ToString());
                    }
                }
        }

        private void UpdateMappingList(string status, string[] mappingInfo)
        {
            MappingsLabel.Text = status;
            MappingsListBox.BeginUpdate();
            MappingsListBox.Items.Clear();
            MappingsListBox.Items.AddRange(mappingInfo);
            if (mappingInfo.Length > 0)
                MappingsListBox.SelectedIndex = 0;
            MappingsListBox.EndUpdate();
            MappingUpdateLabel.Text = $"{DateTime.Now}: mapping updated";
        }

        private void DevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device = DevicesComboBox.SelectedItem as Device;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            doUpdateMappings = false;
            base.OnFormClosing(e);
        }
    }
}
