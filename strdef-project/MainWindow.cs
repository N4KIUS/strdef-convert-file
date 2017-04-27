using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strdef_project
{


    /// <summary>
    /// Estrutura do arquivo 'strdef.bin'
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Ansi)]
    public struct _STRUCT_STRDEF_FILE_
    {
        private const int MAX_STRING_TABLE = 2000;
        private const int MAX_STRING_VALUE = 128;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_STRING_TABLE)]
        public STRUCT_STRDEF[] Message;

        /* Marshal Hack */
        public struct STRUCT_STRDEF
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_VALUE)]
            public string Value;
        }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_VALUE)]
        public string LastValue;

        public static _STRUCT_STRDEF_FILE_ ClearProperty()
        {
            _STRUCT_STRDEF_FILE_ Rise = new _STRUCT_STRDEF_FILE_();

            Rise.Message = new STRUCT_STRDEF[MAX_STRING_TABLE];

            return Rise;
        }
    }

    public partial class MainWindow : Form
    {
        private const string Folder = @"strdef\";

        public MainWindow()
        {
            InitializeComponent();

            CheckOrCreateNewFolder();
        }

        /// <summary>
        /// Cria uma nova pasta se não existir
        /// </summary>
        private void CheckOrCreateNewFolder()
        {
            if (Directory.Exists(Folder) == false)
            {
                Directory.CreateDirectory(Folder);
            }
        }
        private void bin2txt_Click(object sender, EventArgs e)
        {
            string Patch = Folder + "strdef.bin";

            if (File.Exists(Patch) == false)
            {
                MessageBox.Show("O arquivo 'strdef.bin' não existe.", "Erro");

                return;
            }

            byte[] pBuffer = File.ReadAllBytes(Patch);

            if (pBuffer == null)
            {
                throw new Exception("O arquivo strdef.bin tem um buffer inválido.");
            }

            unsafe
            {
                fixed (byte* ptr = pBuffer)
                {
                    for (int i = 0; i < pBuffer.Length; i++)
                    {
                        ptr[i] = (byte)(ptr[i] ^ 0x5A);
                    }
                }
            }

            _STRUCT_STRDEF_FILE_ Select = Decrypt<_STRUCT_STRDEF_FILE_>(pBuffer);

            string[] Content = new string[Select.Message.Length];

            for (int i = 0; i < Select.Message.Length; i++)
            {
                Content[i] = Select.Message[i].Value;
            }

            File.WriteAllLines(Folder+"strdef.txt", Content);

            MessageBox.Show("O arquivo 'strdef.bin' foi convertido para 'strdef.txt' com sucesso.", "Informação");
        }

        /// <summary>
        /// Decripta a estrutura do arquivo
        /// </summary>
        /// <typeparam name="T">Objeto (estrutura)</typeparam>
        /// <param name="_buffer">Buffer do arquivo</param>
        /// <returns></returns>
        private unsafe T Decrypt<T>(byte[] _buffer)
        {
            fixed (byte* Pointer = _buffer)
            {
                return (T)Marshal.PtrToStructure(new IntPtr(Pointer), typeof(T));
            }
        }

        /// <summary>
        /// Encripta a estrutura para o arquivo
        /// </summary>
        /// <typeparam name="T">Objeto (estrutura)</typeparam>
        /// <param name="obj">Objeto a ser transformado</param>
        /// <returns>Retorna o buffer em ponteiro</returns>
        public static unsafe byte[] Encrypt<T>(T obj)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];

            fixed (byte* Pointer = buffer)
            {
                Marshal.StructureToPtr<T>(obj, new IntPtr(Pointer), false);
            }

            return buffer;
        }

        private void txt2bin_Click(object sender, EventArgs e)
        {
            string Patch = Folder + "strdef.txt";

            if (File.Exists(Patch) == false)
            {
                MessageBox.Show("O arquivo 'strdef.txt' não existe.", "Erro");

                return;
            }

            _STRUCT_STRDEF_FILE_ Reading = _STRUCT_STRDEF_FILE_.ClearProperty();

            string[] Content = File.ReadAllLines(Patch);

            for (int i = 0; i < Reading.Message.Length; i++)
            {
                Reading.Message[i].Value = Content[i];
            }

            byte[] pBuffer = Encrypt(Reading);

            unsafe
            {
                fixed (byte* ptr = pBuffer)
                {
                    for (int i = 0; i < pBuffer.Length; i++)
                    {
                        ptr[i] = (byte)(ptr[i] ^ 0x5A);
                    }
                }
            }

            File.WriteAllBytes(Folder + "strdef.bin", pBuffer);

            MessageBox.Show("O arquivo 'strdef.txt' foi convertido para 'strdef.bin' com sucesso.", "Informação");
        }
    }
}
