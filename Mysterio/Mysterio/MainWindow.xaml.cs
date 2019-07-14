using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mysterio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//encripta
        {
            if (!string.IsNullOrEmpty(tbxInformacaoEsconder.Text) && !string.IsNullOrEmpty(tbxSenhaEsconder.Text))
            {
                tbxConteudo.Text = Encyipt.encriptografar(tbxInformacaoEsconder, tbxSenhaEsconder);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//desencripta
        {
            tbxConteudo.Text = Encyipt.encriptografar(tbxInformacaoEsconder, tbxSenhaEsconder);

        }

        public static class Encyipt
        {
            private const string intVector = "gtt87987456ee489fsdg548g5df4hg98eh7th54s";
            private const int keysize = 256;

            public static string encriptografar(string Textoesconder, string senhaEsconder)
            {
                byte[] iniciandoVetorBytes = Encoding.UTF8.GetBytes(intVector);
                byte[] textPLanoBytes = Encoding.UTF8.GetBytes(Textoesconder);

                PasswordDeriveBytes password = new PasswordDeriveBytes(senhaEsconder, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symetricKey = new RijndaelManaged();
                symetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encrypto = symetricKey.CreateEncryptor(keyBytes, iniciandoVetorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypto, CryptoStreamMode.Write);
                cryptoStream.Write(textPLanoBytes, 0, textPLanoBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] textoEmMemoria = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();

                return Convert.ToBase64String(textoEmMemoria);
            }

            private const string intVector = "";
            private const int keysize = 256;

            public static string desencriptografar(string Textoesconder, string senhaEsconder)
            {
                byte[] iniciandoVetorBytes = Encoding.UTF8.GetBytes(intVector);
                byte[] textPLanoBytes = Convert.FromBase64String//Encoding.UTF8.GetBytes(Textoesconder);

                PasswordDeriveBytes password = new PasswordDeriveBytes(senhaEsconder, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symetricKey = new RijndaelManaged();
                symetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encrypto = symetricKey.CreateEncryptor(keyBytes, iniciandoVetorBytes);
                MemoryStream memoryStream = new MemoryStream(textPLanoBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypto, CryptoStreamMode.Read);
                byte[] textoDescriptografado = new byte[textPLanoBytes.Length];
                int descryptoCount = cryptoStream.Read(textoDescriptografado,0, textoDescriptografado.Length);
                memoryStream.Close();
                cryptoStream.Close();

                return Encoding.UTF8.GetString(textoDescriptografado, 0, descryptoCount);
            }
    }
}
