BrightcoveOS .NET-MAPI-Wrapper Changelog
--------------

2011-12-05
Version: 1.20
- Significantly reduced memory usage when uploading large files. Files are now streamed to the server, rather than requiring that the file contents be loaded into memory.
- Note: The "Create" methods that accept a `byte[]` have been removed, so if your code was feeding-in bytes directly (rather than specifying a file on disk) then the version 1.2 update will require you change your code to specify a Stream in the following form, instead: `FileUploadInfo(Stream data, string fileName)`

2011-06-29
Version: 1.10
- Fixed JSON deserialization issue
- Added a couple file upload method overloads

2011-06-22
Version: 1.0
- Fixed format issue when serializing to JSON
- Official stable 1.0 release.

2011-02-19
Version: RC3
- Minor updates and fixes.

2011-02-17
Version: RC2
- Minor updates and fixes.

2011-02-14
Version: RC1
- Renamed project to "BrightcoveOS .NET MAPI Wrapper" (formerly Brightcove4net), and migrated it to the official BrightcoveOS Github respository.




