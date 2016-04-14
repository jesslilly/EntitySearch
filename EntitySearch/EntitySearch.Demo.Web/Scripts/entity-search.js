// todo refactor all this code to be more testable and object oriented.

// TODO It might be nice to allow users to create their own template for the drop down?
//<template class="hello-template">
//  <div class="hello">
//    Hello, world!
//  </div>
//</template>
//<script>
//  var helloTemplate = document.querySelector('.hello-template');
//  var helloDiv = document.importNode(helloTemplate.content, true);
//  document.querySelector('body').appendChild(helloDiv);
//</script>

(function (document, window) {

    console.log("entity-search loaded.");

    function hideSearchPopup(event) {
        console.log("hideSearchPopup on " + this.id);
        var element = this;

        // TODO there has got to be a better way to do this, but blur fires before focus on the next element.
        window.setTimeout(function () {

            // Get the search group id.
            var group = element.getAttribute("data-entity-search-group");

            // If the activeElement is in this group, don't hide yet.
            if (document.activeElement.getAttribute("data-entity-search-group") === group) {
                return;
            }
            var searchPopup = document.querySelector("[data-entity-search-popup-id='" + group + "']");
            // TODO perhaps add code here to hide instead of destroy.
            searchPopup.parentElement.removeChild(searchPopup);
        }, 200);
    }

    function createPopup(searchBox) {
        var popup = document.createElement("div");
        var group = searchBox.getAttribute("data-entity-search-box-id");
        popup.className = "list-group";
        popup.setAttribute("data-entity-search-popup-id", group);
        popup.style.position = "absolute";
        popup.style.zIndex = 999;
        // TODO I suppose I should include CSS or a custom class name so devs can override this?
        popup.style.backgroundColor = "#FFFFFF";
        popup.style["box-shadow"] = "0px 4px 4px lightgray";

        var recents = getTopDistinctRecents(8); // todo make this 8 configurable?

        recents.forEach(function (recentPage, index) {
            var a = document.createElement("a");
            //a.title = "Go to " + recentPage.title; Link titles are distracting.
            a.href = recentPage.href;
            a.className = "list-group-item";
            a.setAttribute("data-entity-search-group", group);
            a.addEventListener("blur", hideSearchPopup);
            var linkText = document.createTextNode(recentPage.title);
            a.appendChild(linkText);
            popup.appendChild(a);
        });
        return popup;
    }

    function showSearchPopup() {
        console.log("showSearchPopup on " + this.id);
        var group = this.getAttribute("data-entity-search-group");
        var searchPopup = document.querySelector("[data-entity-search-popup-id='" + group + "']");

        // It would be bad to create the search popup more than once, so return if exists.
        if (searchPopup) {
            return;
        }

        var popup = createPopup(this);
        this.parentElement.appendChild(popup);
    }

    function trackRecentPage() {
        var scriptElement = document.querySelector("script[data-entity-search-route-data]");
        if (!scriptElement) {
            return;
        }
        var pageInfo = JSON.parse(scriptElement.textContent);
        if (pageInfo) {
            pageInfo.href = document.location.href;
            pageInfo.lastVisted = new Date();
            // Users can set their own custom page title in the route data json if they want.
            if (!pageInfo.title) {
                pageInfo.title = document.title;
                addToLocalStorage(pageInfo);
            }
        }
    }

    function addToLocalStorage(pageInfo) {
        // The key to localStorage is important.
        // TODO investigate if roots https://myhost.com/app1 and https://myhost.com/app2 are the same.  I think they are!  If they are, we need to add the virtual directory to the key.
        // We have to use href here for now.  We can't assume a default ASP.NET MVC RouteConfig.
        // TODO Some way of setting a max number of recent tracking.
        // TODO instead of many keys, perhaps use one key with an object.  Might be inefficient to JSON.parse the object all the time?
        // TODO prevent duplicates.  Maybe use a map instead of an array.
        var key = "entity-search-"; // TODO + base url;

        var recents = JSON.parse(localStorage.getItem(key));
        if (! Array.isArray(recents)) {
            recents = [];
        }
        // Always add to the beginning of the array it is always sorted by most recently visited.
        recents.unshift(pageInfo);

        // TODO make this configurable.
        if (recents.length > 100) {
            recents.pop();
        }

        localStorage.setItem(key, JSON.stringify(recents));
    }

    function getFromLocalStorage() {
        var key = "entity-search-"; // TODO + base url;
        return JSON.parse(localStorage.getItem(key));
    }

    // TODO better jsdoc type comments.
    // Return the top N distinct recently visited pages.
    // (The memory structure for recents allows duplicates.)
    function getTopDistinctRecents(count) {
        var recents = getFromLocalStorage();
        if (!recents) {
            return [];
        }

        // todo seed array with certain size?
        var topRecents = [];
        if (recents.length < count) {
            count = recents.length;
        }

        for (var index = 0; index < recents.length && topRecents.length < count; index++) {
            var recent = recents[index];

            // Exclude the current page from recents.
            if (recent.href === document.location.href) {
                continue;
            }

            // Exclude duplicates (Distinct).
            var isDuplicate = false;
            for (var index2 = 0; index2 < topRecents.length; index2++) {
                var topRecent = topRecents[index2];
                if (topRecent.href === recent.href) {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate) {
                topRecents.push(recent);
            }
        }
        return topRecents;
    }

    function pageLoad() {

        trackRecentPage();

        var searchBoxes = document.querySelectorAll("[data-entity-search]");
        // http://stackoverflow.com/questions/13433799/why-doesnt-nodelist-have-foreach
        for (var index = 0; index < searchBoxes.length; index++) {
            var searchBox = searchBoxes[index];
            searchBox.addEventListener("focus", showSearchPopup);
            searchBox.addEventListener("blur", hideSearchPopup);
            // Allows for more than one search box on a page.
            searchBox.setAttribute("data-entity-search-box-id", index);
            searchBox.setAttribute("data-entity-search-group", index);
        }
    }

    pageLoad();

})(document, window);