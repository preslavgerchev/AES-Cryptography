using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aes
{
    public partial class FormAes : Form
    {
        private string key128 = "11223344556677889900aabbccddeeff";
        private string key192 = "11223344556677889900aabbccddeeff1122334455667788";
        private string key256 = "11223344556677889900aabbccddeeff11223344556677889900aabbccddeeff";
        private int nrOfIterations = 10;

        public FormAes()
        {
            InitializeComponent();
            this.cbKeyLength.SelectedIndex = 0;
            this.cbKeyLength.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbKeyLength.SelectedIndex)
            {
                case 0:
                    tbKey.Text = key128;
                    nrOfIterations = 10;
                    break;
                case 1:
                    tbKey.Text = key192;
                    nrOfIterations = 12;
                    break;
                case 2:
                    tbKey.Text = key256;
                    nrOfIterations = 14;
                    break;
            }
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

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            byte[] inputKey = readHexString(tbKey.Text);
            Key key = new Key(inputKey);
            byte[] inputPlain = readAsciiString(tbPlain.Text);
            string encryptedMsg = EncryptMessage(inputPlain, key, nrOfIterations);
            tbCipher.Text = encryptedMsg;
            tbPlain.Text = String.Empty;
        }

        public static string EncryptMessage(byte[] inputPlain, Key k, int nrOfIterations)
        {
            State inputState = new State(inputPlain);
            inputState = inputState.addRoundKey(k, 0);
            for (int i = 1; i < nrOfIterations; i++)
            {
                inputState = inputState.subBytes();
                inputState = inputState.shiftRows();
                inputState = inputState.mixColumns();
                inputState = inputState.addRoundKey(k, i);
            }
            inputState = inputState.subBytes();
            inputState = inputState.shiftRows();
            inputState = inputState.addRoundKey(k, nrOfIterations);
            Console.Out.WriteLine(inputState.ToMatrixString());
            return inputState.ToString();
        }

        public static string DecryptMessage(byte[] inputPlain, Key k, int nrOfIterations)
        {
            State outputState = new State(inputPlain);
            outputState = outputState.addRoundKey(k, nrOfIterations);

            for (int i = nrOfIterations - 1; i > 0; i--)
            {
                outputState = outputState.shiftRowsInv();
                outputState = outputState.subBytesInv();
                outputState = outputState.addRoundKey(k, i);
                outputState = outputState.mixColumnsInv();

            }
            outputState = outputState.shiftRowsInv();
            outputState = outputState.subBytesInv();
            outputState = outputState.addRoundKey(k, 0);
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

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string testMsg = "12345689abcdefgh";
            byte[] test = readAsciiString(testMsg);
            State s = new State(test);
            s = s.subBytesInv();
            Console.Out.WriteLine("TEST STATE");
            Console.Out.WriteLine(s.ToMatrixString());
            string msg = tbCipher.Text;
            byte[] inputPlain = HexStringToByteArray(msg);
            byte[] inputKey = readHexString(tbKey.Text);
            Key key = new Key(inputKey);
            string decryptededMsgHex = DecryptMessage(inputPlain, key, nrOfIterations);
            string plainMsg = ConvertHex(decryptededMsgHex);
            tbPlain.Text = plainMsg;
            tbCipher.Text = String.Empty;
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}