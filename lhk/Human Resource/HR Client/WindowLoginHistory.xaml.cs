using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//-- IDisposable -- Start -->
using System.ComponentModel;
//-- IDisposable -- End -->
//-- Remove Window Icon -- Start -->
using System.Windows.Interop;
using System.Runtime.InteropServices;
//-- Remove Window Icon -- End -->

namespace HR_Client
{
    /// <summary>
    /// Interaction logic for WindowLoginHistory.xaml
    /// </summary>
    public partial class WindowLoginHistory : IDisposable
    {
        //-- Remove Window Icon -- Start -->
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        const int GWL_EXSTYLE = -20,
            WS_EX_DLGMODALFRAME = 0x0001,
            SWP_NOSIZE = 0x0001,
            SWP_NOMOVE = 0x0002,
            SWP_NOZORDER = 0x0004,
            SWP_FRAMECHANGED = 0x0020;
        const uint WM_SETICON = 0x0080;
        //-- Remove Window Icon -- End -->

        //-- IDisposable -- Start -->
        private IntPtr handle; // Pointer to an external unmanaged resource.
        private Component component = new Component(); // Other managed resource this class uses.
        private bool disposed = false; // Track whether Dispose has been called.

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to take this object off the finalization queue
            // and prevent finalization code for this object from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly or indirectly by a user's code.
        // Managed and unmanaged resources can be disposed.
        // If disposing equals false, the method has been called by the runtime from inside the finalizer
        // and you should not reference other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources.
                if (disposing)
                {
                    component.Dispose(); // Dispose managed resources.
                }
                // Call the appropriate methods to clean up unmanaged resources here.
                // If disposing is false, only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true; // Note disposing has been done.
            }
        }

        // Use interop to call the method necessary to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~WindowLoginHistory() //--> Change to Object Name
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            Dispose(false);
        }
        //-- IDisposable -- End -->
        //-- Remove Window Icon -- Start -->
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Get this window's handle
            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            // Change the extended window style to not show a window icon
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_DLGMODALFRAME);

            // Update the window's non-client area to reflect the changes
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
        }
        //-- Remove Window Icon -- End -->

        public WindowLoginHistory(int Type)
        {
            InitializeComponent();
            switch (Type)
            {
                case 1:
                    labelTimeRange.Content = "Today";
                    break;
                case 2:
                    labelTimeRange.Content = "This Month";
                    break;
                case 3:
                    labelTimeRange.Content = "Last Month";
                    break;
                default:
                    labelTimeRange.Content = "Out of range";
                    break;
            }
            FetchHistory(Type);
        }

        private void FetchHistory(int Type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Time In", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            dt.Rows.Add("Hello", "World");
            DataGridHistory.DataSource = dt;
            DataGridHistory.ColumnHeadersVisible = true;
            DataGridHistory.RowHeadersVisible = false;
            DataGridHistory.ReadOnly = true;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
