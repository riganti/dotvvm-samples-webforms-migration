# Migrating ASP.NET Web Forms app to .NET Core using DotVVM

[![Move your Web Forms app to .NET Core without rewriting everything](https://github.com/riganti/dotvvm/blob/master/video_thumb.png)](https://channel9.msdn.com/Events/dotnetConf/NET-Conf-2019/B321)

[DotVVM](https://github.com/riganti/dotvvm) is an open source MVVM framework for web applications that supports ASP.NET and ASP.NET Core. 

There are still plenty of old Web Forms applications out in the world. They are difficult to maintain and extend. The authors of such apps stand in front of a difficult choice:
* to rewrite the entire application from scratch using a modern stack
* to start a long-running modernization process and do it "on the fly" using small, incremental upgrades 

The total rewrite is a timely process. It requires a huge effort, it is often hard to get approved by company management, and requires the developers to adopt a lot of new knowledge. Morover, it is difficult for the team to add new features in the application as they have a lot of work with the rewrite.

The second way, which is demonstrated by this sample, is less risky, involves less effort and allows to split the modernization into smaller parts so the team can split its capacity to satisfy both modernization and adding new features. DotVVM is also similar to Web Forms in many ways and doesn't require extensive knowledge of JavaScript, so it is very easy to adopt to any .NET developer.

> See [VB.NET version of the sample](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet) if you are using VB.NET in your Web Forms app. There are known issues with DotVVM for Visual Studio extension in VB.NET projects, so we recommend using DotVVM with C# in a separate project that is referenced from the Web Forms VB.NET project.

## About the sample

This sample demonstrates how DotVVM can be used in the process of incremental modernization of Web Forms applications. Every step of the process can be seen by checking out one of the repository branches. 

We recommend to install an extension for Visual Studio that brings the IntelliSense and templates for DotVVM files.

* [DotVVM for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=TomasHerceg.DotVVMforVisualStudio-17892)
* [DotVVM for Visual Studio 2019](https://marketplace.visualstudio.com/items?itemName=TomasHerceg.DotVVM-VSExtension2019)

### Step 1: The `01_webforms` branch contains a simple ASP.NET Web Forms application with a few pages and a simple usage of the `GridView` control.

### Step 2: The `02_install_dotvvm` branch shows how to install DotVVM in the project.

* Install `Dotvvm.Owin` NuGet package.
* Install `Microsoft.Owin.Host.SystemWeb` package.
* Add the OWIN Startup Class [Startup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/02_install_dotvvm/src/OldWebApp/OldWebApp/Startup.cs).
* Add the DotVVM Configuration file [DotvvmStartup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/02_install_dotvvm/src/OldWebApp/OldWebApp/DotvvmStartup.cs).
* Add the DotVVM project type GUID (`94EE71E2-EE2A-480B-8704-AF46D2E58D94`) as a first one in the `<ProjectTypeGuids>` element in [OldWebApp.csproj](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/02_install_dotvvm/src/OldWebApp/OldWebApp/OldWebApp.csproj#L12) to make the DotVVM extension in Visual Studio work properly.

Now you can create new pages in the application using DotVVM, and start an incremental upgrade of the ASPX pages to DotVVM. See the [differences cheat-sheet](https://www.dotvvm.com/webforms) to learn about the differences between DotVVM and ASP.NET Web Forms.

### Step 3: The `03_migration_in_progress` branch shows some pages migrated to DotVVM while the rest remains in ASP.NET Web Forms.

* A master page [Site.dotmaster](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/Views/Site.dotmaster) was created. Its content was copied with a few changes made: `asp:ContentPlaceHolder` was changed to `dot:ContentPlaceHolder`, all the `runat="server"` were removed and so on. 
* A viewmodel [SiteViewModel.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/ViewModels/SiteViewModel.cs) with an abstract property `Title` was added in the project. 
* A resources for jQuery and Bootstrap were configured in [DotvvmStartup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/DotvvmStartup.cs).
* The [About.dothtml](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/Views/About.dothtml) page was migrated in DotVVM.
* The route registrations for the migrated pages were moved from [Global.asax.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/Global.asax.cs) to [DotvvmStartup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/DotvvmStartup.cs).

The deployment model of the application remains the same - you don't need to change anything. This stage can take a long time as there may be hundreds of pages in the application.

During the migration, you can make another refactorings, and thanks to the MVVM approach of DotVVM, your viewmodels will be testable. This can improve the further maintainability of the application.

### Step 4: The `04_migration_complete` branch shows all the pages migrated to DotVVM.

* The [Default.dothtml](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/04_migration_complete/src/OldWebApp/OldWebApp/Views/Default.dothtml) was migrated and demonstrates the [GridView](https://www.dotvvm.com/docs/controls/builtin/GridView/latest) and [DataPager](https://www.dotvvm.com/docs/controls/builtin/DataPager/latest) controls in DotVVM. 
* The [DefaultViewModel.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/04_migration_complete/src/OldWebApp/OldWebApp/ViewModels/DefaultViewModel.cs) demonstrates the MVVM approach for data-binding and the usage of `GridViewDataSet`.

At the end of this stage, the application doesn't use any of the ASP.NET Web Forms features, so it's ready to be switched to .NET Core.
In real-world applications, there might be some other things to change like authentication (needs to be migrated to ASP.NET Core packages), bundling and more. All these things will need to be addressed during the next step.

### Step 5: The `05_dotnetcore` branch shows the changes made to the project file in order to switch the project to .NET Core 3.0.

* The [OldWebApp.NetCore.csproj](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/05_dotnetcore/src/OldWebApp/OldWebApp.NetCore/OldWebApp.NetCore.csproj) was converted to the new format and the `Dotvvm.Owin` package was replaced by `Dotvvm.AspNetCore`.
* The scripts and CSS files were moved to the `wwwroot` folder.
* The [Startup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration/blob/05_dotnetcore/src/OldWebApp/OldWebApp.NetCore/Startup.cs) was updated to use the ASP.NET Core `IServiceCollection` and `IAppBuilder`.

Switching to .NET Core may require additional configuration steps on the server to be performed. Make sure you plan this process in advance so the upgrade process is smooth.

## Conclusion

As you can see, the migration is not easy - there is no magic wizard that will just "convert" the application from ASP.NET Web Forms. However, this method allows to migrate the application while new features can be added continuously, and means much less effort than a total rewrite. You can also learn DotVVM on the fly, start with simple pages and continue with the complex ones. 

> See [VB.NET version of the sample](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet) if you are using VB.NET in your Web Forms app.

## Other resources

* [DotVVM for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=TomasHerceg.DotVVMforVisualStudio-17892)
* [DotVVM for Visual Studio 2019](https://marketplace.visualstudio.com/items?itemName=TomasHerceg.DotVVM-VSExtension2019)
* [DotVVM GitHub](https://github.com/riganti/dotvvm)
* [DotVVM Home Page](https://www.dotvvm.com)
* [Differences between DotVVM and ASP.NET Web Forms](https://www.dotvvm.com/webforms)
* [DotVVM Academy](https://academy.dotvvm.com)
* [Documentation](https://www.dotvvm.com/docs)
* [Gitter Chat](https://gitter.im/riganti/dotvvm)


 

 