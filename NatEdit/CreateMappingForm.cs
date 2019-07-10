using Mono.Nat;
using System;
using System.Windows.Forms;

namespace NatEdit
{
    public partial class CreateMappingForm : Form
    {
        readonly Device Device;
        public CreateMappingForm(Device device, MappingItem selected)
        {
            InitializeComponent();

            Device = device;


            var m = selected.Mapping;
            ProtocolComboBox.SelectedItem = m.Protocol.ToString();
            RouterAddrTextBox.Text = m.RouterAddress;
            RouterPortTextBox.Text = m.RouterPort.ToString();
            LocalAddrTextBox.Text = m.LocalAddress;
            LocalPortTextBox.Text = m.LocalPort.ToString();
            DescriptionTextBox.Text = m.Description;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (ProtocolComboBox.SelectedItem == null
               || !Enum.TryParse(ProtocolComboBox.SelectedItem.ToString(), true, out Protocol protocol)
               || !int.TryParse(RouterPortTextBox.Text, out int routerPort)
               || !int.TryParse(LocalPortTextBox.Text, out int localPort))
            {
                MessageBox.Show(this, "Invalid values");
                return;
            }

            var mapping = new Mapping(protocol, RouterAddrTextBox.Text, routerPort,
                LocalAddrTextBox.Text, localPort, DescriptionTextBox.Text, 0);
            await Device.NatDevice.CreatePortMapAsync(mapping);
            Close();
        }
    }
}
