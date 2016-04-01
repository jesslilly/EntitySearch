
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

(function (document) {

    console.log("entity-search loaded.");

    function showSearchPopup() {
        console.log("showSearchPopup on " + this.id);
        var newDiv = document.createElement("div");
        newDiv.id = 'entity-search-popup'; // TODO come up with a better way.
        var newContent = document.createTextNode("Recently Viewed Pages");
        newDiv.appendChild(newContent);
        newDiv.style.position = "absolute";
        newDiv.style.zIndex = 999;
        newDiv.style.backgroundColor = "#FFFFFF";
        //newDiv.style.top = "50px;";
        //newDiv.style.left = "50px;";
        this.parentElement.appendChild(newDiv);
    }

    function hideSearchPopup() {
        console.log("hideSearchPopup");
        var searchPopup = document.getElementById("entity-search-popup");
        searchPopup.parentElement.removeChild(searchPopup);
    }

    function pageLoad() {
        var searchBoxes = document.querySelectorAll('[data-entity-search]');
        // http://stackoverflow.com/questions/13433799/why-doesnt-nodelist-have-foreach
        for (var index = 0; index < searchBoxes.length; index++) {
            var searchBox = searchBoxes[index];
            searchBox.addEventListener("focus", showSearchPopup);
            searchBox.addEventListener("blur", hideSearchPopup);
        }
    }

    pageLoad();

})(document);