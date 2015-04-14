# ViewStateOptimizer
The ViewStateOptimizer is a .NET library used to optimize the ViewState problem for the asp.net web forms platform. It will include a set of the best methods to improve the performance for the asp.net web forms when using ViewState.
![ViewStateOptimizer Class Diagram](http://i.imgur.com/GWFr1jO.png "ViewStateOptimizer Class Diagram")

### ViewState Performance
Basically, the ViewState data is stored in the hidden field and will be sent the roundtrip between the server and the client. If you use many asp.net server controls, the ViewState size will become bigger. So, we store the ViewState data in the hidden field which can bring us some following disadvantages:
* Increase the bandwidth cost.
* Risk about the ViewState data security.
* Make our website quite lower.

For this library, we can use an another solution to optimize the ViewState data that we can store the ViewState data in the files on the server-side. This helps us to decrease the bandwidth cost, restrict the risk about the ViewState data and make our website faster than.

### Install and Requirements
In order to use this library, your application needs to meet these following criterias:
* Use for the asp.net web forms applications.
* Require the .NET Framework 2.0 or higher.

If okay, then you can install it directly via following ways:
* Via Nuget: ``` Install-Package ViewStateOptimizer ```
* Via Github: ``` git clone https://github.com/congdongdotnet/ViewStateOptimizer.git ```

### Samples
#####[File Storage] Store the ViewState contents in the files using FileViewStateOptimizer class
In order to configure to store the ViewState contents in the files on the server-side, you only need to create a new browser file named __vso-browser.browser__ under the App_Browsers folder and then add the following contents into that browser file:
```xml
<browsers>
	<browser refID="Default">
		<controlAdapters>
			<adapter controlType="System.Web.UI.Page"
            			 adapterType="ViewStateOptimizer.FileStorage
            			 	.FileViewStateOptimizerPageAdapter"/>
		</controlAdapters>
	</browser>
</browsers>
```
Basically, the ViewState data will be configured with three following options in the static class __FileViewStateOptimizerOptions__:
* ViewStateStorageRelativeFolder = "~/App_Data/VsFiles": this option used to configure the relative folder to store the ViewState contents on the server-side.
* ViewStateKey = "_ViewStateOptimizer": this option used to configure the ViewStateKey for the hidden field on the client-side.
* ViewStatePrefixValue = "_vso": this option used to configure the prefix value of value of the hidden field on the client-side.

If you would like to configure your own above options for global asp.net application, you can do this in the __Application_Start__ event of asp.net.

In case you would like to configure storing the ViewState data for the page-level without all pages, you have to add the following code into the code-behind of web forms page:
```c#
protected override PageStatePersister PageStatePersister
{
	get
	{
		return new FileViewStateOptimizer(Page);
	}
}
```
**NOTE:**

Starting from the 1.0.1 version, we will have to configure above options via web.config instead of being inside code as before. This method helps us to avoid re-compiling the source code each times we make some changes to those options. We can configure the ViewStateOptimizer for the file storage with following codes:
```xml
<configuration>
	...
	<configSections>
		...
		<section name="viewStateOptimizer" type="ViewStateOptimizer
								.ViewStateOptimizerConfigurationSection"/>
		...
	</configSections>
	...
	<viewStateOptimizer type="FileStorage">
		<fileStorageViewStateOptimizer viewStateKey="_ViewStateOptimizer"  
			viewStateStorageRelativeFolder="~/ViewStateOptimizer/VsFiles"
			viewStatePrefixValue="_vso"/>
	</viewStateOptimizer>
	...
</configuration
```

### Bugs and Issues
If any issue or bug, please push a new issue [here](https://github.com/congdongdotnet/ViewStateOptimizer/issues).

### Release Notes
* 1.0.1:
    * Add the meaningful comments into code.
    * Move the configurations programmatically to web.config.
* 1.0.0:.
    * Optimize the ViewState performance by storing the ViewState contents in the files on the server-side.
    * Support the session page adapter for configuring the SessionPageStatePersister.

### Copyright and License
Copyright 2015 by CongDongDotNet - MIT License
