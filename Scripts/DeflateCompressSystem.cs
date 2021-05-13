using System.IO;
using System.IO.Compression;
using System.Text;

namespace Isshi777
{
    /// <summary>
    /// Deflate�A���S���Y���ɂ�鈳�k�E�W�J�����N���X
    /// </summary>
    public static class DeflateCompressSystem
    {
        #region Compress
        /// <summary>
        /// ������̈��k����
        /// </summary>
        public static byte[] CompressFromString(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            return Compress(data);
        }

        /// <summary>
        /// ���k����
        /// </summary>
        public static byte[] Compress(byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Compress, true))
                {
                    ds.Write(data, 0, data.Length);
                }

                ms.Position = 0;
                byte[] comp = new byte[ms.Length];
                ms.Read(comp, 0, comp.Length);
                return comp;
            }
        }
        #endregion Compress

        #region Decompress

        /// <summary>
        /// ���k�f�[�^�̕����񕜌�����
        /// </summary>
        public static string DecompressToString(byte[] data)
        {
            byte[] deComp = Decompress(data);
            return Encoding.UTF8.GetString(deComp);
        }

        /// <summary>
        /// ���k�f�[�^�̉𓀏���
        /// </summary>
        public static byte[] Decompress(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    using (var dest = new MemoryStream())
                    {
                        ds.CopyTo(dest);
                        dest.Position = 0;
                        byte[] deComp = new byte[dest.Length];
                        dest.Read(deComp, 0, deComp.Length);
                        return deComp;
                    }
                }
            }
        }

        #endregion Decompress
    }
}
