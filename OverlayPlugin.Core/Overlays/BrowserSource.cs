using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace RainbowMage.OverlayPlugin.Overlays
{
    [Serializable]
    public class BrowserSource : OverlayBase<BrowserSourceConfig>
    {
        public BrowserSource(BrowserSourceConfig config, string name, TinyIoCContainer container) 
            : base(config, name, container)
        {
            if (Overlay == null)
            {
                return;
            }

            if (Config.Zoom == 1)
            { 
                Config.Zoom = 1;
            }
            SetupOverlayEventHandlers();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        public override Control CreateConfigControl()
        {
            return new BrowserSourceConfigPanel(container, this);
        }
        private void SetupOverlayEventHandlers()
        {
            Config.UrlChanged += (o, e) =>
            {
                UpdateUrl();
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
            Config.MuteChanged += (o, e) =>
            {
                this.Overlay.Renderer.SetMuted(Config.Mute);
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
        private void UpdateUrl()
        { 
            this.Overlay.Url = Config.Url;
        }
        private void LoadCSS()
        {
            string uriEncodedCSS = Uri.EscapeUriString(Config.CSS ?? "").ToString();
            string myScript = "const myCSS = document.createElement('style');";
            myScript += "myCSS.innerHTML = decodeURIComponent(\"" + uriEncodedCSS + "\");";
            myScript += "document.querySelector('head').appendChild(myCSS);";
            ExecuteScript(myScript);
        }
        internal string CreateJson()
        {
            return string.Format("{{ ForceBackground: {0}, Url: {1}, Width: {2}, Height: {3}, FPS: {4}, Zoom: {5}, CSS: {6}",
                    this.Config.ForceBackground ? "true" : "false",
                    JsonConvert.SerializeObject(this.Config.Url),
                    JsonConvert.SerializeObject(this.Config.Size.Width),
                    JsonConvert.SerializeObject(this.Config.Size.Height),
                    JsonConvert.SerializeObject(this.Config.MaxFrameRate),
                    JsonConvert.SerializeObject(this.Config.Zoom),
                    JsonConvert.SerializeObject(this.Config.CSS)
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
