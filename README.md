------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Primary scene
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
* Main scene could be a simple lobby with banners on the wall, each banner is clickable.
	+ Fill scene with objects to make it look nice
	+ Suitable directional lighting

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Banner Rendering
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
* Render a zanox banner from Zanox API (or fake it) within a VR scene + Impression/Click counting
	+ Should be clickable
	+ Click should 'teleport' the user to another unity 'scene', this scene represents the advert
	+ Click should be counted in some stats somewhere
	+ Impression should be counted, but only if the user has seen the creative
		+ We can record stats on the following...
			+ Peripheral vision impression
			+ Direct gaze impression
			+ Stats can be recorded locally or in our own solution, do not need to integrate with Zanox/AW for this.

	+ Safe to ignore the URL in the advert for now, it is likely that the URI could be used to launch a VR creative in a 'production' environment.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Advertising Creatives:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
* Each demo will be built in a scene
	+ The purpose of this is to mirror the 'creative as advert' pattern used in the industry (i.e. Flash or JS based advertising 'creatives')

* Virtual Reality 'Checkout' (This is really just a  dummy scene to represent a checkout, does not need to work well)
	+ Simple 3D scene to represent a 'shopping basket' containing one item
	+ Pressing 'Buy' will prompt for a PIN number (accept any)
	+ Fake sucess message
	+ Should track success in stats for conversion data

* Build a 'Video Advert' creative
	+ How do we play video in unity on a texture (such as a television in the scene)
	+ Rewind, Fast Forward, Pause
	+ How to prepare video for this, what is the conversion process
		Download MP4:   [youtube-dl <some_url>] 
		Convert to ogv: [ffmpeg -i source.mp4 -acodec libvorbis -vcodec libtheora -ac 2 -ab 96k -ar 44100 -b 819200 -s 1080x720 destination.ogv]
	+ Some visual 'call to action', perhaps a flashing object in the room

* Spotify music player VR advert creative
	+ User should be in an armchair, a simple control panel should be accessible
	+ Some Genres should be accessible around the room, these should be clickable
	+ Clicking on a Genre will start a 'radio' session for that Genre	
	+ Pause/Stop/Skip back / forward buttons
	+ Even if we have to make API calls to another machine to play music, this is acceptable for demo purposes.

* 'Visual Impact' creative
	+ Use should be in a darkened scene
	+ Visual elements and brand specific messages should fly at the user during the playback of the scene
	+ Compelling music should be timed to the visual elements
	+ The idea is not to make this massively interactive, however we might choose to make some minor interactions (such as objects the user can touch which make musical noise or something)
