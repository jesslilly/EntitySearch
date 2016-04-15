





describe('recentPage constructor', function () {
	
	it('should throw an exception when not all args passed.', function () {
		expect(function () {
			new RecentPage({
				a : "abc.js",
				b : "in.log"
			});
		}).toThrow();
	});
});