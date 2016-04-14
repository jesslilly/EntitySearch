# EntitySearch

This project is in development. 

## Use Case


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

* Add the `data-entity-search-route-data` attribute to pages you want to be tracked.

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
1. Add javascript tests.  Maybe use a test page, or jasmine.
1. Refactor to RecentPage object.
1. Search for TODOs in code.
1. Have a max recents.

### Nice to have / Future
1. for multi tenant or multiple user accounts in an app, need to key local storage of recents by a base url/user group?
1. Allow search boxes filtered by entity type (for linking)
1. Security groups (filter the search by tenant/security group?)
1. Number of results in popup data element.  Example: data-entity-search="{show:5}"
1. Fix git repo for Windows line endings.
1. Hit Esc key to close recentPopup.

## Done
1. Mechanism to get Route info into local storage. data attribute on page?  We can't assume page title is what people will want to appear in the recent list. We also can't assume a certain route config (controller/action/id). Also by allowing devs to control when recent data is added to the page, they can choose to not track edit or create pages. 
1. Track recents in local storage.
1. Retrive recents in searchPopup.
1. Recent object should have lastVisted, title, url (from document.location.href), entity type (controller), all route values including ID.
1. Need to fix duplicates and sort order.

