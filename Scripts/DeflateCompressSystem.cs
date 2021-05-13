using System.IO;
using System.IO.Compression;
using System.Text;

namespace Isshi777
{
    /// <summary>
    /// Deflateアルゴリズムによる圧縮・展開処理クラス
    /// </summary>
    public static class DeflateCompressSystem
    {
        #region Compress
        /// <summary>
        /// 文字列の圧縮処理
        /// </summary>
        public static byte[] CompressFromString(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            return Compress(data);
        }

        /// <summary>
        /// 圧縮処理
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
        /// 圧縮データの文字列復元処理
        /// </summary>
        public static string DecompressToString(byte[] data)
        {
            byte[] deComp = Decompress(data);
            return Encoding.UTF8.GetString(deComp);
        }

        /// <summary>
        /// 圧縮データの解凍処理
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
