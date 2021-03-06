# EntitySearch

This project is in development. 

## Use Case

TODO: Add pictures.

For ASP.NET MVC applications, provide a way of tracking "recently visited pages" and search functionality.  Support bootstrap theming.

Provide a search box where:
* Users will view and click on recent pages in a drop down.
* Users can search for entities with auto-complete.

## How to use EntitySearch

* Open your _Layout.cshtml file.

* Include the js file.

```javascript
<script src=@Url.Content("~/Scripts/entity-search.js")></script>
```

* Create a text box with HTML attribute `data-entity-search`.

```cshtml
<form class="navbar-form navbar-left" role="search">
    <div class="form-group">
        <input data-entity-search type="text" class="form-control" placeholder="Search" id="entity-search-in-nav">
    </div>
</form>
```

* Add the `data-entity-search-route-data` attribute with route info JSON to pages you want to be tracked.

```cshtml
@{
    var routeValues = ViewContext.RouteData.Values.ToDictionary(x => x.Key, x => x.Value);
    // You will need to customize this if statement to configure which pages you want to be searchable.
    if (routeValues.ContainsKey("action")
        && (string)routeValues["action"] != "Edit"
        && (string)routeValues["action"] != "Create"
        && (string)routeValues["action"] != "Delete")
    {
        <script data-entity-search-route-data type="application/json">@Html.Raw(Json.Encode(routeValues))</script>
    }
}
```

* Create a controller action like this and seed the search engine with your data
	TODO: Provide example

## Assumptions
1. Developers will not want to create new data structures to use EntitySearch. 
1. Therefore, localStorage will suffice for recent tracking. But, recents will be different across user devices...
1. Developers do not want libraries that have tons of dependencies.  Therefore, this is written in pure javascript instead of jQuery.  Also other libraries like underscore are not used.

## TODOs
### Necessary
1. make the config for locslStorage vs. AJAX better. Don't use a magic string. 
1. Add config for localStorage key to be `new Uri(Request.Url, Url.Content("~"))`. Or maybe this can be done in the framework so users don't have to require config settings. 
1. Get Web Essentials minification working. 
1. data-entity-search-config script tag with JSON content like this
```javascript
{
  "recents": {
    "max": 100,
    "popup": {
      "show": 6
    },
    "storage": {
      "type": "localStorage",
      "uri": "http://some/endpoint",
    },
    "classes": {
      "Warehouses": "building",
      "Customers": "user",
      "Products": "package",
      "Inventory": "inventory",
      "Orders": "cart"
    }
  },
  "search": {
    "idleDelayMs": 500,
    "minCharactersToSearch": 2,
    "suggestions" : {
      "show": 5
    }
  }
}
```
    1. QUnit tests
    1. console.error if config is bad JSON. 
    1. Code to set defaults if missing or partial config. 
    1. Put in EntitySearch.Config. 
1. Implement glyphicons or css classes for recents. 
1. Do not track a recent page if the same page is visited repeatedly.
1. Revert gulp, node, npm commit.
1. Build QUnit tests for recent tracking
1. Refactor to RecentPage object.
1. Search for TODOs in code.
1. Look at MSFT Cognitive Team to see if we can use anything from that.
1. Research other solutions that track recents and/or do search.
1. Implement a top 100 recents page / modal that can be filtered.
1. Investigate Microsoft Azure Search REST API
1. Support API for storing recents cross-device. 

### Search
1. Search recents in localstorage first?  Combine and distinct with search results?
1. Build cache object
1. LINQ to load cache in app start?
1. Simple full text search before implementing indexes. 
1. add search by ID to the demo app. 
1. POST action to maintain cache on CRUD actions.  Update indexes. 
1. Build indexes. 
1. Async Controller actions for auto complete and search results
1. Wire up auto complete events to hit controller action XHR. 
1. cache metadata metric for popular search items. 
1. Prioritize popular items in search. 
1. Way to limit cache memory size. 

### Nice to have / Future
1. Can we do search auto-complete from a public API?  Example, start typing Bos and get suggestions like Boston, Bose, etc.
1. Can we implement viewer history from different sources?  For example, if an app already tracks viewer history from some other means, can we hook into it?  (Via XHR)
1. for multi tenant or multiple user accounts in an app, need to key local storage of recents by a base url/user group?
1. Allow search boxes filtered by entity type (for linking)
1. Security groups (filter the search by tenant/security group?)
1. Number of results in popup data element.  Example: data-entity-search="{show:5}"
1. Fix git repo for Windows line endings.
1. Hit Esc key to close recentPopup.
1. Support different "areas" for a single application.  This would control the key in local storage. 
1. similarly, we could pass in the base URL and virtual directory to solve the problem of two applications on the same server.  this would be used for the local storage key. 

## Completed Features
1. Mechanism to get Route info into local storage. data attribute on page?  We can't assume page title is what people will want to appear in the recent list. although that is the default. We also can't assume a certain route config (controller/action/id). Also by allowing devs to control when recent data is added to the page, they can choose to not track edit or create pages. 
1. Track recents in local storage.
1. Retrive recents in searchPopup.
1. Recent object should have lastVisted, title, url (from document.location.href), entity type (controller), all route values including ID.
1. Need to fix duplicates and sort order.
1. Have a max recents. (100)
1. Use QUnit for testing - fewer dev dependencies.
1. Add javascript tests.

# For Developers

Do you want to help develop and improve this tool?  Great.

Please look at the [Developer Readme!](DEVELOPER_README.md)

