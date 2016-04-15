QUnit.test("EntitySearch.qUnitSample", function (assert) {
    assert.ok(EntitySearch.qUnitSample("") === 0);
    assert.ok(EntitySearch.qUnitSample("1") === 1);
    assert.ok(EntitySearch.qUnitSample("qwertyuiop") === 10);
});
QUnit.test("EntitySearch.getLocalStorageKey", function (assert) {
    assert.ok(EntitySearch.getLocalStorageKey() === "entity-search-");
});