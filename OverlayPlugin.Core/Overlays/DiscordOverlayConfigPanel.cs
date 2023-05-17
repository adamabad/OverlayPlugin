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
    public partial class DiscordOverlayConfigPanel : UserControl
    { 
        private DiscordOverlayConfig config;
        private DiscordOverlay overlay;
        public DiscordOverlayConfigPanel(TinyIoCContainer container, DiscordOverlay overlay)
        {
            InitializeComponent();

            this.overlay = overlay;
            this.config = overlay.Config;

            SetupControlProperties();
            SetupConfigEventHandlers();
        }
        private void SetupConfigEventHandlers()
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
                    this.ClickThrough.Checked = e.IsClickThru;
                });
            };
            this.config.LockChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Locked.Checked = e.IsLocked;
                });
            };
            this.config.ForceBackgroundChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.ForceBackground.Checked = e.NewState;
                });
            };
            this.config.ServerChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.ServerID.Text = e.Text;
                });
            };
            this.config.ChannelChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.ChannelID.Text = e.Text;
                });
            };
            this.config.CSSChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.CSS.Text = e.Text;
                });
            };
            this.config.Player1Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player1ID.Text = e.Text;
                });
            };
            this.config.Player2Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player2ID.Text = e.Text;
                });
            };
            this.config.Player3Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player3ID.Text = e.Text;
                });
            };
            this.config.Player4Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player4ID.Text = e.Text;
                });
            };
            this.config.Player5Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player5ID.Text = e.Text;
                });
            };
            this.config.Player6Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player6ID.Text = e.Text;
                });
            };
            this.config.Player7Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player7ID.Text = e.Text;
                });
            };
            this.config.Player8Changed += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.Player8ID.Text = e.Text;
                });
            };
            this.config.ZoomChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.trackBar1.Value = this.config.Zoom;
                });
            };
            this.config.LogConsoleMessagesChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.LogOutput.Checked = this.config.LogConsoleMessages;
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
        private void SetupControlProperties()
        {
            this.isVisible.Checked = config.IsVisible;
            this.isEnabled.Checked = !config.Disabled;
            this.ClickThrough.Checked = config.IsClickThru;
            this.Locked.Checked = config.IsLocked;
            this.ForceBackground.Checked = config.ForceBackground;
            this.ServerID.Text = config.ServerID;
            this.ChannelID.Text = config.ChannelID;
            this.Player1ID.Text = config.Player1ID;
            this.Player2ID.Text = config.Player2ID;
            this.Player3ID.Text = config.Player3ID;
            this.Player4ID.Text = config.Player4ID;
            this.Player5ID.Text = config.Player5ID;
            this.Player6ID.Text = config.Player6ID;
            this.Player7ID.Text = config.Player7ID;
            this.Player8ID.Text = config.Player8ID;
            this.CSS.Text = config.CSS;
            this.config.Url = config.Url;
            this.trackBar1.Value = config.Zoom;
            this.LogOutput.Checked = config.LogConsoleMessages;
            this.xUpDown.Value = config.Position.X;
            this.yUpDown.Value = config.Position.Y;
            this.xUpDown.Enabled = !config.IsLocked;
            this.yUpDown.Enabled = !config.IsLocked;
            this.resetZoom.Enabled = !config.IsLocked;
            this.trackBar1.Enabled = !config.IsLocked;
        
        }
        private void UpdatePosition()
        {
            this.overlay.Overlay.SetDesktopLocation((int)xUpDown.Value, (int)yUpDown.Value);
        }

        #region EventChanged functions
        private void isVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsVisible = this.isVisible.Checked;
        }

        private void isEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.config.Disabled = !this.isEnabled.Checked;
        }

        private void ClickThrough_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsClickThru = this.ClickThrough.Checked;
        }

        private void Locked_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsLocked = this.Locked.Checked;
            this.xUpDown.Enabled = !this.Locked.Checked;
            this.yUpDown.Enabled = !this.Locked.Checked;
            this.resetZoom.Enabled = !this.Locked.Checked;
            this.trackBar1.Enabled = !this.Locked.Checked;
        }

        private void ForceBackground_CheckedChanged(object sender, EventArgs e)
        {
            this.config.ForceBackground = this.ForceBackground.Checked;
        }

        private void ServerID_TextChanged(object sender, EventArgs e)
        {
            this.config.ServerID = this.ServerID.Text;
            this.config.Url = $"https://streamkit.discord.com/overlay/voice/{this.config.ServerID}/{this.config.ChannelID}";
        }

        private void ChannelID_TextChanged(object sender, EventArgs e)
        {
            this.config.ChannelID = this.ChannelID.Text;
            this.config.Url = $"https://streamkit.discord.com/overlay/voice/{this.config.ServerID}/{this.config.ChannelID}";
        }

        private void Player1ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player1ID = this.Player1ID.Text;
        }

        private void Player2ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player2ID = this.Player2ID.Text;
        }

        private void Player3ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player3ID = this.Player3ID.Text;
        }

        private void Player4ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player4ID = this.Player4ID.Text;
        }

        private void Player5ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player5ID = this.Player5ID.Text;
        }

        private void Player6ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player6ID = this.Player6ID.Text;
        }

        private void Player7ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player7ID = this.Player7ID.Text;
        }

        private void Player8ID_TextChanged(object sender, EventArgs e)
        {
            this.config.Player8ID = this.Player8ID.Text;
        }

        private void CSS_TextChanged(object sender, EventArgs e)
        {
            this.config.CSS = this.CSS.Text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (this.config.Zoom == 0 && Math.Abs(this.config.Zoom - this.trackBar1.Value) < 10)
            {
                return;
            }
            this.config.Zoom = this.trackBar1.Value;
        }

        private void resetZoom_Click(object sender, EventArgs e)
        {
            this.config.Zoom = 0;
            this.trackBar1.Value = 0;
        }

        private void LogOutput_CheckedChanged(object sender, EventArgs e)
        {
            this.config.LogConsoleMessages = this.LogOutput.Checked;
        }

        private void applyCSS_Click(object sender, EventArgs e)
        {
            this.overlay.Reload();
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        #endregion
    }
}
