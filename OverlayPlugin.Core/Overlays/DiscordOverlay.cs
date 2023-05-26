using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RainbowMage.OverlayPlugin.Overlays
{
    [Serializable]
    public class DiscordOverlay : OverlayBase<DiscordOverlayConfig>
    {
        public DiscordOverlay(DiscordOverlayConfig config, string name, TinyIoCContainer container)
            : base(config, name, container)
        {
            if (Overlay == null)
            {
                return;
            }

            if (Config.Zoom == 1)
            {
                Config.Zoom = 0;
            }

            if (Config.Url == null)
            {
                Config.Url = "https://streamkit.discord.com/overlay/voice/";
            }

            SetupOverlayEventHandlers();
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        public override System.Windows.Forms.Control CreateConfigControl()
        {
            return new DiscordOverlayConfigPanel(container, this);
        }
        private void SetupOverlayEventHandlers()
        {
            Config.ChannelChanged += (o, e) =>
            {
                UpdateURLOverlay();
            };
            Config.ServerChanged += (o, e) =>
            {
                UpdateURLOverlay();
            };
            Config.UrlChanged += (o, e) =>
            {
                UpdateURLOverlay();
            };
            this.Overlay.Renderer.BrowserLoad += (o, e) =>
            {
                LoadCSS();
            };
            Config.ForceBackgroundChanged += (o, e) =>
            {
                var color = Config.ForceBackground ? "white" : "transparent";
                ExecuteScript($"document.body.style.backgroundColor = \"{color}\";");
            };
            Config.DisabledChanged += (o, e) =>
            {
                if (Config.Disabled)
                {
                    Overlay.Renderer.EndRender();
                    Overlay.ClearFrame();
                }
                else
                {
                    Overlay.Renderer.BeginRender();
                }
            };
            Config.ZoomChanged += (o, e) =>
            {
                this.Overlay.Renderer.SetZoomLevel(Config.Zoom / 100.0);
            };
            Config.Player1Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player2Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player3Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player4Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player5Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player6Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player7Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Config.Player8Changed += (o, e) =>
            {
                this.Overlay.Reload();
            };
            Overlay.Renderer.BrowserStartLoading += (o, e) =>
            {
                if (e.Url.StartsWith("about:blank"))
                    return;
                Overlay.Renderer.SetZoomLevel(Config.Zoom / 100.0);
                if (Config.ForceBackground)
                {
                    ExecuteScript("document.body.style.backgroundColor = 'white';");
                }
            };
        }
        private void UpdateURLOverlay()
        {
            this.Overlay.Url = $"https://streamkit.discord.com/overlay/voice/{Config.ServerID}/{Config.ChannelID}";
        }
        private void LoadCSS()
        {
            string uriEncodedCSS = Uri.EscapeUriString(Config.CSS ?? "").ToString();
            string myScript = "const myCSS = document.createElement('style');";
            myScript += "myCSS.innerHTML = decodeURIComponent(\"" + uriEncodedCSS + "\");";
            myScript += "document.querySelector('head').appendChild(myCSS);";

            Regex regex;
            for (int i = 1; i < 9; i++)
            {
                regex = new Regex($@"PLAYER{i}ID");
                myScript = regex.Replace(myScript, Config.GetPlayerID(i) ?? "PLAYERIDNOTFOUND");
            }

            ExecuteScript(myScript);

        }
        internal string CreateJson()
        {
            return string.Format("{{ ForceBackground: {0}, ServerID: {1}, ChannelID: {2}, Player1ID: {3}, Player2ID: {4}, Player3ID: {5}, Player4ID: {6}, Player5ID: {7}, Player6ID: {8}, Player7ID: {9}, Player8ID: {10}, CSS: {11}, Zoom: {12} }}",
                this.Config.ForceBackground ? "true" : "false",
                JsonConvert.SerializeObject(this.Config.ServerID),
                JsonConvert.SerializeObject(this.Config.ChannelID),
                JsonConvert.SerializeObject(this.Config.Player1ID),
                JsonConvert.SerializeObject(this.Config.Player2ID),
                JsonConvert.SerializeObject(this.Config.Player3ID),
                JsonConvert.SerializeObject(this.Config.Player4ID),
                JsonConvert.SerializeObject(this.Config.Player5ID),
                JsonConvert.SerializeObject(this.Config.Player6ID),
                JsonConvert.SerializeObject(this.Config.Player7ID),
                JsonConvert.SerializeObject(this.Config.Player8ID),
                JsonConvert.SerializeObject(this.Config.CSS),
                this.Config.Zoom.ToString()
                );
        }
        public override void Start()
        {
        }
        public override void Stop()
        {
        }
        protected override void Update()
        {
        }
    }
}
