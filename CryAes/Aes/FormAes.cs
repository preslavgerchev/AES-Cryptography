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

            byte[] inputPlain = readAsciiString(tbPlain.Text);
            string encryptedMsg = EncryptMessage(inputPlain, key);
            textBox1.Text = encryptedMsg;
        }
        public static string EncryptMessage(byte[] inputPlain,Key k)
        {
            State inputState = new State(inputPlain);
            inputState = inputState.addRoundKey(k, 0);
            for (int i = 1; i <10; i++)
            {
                inputState = inputState.subBytes();
                inputState = inputState.shiftRows();
                inputState = inputState.mixColumns();
                inputState = inputState.addRoundKey(k, i);
            }
            inputState = inputState.subBytes();
            inputState = inputState.shiftRows();
            inputState = inputState.addRoundKey(k, 10);
            Console.Out.WriteLine(inputState.ToMatrixString());
            return inputState.ToString();
        }

        public static string DecryptMessage(byte[] inputPlain, Key k)
        {
            State outputState = new State(inputPlain);
            outputState = outputState.addRoundKey(k, 10);

            for (int i = 9; i > 0; i--)
            {
                outputState = outputState.shiftRowsInv();
                outputState = outputState.subBytesInv();
                outputState = outputState.addRoundKey(k, i);
                outputState = outputState.mixColumnsInv();

            }
            outputState = outputState.shiftRowsInv();
            outputState = outputState.subBytesInv();
            outputState = outputState.addRoundKey(k, 0);
            Console.Out.WriteLine("FINAL");
            Console.Out.WriteLine(outputState.ToMatrixString());
            return outputState.ToString();
        }

        public string ConvertHex(String hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            byte[] inputPlain = StringToByteArray(msg);
            byte[] inputKey = readHexString(tbKey.Text);
            Key key = new Key(inputKey);
            string decryptedMsg = DecryptMessage(inputPlain, key);
            string da = ConvertHex(decryptedMsg);
            textBox2.Text = da;
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
