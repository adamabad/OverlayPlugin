# BrowserSource and DiscordOverlay
Additions to OverlayPlugin.Core.dll to add 2 new overlay types

## Why?
OverlayPlugin offers native AddonSupport. This works well for addons that include EventSource modules, however, the purpose of these 2 overlay types are meant to increase the capability of having overlays in game that do not have in-game links.

## System requirements
* Exisiting OverlayPlugin install for Advanced Combat Tracker. This fork is based on v19.19

## How to use
1. Visit https://streamkit.discord.com/overlay/ and click either "Install of OBS" or "Install for XSplit"
 	a. Either of these buttons work and do practicaly the same thing, you will get a notificaiton in your Discord client asking for permissions
	b. This site is Discord hosted and well-trusted. By accepting the permissions, you are opening your Client's RPC access to the Streamkit API.
2. [IMPORTANT] Head to you ACT plugin folder and BACKUP your existing OverlayPlugin options. This addition is in ALPHA and will not affect your existing overlays but may cause your settings to be reset when updating.
	a. %appadata%/Advanced Combat Tracker/Config/RainbowMage.OverlayPlugin.config
	b. %appadata%/Advanced Combat Tracker/Config/RainbowMage.OverlayPlugin.config.json.backup
	c. Duplicate the above listed files and save them in a secure location.
	d. DISCLAIMER: By using this plugin, parser presets such as those editable in Mopimopi or Kagero may be reset. These are stored in the wrapped browser cache and not in the above config files.
3. Download the linked OverlayPlugin.Core.dll and replace the existing file located in the Roaming folder.
	a. %appadata%/Advanced Combat Tracker/Plugins/OverlayPlugin/libs
	b. Relaunch ACT and head over to the OverlayPlugin tab, check the debug log on the bottom half of the screen to confirm no load errors.
4. This fork adds 2 new overlay types to the OverlayPlugin: BrowserSource and DiscordOverlay.
	a. Create a new overlay by clicking "New" at the bottom left of the plugin tab.
	b. Add a name to the overlay of your own choosing
	c. Select Preset "Custom"
	d. Under Type, select one of the two new Types included. (BrowserSource or DiscordOverlay)

## BrowserSource
1. The BrowserSource plugin is made to replicate the OBS BrowserSource stream element as closely as possible with some additional functions. YOU CANNOT USE PARSER OVERLAYS WITH THIS TYPE.
2. Many of the functions are self explanatory, by clicking "Lock Overlay" you will disable Posiiton, Size, FPS, Zoom, and Reset buttons. To use these, you must uncheck Lock Overlay.
3. Force White Background is used to change the background color of your element from white to transparent. You may need to toggle this on/off depending on the website or your own CSS options.
4. Log Browser Output is used to relay browser log lines to the debug window in the plugin.
5. On the CSS tab, you can add your own CSS and click "Apply CSS" to update the window. CSS is automatically applied when the window loads or reloads. Open Dev Tools will open a Chromium-based dev window, allowing you to see html elements and other useful tools. Clear Cache is used to clear the local window's cache

## DiscordOverlay
1. This overlay redirects to a https://streamkit.discord.com/overlay/voice/{ServerID}/{ChannelID} site. These are commonly used and edited to make "PNGTuber" overlay for streams and videos.
2. Several settings are included for easier Raid-overlaying, given the current restrictions on discord RPC, you will have to manually adjust your user's IDs and server/channel IDs (Srry, just painful how it is right now)
3. To access ServerID/ChannelID, you may need to enable Developer Mode on your discord client. 
	a. Once you have enabled, you can grab the server ID by right clicking the server icon and select "Copy Server ID" at the bottom of the popup.
	b. To get your channel id, locate the VOICE channel you will be speaking in, right click the channel and select "Copy Channel ID" at the bottom of the popup.
	c. Place these two values in their corresponding text boxes in the plugin.
4. Like ServerID/ChannelID, You will need to grab your raid member IDs and place them in the boxes as you expect them to show in your party list in game. You CAN skip over players not in call. These player IDs are used for alignment of CSS elements.
5. Head over to the CSS tab and either input your own CSS or the included CSS with this plugin. Notice how there are several player sections with "PLAYER#ID" src idefitiers. The plugin looks for these to filter your own player IDs without having to change your CSS. If developing your own CSS, please use PLAYER#ID (all caps, with # being 1-8) to distinguish your own players.
6. At the top of the file there are several root elements used as variables througout the CSS. These can be changed to your liking to better fit your own tastes. 
	a. --scale is an internal scale modifier for the UI. FFXIV has different UI scaling options and this can be used as a quick-adjust to your own. It may fit, it may not in combination with the Zoom value under "Advanced" Try 			adjusting this value before messing with the CSS spacing below.
	b. --border-color is the color that will appear when a user is talking
	c. --border-width is the width of the border that will show. 2px is set by default, but depending on settings and resolution, users may opt to increase or decrease this value.
	d. --sizeing-color is used to align your elements when setting up or used to have a persistent border around users when not talking. Note that users must be in call for their borders to appear. By adjusting this to not transparent 		(ex: red), you will see several borders around users that are in a call. You can use this when editing your alignments without having everyone talk to confirm you are set.
7. Once your CSS is set, you can fine tune your position and sizes with the advanced tab. These settings will be locked if "Lock overlay" is enabled under general.