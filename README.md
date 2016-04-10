# EntitySearch

This project is in development. 

## Use Case


For ASP.NET MVC applications, provide a way of tracking "recently visited pages" and search functionality.  Support bootstrap theming.

Provide a search box where:
* Users will view and click on recent pages in a drop down.
* Users can search for entities with auto-complete.

## How to use EntitySearch

* Include the js file in your Layout or _ViewStart.cstml file.
	TODO: Provide example
* Create a text box with HTML attribute data-entity-search
	TODO: Provide example
* Add data- attribute to pages you want to be tracked. TODO: Code example. 
* Create a controller action like this and seed the search engine with your data
	TODO: Provide example

## Assumptions
1. Developers will not want to create new data structures to use EntitySearch. 
1. Therefore, localStorage will suffice for recent tracking. But, recents will be different across user devices...
1. Developers do not want libraries that have tons of dependencies.  Therefore, this is written in pure javascript instead of jQuery.  Also other libraries like underscore are not used.

## TODOs
### Necessary
1. Need to fix duplicates and sort order.
1. Add javascript tests.  Maybe use a test page, or jasmine.
1. Search for TODOs in code.

### Nice to have / Future
1. for multi tenant or multiple user accounts in an app, need to key local storage of recents by a base url/user group?
1. Allow search boxes filtered by entity type (for linking)
1. Security groups (filter the search by tenant/security group?)
1. Number of results in popup data element.  Example: data-entity-search="{show:5}"
1. Fix git repo for Windows line endings.

## Done
1. Mechanism to get Route info into local storage. data attribute on page?  We can't assume page title is what people will want to appear in the recent list. We also can't assume a certain route config (controller/action/id). Also by allowing devs to control when recent data is added to the page, they can choose to not track edit or create pages. 
1. Track recents in local storage.
1. Retrive recents in searchPopup.
1. Recent object should have lastVisted, title, url (from document.location.href), entity type (controller), all route values including ID.

