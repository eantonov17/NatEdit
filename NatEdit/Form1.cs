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
            //MappingsListBox.Enabled = enable;
            //CreateMappingButton.Enabled = enable;

            if (MappingsListBox.Items.Count == 0)
                enable = false;
            //MappingInfoButton.Enabled = enable;
            //RemoveMappingButton.Enabled = enable;
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
                    var mappingItems = new List<MappingItem>();
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
                                foreach (Mapping mapping in mappings)
                                    mappingItems.Add(new MappingItem(mapping));
                                break;

                            default:
                                throw new InvalidOperationException("Unknown NatProtocol {device.NatProtocol}");
                        }

                    // UI controls must be updated on UI thread
                    Invoke((MethodInvoker)delegate
                    {
                        UpdateMappingList(status, mappingItems.ToArray()); // runs on UI thread
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

        private void UpdateMappingList(string status, MappingItem[] mappingItems)
        {
            var count = mappingItems.Length;
            var selected = MappingsListBox.SelectedItem as MappingItem;
            var topVisible = MappingsListBox.TopIndex;
            var items = MappingsListBox.Items;

            MappingsListBox.BeginUpdate();

            items.Clear();
            if (count > 0)
            {
                items.AddRange(mappingItems);
                if (selected != null)
                    for (int i = 0; i < count; ++i)
                        if (selected.Equals(items[i] as MappingItem))
                        {
                            MappingsListBox.SelectedIndex = i;
                            break;
                        }
                MappingsListBox.TopIndex = topVisible < count ? topVisible : count - 1;
            }

            MappingsListBox.EndUpdate();
            MappingsLabel.Text = status;
            MappingUpdateLabel.Text = $"{DateTime.Now}: mappings discovery completed";
        }

        private void DevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device = DevicesComboBox.SelectedItem as Device;
            MappingsListBox.Items.Clear();
            MappingsLabel.Text = "Waiting for mappings discovery...";
            MappingUpdateLabel.Text = $"{DateTime.Now}: started mappings discovery";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            doUpdateMappings = false;
            base.OnFormClosing(e);
        }

        private async void DeleteMappingButton_Click(object sender, EventArgs e)
        {
            if (Device == null || !(MappingsListBox.SelectedItem is MappingItem selected))
                return;

            var res = MessageBox.Show(this, $"Are you sure you want to delete this mapping?\n{selected}",
                "Delete mapping", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (res == DialogResult.OK)
                await Device.NatDevice.DeletePortMapAsync(selected.Mapping).ConfigureAwait(false);
        }
    }
}
