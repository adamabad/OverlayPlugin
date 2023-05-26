using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin.Overlays
{
    public partial class BrowserSourceConfigPanel : UserControl
    {
        private BrowserSourceConfig config;
        private BrowserSource overlay;
        private TinyIoCContainer container;
        public BrowserSourceConfigPanel()
        { 
        
        }
        public BrowserSourceConfigPanel(TinyIoCContainer container, BrowserSource overlay)
        {
            InitializeComponent();

            this.overlay = overlay;
            this.config = overlay.Config;
            this.container = container;

            SetupControlProperties();
            SetupConfigEventHandles();            
        }
        private void SetupControlProperties()
        {
            //this.localfile.Checked = this.config.Local;
            this.url_textbox.Text = this.config.Url;
            this.widthUpDown.Value = this.config.Size.Width;
            this.heightUpDown.Value = this.config.Size.Height;
            this.isMuted.Checked = this.config.Mute;
            this.fpsUpDown.Value = this.config.MaxFrameRate;
            this.isVisible.Checked = this.config.IsVisible;
            this.isEnabled.Checked = !this.config.Disabled;
            this.isClickthrough.Checked = this.config.IsClickThru;
            this.isLocked.Checked = this.config.IsLocked;
            this.isForcedBackground.Checked = this.config.ForceBackground;
            this.xUpDown.Value = this.config.Position.X;
            this.yUpDown.Value = this.config.Position.Y;
            this.trackBar1.Value = this.config.Zoom;
            this.css_textbox.Text = this.config.CSS;
            this.isLogged.Checked = this.config.LogConsoleMessages;

            this.widthUpDown.Enabled = !this.config.IsLocked;
            this.heightUpDown.Enabled = !this.config.IsLocked;
            this.fpsUpDown.Enabled = !this.config.IsLocked;
            this.xUpDown.Enabled = !this.config.IsLocked;
            this.yUpDown.Enabled = !this.config.IsLocked;
            this.trackBar1.Enabled = !this.config.IsLocked;
            this.default_btn.Enabled = !this.config.IsLocked;
            this.resetZoom_btn.Enabled = !this.config.IsLocked;
        }
        private void SetupConfigEventHandles() 
        {
            this.config.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.isVisible.Checked = e.IsVisible;
                });
            };
            this.config.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.isClickthrough.Checked = e.IsClickThru;
                });
            };
            this.config.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.url_textbox.Text = e.NewUrl;
                });
            };
            this.config.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.fpsUpDown.Value = e.NewFrameRate;
                });
            };
            this.config.LockChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.isLocked.Checked = e.IsLocked;
                });
            };
            this.config.ZoomChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.trackBar1.Value = this.config.Zoom;
                });
            };
            this.config.DisabledChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.isEnabled.Checked = !this.config.Disabled;
                });
            };
            this.config.MuteChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.isMuted.Checked = this.config.Mute;
                });
            };
            this.config.LogConsoleMessagesChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.isLogged.Checked = this.config.LogConsoleMessages;
                });
            };
            this.config.CSSChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.css_textbox.Text = e.Text;
                });
            };
        }
        private void InvokeIfRequired(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void SizeUpdate()
        {
            overlay.Overlay.Size = new Size((int)widthUpDown.Value, (int)heightUpDown.Value);
        }
        private void UpdatePosition()
        {
            overlay.Overlay.SetDesktopLocation((int)xUpDown.Value, (int)yUpDown.Value);
        }
        private void applyCSS_Click(object sender, EventArgs e)
        {
            this.overlay.Reload();
        }

        private void widthUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SizeUpdate();
        }

        private void heightUpDown_ValueChanged(object sender, EventArgs e)
        {
            SizeUpdate();
        }

        private void fpsUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.config.MaxFrameRate = (int)fpsUpDown.Value;
        }

        private void url_textbox_TextChanged(object sender, EventArgs e)
        {
            this.config.Url = url_textbox.Text;
        }

        private void isVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsVisible = this.isVisible.Checked;
        }

        private void isEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.config.Disabled = !this.isEnabled.Checked;
        }

        private void isClickthrough_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsClickThru = this.isClickthrough.Checked;
        }

        private void isLocked_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsLocked = this.isLocked.Checked;
            this.widthUpDown.Enabled = !this.config.IsLocked;
            this.heightUpDown.Enabled = !this.config.IsLocked;
            this.fpsUpDown.Enabled = !this.config.IsLocked;
            this.xUpDown.Enabled = !this.config.IsLocked;
            this.yUpDown.Enabled = !this.config.IsLocked;
            this.trackBar1.Enabled = !this.config.IsLocked;
            this.default_btn.Enabled = !this.config.IsLocked;
            this.resetZoom_btn.Enabled= !this.config.IsLocked;
        }

        private void isForcedBackground_CheckedChanged(object sender, EventArgs e)
        {
            this.config.ForceBackground = this.isForcedBackground.Checked;
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        private void resetZoom_btn_Click(object sender, EventArgs e)
        {
            this.config.Zoom = 0;
            this.trackBar1.Value = 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (this.config.Zoom == 0 && Math.Abs(this.config.Zoom - this.trackBar1.Value) < 10)
            {
                return;
            }
            this.config.Zoom = this.trackBar1.Value;
        }

        private void default_btn_Click(object sender, EventArgs e)
        {
            this.config.Size = new Size(500, 500);
            this.widthUpDown.Value = 500;
            this.heightUpDown.Value = 500;
            this.config.MaxFrameRate = 30;
            this.fpsUpDown.Value = 30;
            this.config.Position = new Point(0, 0);
            this.xUpDown.Value = 0;
            this.yUpDown.Value = 0;
            this.config.Zoom = 0;
            this.trackBar1.Value = 0;
            this.config.CSS = "";
            this.css_textbox.Text = this.config.CSS;
            this.isLogged.Checked = true;
        }

        private void css_textbox_TextChanged(object sender, EventArgs e)
        {
            this.config.CSS = this.css_textbox.Text;
        }

        private void showDevTools_btn_Click(object sender, EventArgs e)
        {
            overlay.Overlay.Renderer.showDevTools();
        }

        private void clearcache_btn_Click(object sender, EventArgs e)
        {
            container.Resolve<PluginMain>().ClearCacheOnRestart();
            clearcache_btn.Enabled = false;
            Updater.Updater.TryRestartACT(true, Resources.ClearCacheRestart);
        }

        private void isLogged_CheckedChanged(object sender, EventArgs e)
        {
            this.config.LogConsoleMessages = this.isLogged.Checked;
        }
    }
}
