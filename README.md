# EntitySearch


## Use Case


For ASP.NET MVC applications, provide a way of tracking "recently visited pages" and search functionality.  Support bootstrap theming.

Provide a search box where:
* Users will see recent pages in a drop down.
* Users can search for entities with auto-complete.

## How to use EntitySearch

* Include the js file in your Layout or _ViewStart.cstml file.
	TODO: Provide example
* Create a text box with HTML attribute data-entity-search
	TODO: Provide example
* Create a controller action like this and seed the search engine with your data
	TODO: Provide example



## TODOs
1. Track recents in local storage.
1. Retrive recents in searchPopup.
1. Recent object should have lastVisted prop.
1. Allow search boxes filtered by entity type (for linking)
1. Security groups (filter the search by tenant/security group?)
1. Fix git repo for Windows line endings.