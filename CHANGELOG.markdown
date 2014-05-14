BrightcoveOS .NET-MAPI-Wrapper Changelog
--------------

**Version 2.01 (May 14, 2014)**

- Added support for `CreateVideo` call with a remote asset specified (rather than uploading a file directly).

**Version 2.00 (January 10, 2013)**

- `BrightcoveAPI`
	- Modified several methods that were not working, either due to a changed specification by Brightcove or an error in Brightcove's implementation.
		- `SearchVideos` (implemented the new sorting mechanism)
		- `FindVideosByText` (deprecated in favor of SearchVideos)
		- `FindVideosByTags` (deprecated in favor of SearchVideos)
		- `FindVideosByUserId` (deprecated in favor of alternative [approaches to user-generated content](http://support.brightcove.com/en/video-cloud/docs/user-generated-content))
		- `FindVideosByCampaignId` (deprecated in favor of alternative [approaches to user-generated content](http://support.brightcove.com/en/video-cloud/docs/user-generated-content))
	- Added several methods that were not included in the previous release that are supported by Brightcove.
		- `DeleteAudioTrack` (undocumented)
		- `DeleteAudioTrackPlaylist` (undocumented)
		- `FindVideoByIdUnfiltered`
		- `FindVideoByReferenceIdUnfiltered`
		- `FindVideosByIdsUnfiltered`
		- `FindVideosByReferenceIdsUnfiltered`
		- `UnshareVideo`
- `BrightcoveApiConfig`
	- Added support for requests to the Japanese site, [api.brightcove.co.jp](http://api.brightcove.co.jp), while maintaining support for the general site, [api.brightcove.com](http://api.brightcove.com).
- `Connectors`
	- `BrightcoveApiConnnector`
		- Made the `RequestUrl` property publicly gettable while protectedly settable. This allows for all users to read the `RequestUrl`, while allowing for inheritors to set the property if overriding the `GetResponseJson` method.
	- `BasicRequestBuilder`
		- Write stream buffering is now turned off for file uploads to reduce memory usage, as suggested in [issue #17](https://github.com/BrightcoveOS/.NET-MAPI-Wrapper/issues/17).
- `Model.Items`
	- Made all setters for collections instantiated in the models' constructors public (e.g. `BrightcoveVideo.Renditions`, `BrightcovePlaylist.FilterTags`, etc.). This eliminates any ambiguity about being able to add items to any such collection.
	- Changed the accessibility of the setter of the Id property in all applicable models to public (from private). This allows API consumers to instantiate new playlists for updating if they know the value of the Id in advance.
		- As a result, the serializer now ignores any Ids that are set to 0.
- `Model.Items.BrightcovePlaylist`
	- Changed the default value of `TagInclusionRule` to `Or` to match the default value of playlists created in Brightcove.
	- Created a workaround in the event that an API consumer wants to change a smart playlist to an explicit playlist and vice versa.

- Documentation
    - Added documentation for all classes, methods and properties.
	
- Tests
    - Added integration tests for most areas of the API.
        - `BrightcoveAudioTrackPlaylist` read/write
        - `BrightcoveAudioTrack` read/write
        - `BrightcovePlaylist` read/write
        - `BrightcoveVideo` read/write


**Version 1.20 (December 12, 2011)**

- Significantly reduced memory usage when uploading large files. Files are now streamed to the server, rather than requiring that the file contents be loaded into memory.
- Note: The "Create" methods that accept a `byte[]` have been removed, so if your code was feeding-in bytes directly (rather than specifying a file on disk) then the version 1.2 update will require you change your code to specify a Stream in the following form, instead: `FileUploadInfo(Stream data, string fileName)`


**Version 1.10 (June 29, 2011)**

- Fixed JSON deserialization issue
- Added a couple file upload method overloads


**Version 1.0 (June 22, 2011)**

- Fixed format issue when serializing to JSON
- Official stable 1.0 release.


**Version RC3 (February 19, 2011)**

- Minor updates and fixes.


**Version RC2 (February 17, 2011)**

- Minor updates and fixes.


**Version: RC1 (February 14, 2011)**

- Renamed project to "BrightcoveOS .NET MAPI Wrapper" (formerly Brightcove4net), and migrated it to the official BrightcoveOS Github respository.
