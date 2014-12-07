using System;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class ControlsSamplePageContainer : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style |= WinApi.WS_CLIPSIBLINGS | WinApi.WS_CLIPSIBLINGS;
                return createParams;
            }
        }

        private UserControl _ControlsSamplePage;

        public UserControl ControlsSamplePage
        {
            get { return _ControlsSamplePage; }
            set
            {
                if (_ControlsSamplePage == value)
                    return;

                IntPtr deferWindowPos = IntPtr.Zero;

                if (_ControlsSamplePage != null && value != null)
                    deferWindowPos = WinApi.BeginDeferWindowPos(2);

                try
                {
                    if(_ControlsSamplePage != null)
                    {
                        if(deferWindowPos != IntPtr.Zero)
                        {
                            WinApi.DeferWindowPos(
                                deferWindowPos, _ControlsSamplePage.Handle, IntPtr.Zero, 0, 0, 0, 0,
                                WinApi.SWP_NOMOVE | WinApi.SWP_NOSIZE | WinApi.SWP_NOZORDER | WinApi.SWP_HIDEWINDOW);
                        }

                        _ControlsSamplePage.Visible = false;
                        _ControlsSamplePage.Parent = null;
                    }

                    _ControlsSamplePage = value;

                    if(_ControlsSamplePage != null)
                    {
                        _ControlsSamplePage.Dock = DockStyle.Fill;
                        _ControlsSamplePage.Parent = this;
                        _ControlsSamplePage.Visible = true;

                        if(deferWindowPos != IntPtr.Zero)
                        {
                            WinApi.DeferWindowPos(
                                deferWindowPos, _ControlsSamplePage.Handle, WinApi.HWND_TOP, 0, 0, 0, 0,
                                WinApi.SWP_NOZORDER | WinApi.SWP_SHOWWINDOW);
                        }
                        else
                        {
                            _ControlsSamplePage.BringToFront();
                            _ControlsSamplePage.Show();    
                        }
                    }
                }
                finally
                {
                    if(deferWindowPos != IntPtr.Zero)
                        WinApi.EndDeferWindowPos(deferWindowPos);
                }

                PassPaintMessages();
            }
        }
    }
}
