using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    public class BrowserSourceConfig : OverlayConfigBase
    {
        private bool _forceBackground;
        public bool ForceBackground
        {
            get
            {
                return _forceBackground;
            }
            set
            {
                if (_forceBackground != value)
                {
                    _forceBackground = value;
                    ForceBackgroundChanged?.Invoke(this, new StateChangedEventArgs<bool>(_forceBackground));
                }
            }
        }
        private string _CSS;
        public string CSS
        {
            get
            {
                return _CSS;
            }
            set
            {
                if (_CSS != value)
                {
                    _CSS = value;
                    CSSChanged?.Invoke(this, new TextChangedEventArgs(_CSS));
                }
            }
        }
        private int _zoom = 1;
        public int Zoom
        {
            get
            {
                return this._zoom;
            }
            set
            {
                if (this._zoom != value)
                {
                    this._zoom = value;
                    ZoomChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        private bool _mute;
        public bool Mute
        {
            get
            {
                return _mute;
            }
            set
            {
                if (_mute != value)
                {
                    _mute = value;
                    MuteChanged?.Invoke(this, new StateChangedEventArgs<bool>(_mute));
                }
            }
        }
        public event EventHandler<TextChangedEventArgs> CSSChanged;
        public event EventHandler<StateChangedEventArgs<bool>> ForceBackgroundChanged;
        public event EventHandler<StateChangedEventArgs<bool>> MuteChanged;
        public event EventHandler ZoomChanged;
        
        public override Type OverlayType
        { 
            get { return typeof(BrowserSource); }
        }

        public BrowserSourceConfig(string name) : base(name)
        { 
        }

        private BrowserSourceConfig() : base(null)
        { 
        }

        public BrowserSourceConfig(TinyIoCContainer container, string name) : base(name)
        { 
        }
    }
}
