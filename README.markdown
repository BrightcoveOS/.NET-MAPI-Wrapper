Brightcove4net
--------------
**Homepage**: [http://blog.velir.com/index.php/brightcove4net/](http://blog.velir.com/index.php/brightcove4net/)
**Author**: [David Mills](mailto:david.mills@velir.com)
**Copyright**: 2010 [Velir](http://www.velir.com)
**License**: [MIT License](file:MIT-LICENSE)

About Brightcove4net
----------------
Brightcove4net is a .NET wrapper for the [Brightcove](http://www.brightcove.com/) [Media API](http://support.brightcove.com/en/docs/media-api-reference). All available API calls are wrapped, for both video and audio.

Getting Started
----------------
1. Download the [latest release](https://github.com/downloads/Velir/Brightcove4net/Brightcove4net.dlls.zip). Extract the archive and place Brightcove4net.dll in an appropriate place for inclusion in your projest. 
	- Choose the debug dll while developing, since it is compiled with debug symbols, and will print raw information about the API calls to the .NET debug trace listener as the calls are made. 
	- For productions environments, use the release version of the dll.
2. Add a reference to your project for the dll. 
3. Instantiate a BrightcoveApi object and make API calls!

Usage
----------------
A simple case, find all videos in an account: 

	// Instantiate an API object by using the provided factory
	BrightcoveApi api = BrightcoveApiFactory.CreateApi("my API read token", "my API write token");
	
	// API calls are subject to the whims of internet connectivity, and may throw an exception. 
	// To ensure that your app is as robust as possible, make sure to try/catch all API calls (not shown here).
	BrightcoveItemCollection<BrightcoveVideo> videos = api.FindAllVideos();	
	foreach (BrightcoveVideo video in videos)
	{
		// do something with each video
	}
	
All available API calls are [documented by Brightcove](http://docs.brightcove.com/en/media/); or see the [official Brightcove4net page](http://blog.velir.com/index.php/brightcove4net/) for more examples. 

Documentation
----------------
Examples and other documentation are available on the [official Brightcove4net page](http://blog.velir.com/index.php/brightcove4net/).

----------------
Copyright (c) 2010 [Velir](http://www.velir.com), released under the MIT license