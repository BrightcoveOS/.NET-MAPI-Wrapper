BrightcoveOS .NET-MAPI-Wrapper
--------------
- **Homepage**: https://github.com/BrightcoveOS/.NET-MAPI-Wrapper
- **Author**: [David Mills](mailto:david.mills@velir.com)
- **Copyright**: 2011 [Velir]
- **License**: [MIT License](file:MIT-LICENSE)

About the .NET-MAPI-Wrapper
----------------
BrightcoveOS .NET-MAPI-Wrapper is a .NET wrapper for the [Brightcove](http://www.brightcove.com/) [Media API](http://support.brightcove.com/en/docs/media-api-reference). All available API calls are wrapped, for both video and audio.

Getting Started
----------------
1. Download the [latest release][latest-dll]. Extract the archive and place BrightcoveOS.NET-MAPI-Wrapper.dll in an appropriate place for inclusion in your project. 
	- Choose the debug dll while developing, since it is compiled with debug symbols, and will print raw information about the API calls to the .NET debug trace listener as the calls are made. 
	- For productions environments, use the release version of the dll.
2. Add a reference to your project for the dll.
3. Add "using" statements to your code for the following namespaces:
	- using BrightcoveMapiWrapper.Api;
	- using BrightcoveMapiWrapper.Model;
	- using BrightcoveMapiWrapper.Model.Containers;
	- using BrightcoveMapiWrapper.Model.Items;
3. Create a BrightcoveApi object and make API calls!

Usage
----------------
A simple case, find all videos in an account: 

	// Instantiate an API object by using the provided factory
	BrightcoveApi api = BrightcoveApiFactory.CreateApi("my API read token");
	
	// NOTE: API calls are subject to the whims of internet connectivity, and may throw an exception for any number of reasons. 
	// NOTE: To ensure that your app is as robust as possible, make sure to try/catch all API calls (not shown here).
	
	// Perform the "find_all_videos" API call
	BrightcoveItemCollection<BrightcoveVideo> videos = api.FindAllVideos();	
	foreach (BrightcoveVideo video in videos)
	{
		// do something with each video
	}


All available API calls are [documented by Brightcove][brightcove-api-docs]; or see the [.NET-MAPI-Wrapper wiki][wiki] for more examples. 

Documentation
----------------
Examples and other documentation are available on the [wiki].

Copyright & License
----------------
Copyright (c) 2011 [Velir](http://www.velir.com), released under the [MIT License](file:MIT-LICENSE)

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

[latest-dll]: https://github.com/downloads/BrightcoveOS/.NET-MAPI-Wrapper/BrightcoveOS.NET-MAPI-Wrapper.latest.dlls.zip
[wiki]: https://github.com/BrightcoveOS/.NET-MAPI-Wrapper/wiki
[brightcove-api-docs]: http://docs.brightcove.com/en/media/
[velir]: http://www.velir.com