using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aes
{
    public partial class FormAes : Form
    {
        public FormAes()
        {
            InitializeComponent();
        }

        private byte[] readHexString(string s)
        {
            int size = s.Length / 2;
            byte[] b = new byte[size];

            if ((size != 16) && (size != 24) && (size != 32))
            {
                throw new Exception();
            }

            for (int i = 0; i < size; i++)
            {
                b[i] = Convert.ToByte(s.Substring(2 * i, 2), 16);
            }
            return (b);
        }

        private byte[] readAsciiString(string s)
        {
            byte[] b = new byte[s.Length];
            b = Encoding.ASCII.GetBytes(s);
            return (b);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            byte[] inputKey = readHexString(tbKey.Text);
            Key key = new Key(inputKey);
            Console.Out.WriteLine("\nkey:\n" + key);

            byte[] inputPlain = readAsciiString(tbPlain.Text);
            State inputState = new State(inputPlain);
            State shiftedRows = inputState.shiftRows();
            Console.Out.WriteLine("state:\n" + inputState.ToMatrixString());
        }
    }
}
