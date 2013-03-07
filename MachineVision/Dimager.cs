
namespace MachineVision
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    public class Dimager
    {
        #region DLL function decralation

        [DllImport("Dimagerdll.dll")]
        public static extern int InitImageDriver();

        [DllImport("Dimagerdll.dll")] 
        public static extern int Speedmode();

        [DllImport("Dimagerdll.dll")]
        public static extern int Freqmode();

        [DllImport("Dimagerdll.dll")]
        public static extern int FreeImageDriver();

        [DllImport("Dimagerdll.dll")]
        public static extern int GetImageKN
            ([MarshalAs(UnmanagedType.LPArray)] ushort[] kdat, [MarshalAs(UnmanagedType.LPArray)] ushort[] ndat);

        #endregion

        #region fields

        /// <summary>
        /// the range image data acquiring buffer.
        /// </summary>
        public ushort[] kdat;
        
        /// <summary>
        /// the grayscale image data acquiring buffer.
        /// </summary>
        public ushort[] ndat;
        
        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public Dimager() 
        {
            this.kdat = new ushort[160 * 120];
            this.ndat = new ushort[160 * 120];
        }
        
        #endregion

        #region Methods

        public int D_InitImageDriver()
        {
            int value = InitImageDriver();
            return value;
        }

        public int D_Speedmode()
        {
            int value = Speedmode();
            return value;
        }

        public int D_Freqmode()
        {
            int value = Freqmode();
            return value;
        }

        public int D_FreeImageDriver()
        {
            int value = FreeImageDriver();
            return value;
        }

        public int D_GetImageKN()
        {
            this.kdat.Initialize();
            this.ndat.Initialize();

            int value = GetImageKN(this.kdat, this.ndat);
            return value;
        }

        #endregion
    }
}
