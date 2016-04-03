
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
        popup.style.backgroundColor = "#FFFFFF";

        var links = [
            "/Warehouses/Details/5",
            "/Warehouses/Details/6",
            "/Warehouses/Details/7",
            "/Warehouses/Details/8",
        ];

        links.forEach(function (link, index) {
            var a = document.createElement("a");
            a.title = "Go to " + link;
            a.href = link;
            a.className = "list-group-item";
            a.setAttribute("data-entity-search-group", group);
            a.addEventListener("blur", hideSearchPopup);
            var linkText = document.createTextNode("Go to " + link);
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

    function pageLoad() {
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