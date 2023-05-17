using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    [Serializable]
    public class DiscordOverlayConfig : OverlayConfigBase
    {
        private bool _ForceBackground;
        public bool ForceBackground
        {
            get
            {
                return _ForceBackground;
            }
            set
            {
                if (_ForceBackground != value)
                {
                    _ForceBackground = value;
                    ForceBackgroundChanged?.Invoke(this, new StateChangedEventArgs<bool>(_ForceBackground));
                }
            }
        }
        private string _ServerID;
        public string ServerID
        {
            get
            {
                return _ServerID;
            }
            set
            {
                if (_ServerID != value)
                {
                    _ServerID = value;
                    ServerChanged?.Invoke(this, new TextChangedEventArgs(_ServerID));
                }
            }
        }
        private string _ChannelID;
        public string ChannelID
        {
            get
            {
                return _ChannelID;
            }
            set
            {
                if (_ChannelID != value)
                {
                    _ChannelID = value;
                    ChannelChanged?.Invoke(this, new TextChangedEventArgs(_ChannelID));
                }
            }
        }
        private string _Player1ID;
        public string Player1ID
        {
            get
            {
                return _Player1ID;
            }
            set
            {
                if (_Player1ID != value)
                {
                    _Player1ID = value;
                    Player1Changed?.Invoke(this, new TextChangedEventArgs(_Player1ID));
                }
            }
        }
        private string _Player2ID;
        public string Player2ID
        {
            get
            {
                return _Player2ID;
            }
            set
            {
                if (_Player2ID != value)
                {
                    _Player2ID = value;
                    Player2Changed?.Invoke(this, new TextChangedEventArgs(_Player2ID));
                }
            }
        }
        private string _Player3ID;
        public string Player3ID
        {
            get
            {
                return _Player3ID;
            }
            set
            {
                if (_Player3ID != value)
                {
                    _Player3ID = value;
                    Player3Changed?.Invoke(this, new TextChangedEventArgs(_Player3ID));
                }
            }
        }
        private string _Player4ID;
        public string Player4ID
        {
            get
            {
                return _Player4ID;
            }
            set
            {
                if (_Player4ID != value)
                {
                    _Player4ID = value;
                    Player4Changed?.Invoke(this, new TextChangedEventArgs(_Player4ID));
                }
            }
        }
        private string _Player5ID;
        public string Player5ID
        {
            get
            {
                return _Player5ID;
            }
            set
            {
                if (_Player5ID != value)
                {
                    _Player5ID = value;
                    Player5Changed?.Invoke(this, new TextChangedEventArgs(_Player5ID));
                }
            }
        }
        private string _Player6ID;
        public string Player6ID
        {
            get
            {
                return _Player6ID;
            }
            set
            {
                if (_Player6ID != value)
                {
                    _Player6ID = value;
                    Player6Changed?.Invoke(this, new TextChangedEventArgs(_Player6ID));
                }
            }
        }
        private string _Player7ID;
        public string Player7ID
        {
            get
            {
                return _Player7ID;
            }
            set
            {
                if (_Player7ID != value)
                {
                    _Player7ID = value;
                    Player7Changed?.Invoke(this, new TextChangedEventArgs(_Player7ID));
                }
            }
        }
        private string _Player8ID;
        public string Player8ID
        {
            get
            {
                return _Player8ID;
            }
            set
            {
                if (_Player8ID != value)
                {
                    _Player8ID = value;
                    Player8Changed?.Invoke(this, new TextChangedEventArgs(_Player8ID));
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

        public event EventHandler<StateChangedEventArgs<bool>> ForceBackgroundChanged;
        public event EventHandler<TextChangedEventArgs> ServerChanged;
        public event EventHandler<TextChangedEventArgs> ChannelChanged;
        public event EventHandler<TextChangedEventArgs> Player1Changed;
        public event EventHandler<TextChangedEventArgs> Player2Changed;
        public event EventHandler<TextChangedEventArgs> Player3Changed;
        public event EventHandler<TextChangedEventArgs> Player4Changed;
        public event EventHandler<TextChangedEventArgs> Player5Changed;
        public event EventHandler<TextChangedEventArgs> Player6Changed;
        public event EventHandler<TextChangedEventArgs> Player7Changed;
        public event EventHandler<TextChangedEventArgs> Player8Changed;
        public event EventHandler<TextChangedEventArgs> CSSChanged;
        public event EventHandler ZoomChanged;
        public DiscordOverlayConfig(string name) : base(name)
        {
        }

        private DiscordOverlayConfig() : base(null)
        {
        }

        public DiscordOverlayConfig(TinyIoCContainer container, string name) : base(name)
        {

        }
        public string GetPlayerID(int i)
        {
            switch (i)
            {
                case (1):
                    return Player1ID;
                case (2):
                    return Player2ID;
                case (3):
                    return Player3ID;
                case (4):
                    return Player4ID;
                case (5):
                    return Player5ID;
                case (6):
                    return Player6ID;
                case (7):
                    return Player7ID;
                case (8):
                    return Player8ID;
                default:
                    return "";
            }
        }
        public override Type OverlayType
        {
            get { return typeof(DiscordOverlay); }
        }
    }
}
