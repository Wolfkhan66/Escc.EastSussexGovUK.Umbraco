# Escc.EastSussexGovUK.Umbraco

This project is the root of our [Umbraco](http://umbraco.com/) installation for [www.eastsussex.gov.uk](https://www.eastsussex.gov.uk) and includes:

* [Jobs](Jobs.md)
* [Locations, including libraries and recycling sites](Location.md)
* [Adding term dates to a topic page](Topic.md)

## Development setup steps

1. From an Administrator command prompt, run `app-setup-dev.cmd` to set up a site in IIS.
2. Build the solution
3. Grant modify permissions to the application pool account on the web root folder and all children
4. Copy `packages\Umbraco*\Content\config\*.config` into `~\config`
6. In `~\web.config` set the `UmbracoConfigurationStatus` and `umbracoDbDSN`, or run the Umbraco installer.
8. In `~\web.config` add the contents of `web.config.xdt`
7. In `~\web.config` uncomment and complete the `Proxy` and `RemoteMasterPage` sections
8. At a command line, run the following two commands to add the document types to Umbraco. Substitute the hostname and port where you set up this project, and ensure the token matches the `Escc.Umbraco.Inception.AuthToken` value in the `appSettings` section of `web.config`.

		curl --insecure -X POST -d "" https://hostname:port/umbraco/api/UmbracoSetupApi/CreateUmbracoSupportingTypes?token=dev
		curl --insecure -X POST -d "" https://hostname:port/umbraco/api/UmbracoSetupApi/CreateUmbracoDocumentTypes?token=dev